﻿using IServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using System.Numerics;
using Services.Exextension;
using System.Net.Mail;
using IServices.Models.User;
using IServices.Models.Post;
/// <summary>
/// Инфраструктура сайта
/// </summary>
namespace Blog.Infrastructura
{
    /// <summary>
    ///Класс отвечающий за авторизацию пользователя.
    /// </summary>
    public class WebUser
    {
        /// <summary>
        /// The services
        /// </summary>
        private static IMainServices Services = DependencyResolver.Current.GetService<IMainServices>();
        /// <summary>
        ///  Модель пользователя содержащия сессию и куки в которой находится информация о состояние пользователя
        /// </summary>
        public static ModelUser CurrentUser
        {
            get
            {
                if (!(HttpContext.Current.Session["user"] is ModelUser))
                {

                    var data = HttpContext.Current.Request.Cookies["data"];
                    if (data == null || string.IsNullOrWhiteSpace(data.Value))
                    {
                        return new ModelUser();
                    }
                    else
                    {
                        var model = Decrypt(data.Value);
                        if (model != null)
                            Login(model.UserName, model.Password);
                        else return new ModelUser();
                    }
                }
                return HttpContext.Current.Session["user"] as ModelUser;
            }
            set
            {
                HttpContext.Current.Session["user"] = value;
            }
        }
        /// <summary>
        /// Метод выполняющий авторизацю на сайте
        /// </summary>
        /// <param name="userName">Имя пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <param name="RememberMe">Галочка-Запомнить меня</param>
        public static void Login(string userName, string password, bool RememberMe = false)
        {

            if (Services.Users.Login(userName, password)) 
            {

                CurrentUser = new ModelUser { UserName = userName, IsAuth = true, Password = password, Id=Services.Users.IdUser(userName)};
                if (RememberMe)
                {
                    HttpContext.Current.Response.Cookies.Add(new HttpCookie("data") { Value = Encrypt(CurrentUser), Expires = DateTime.Now.AddDays(1) });
                }
            }
        }
        /// <summary>
        /// Удаляет сессию и куки содержащию информацию о состояние авторизации пользователя
        /// </summary>
        public static void LogOff()
        {
            HttpContext.Current.Session.Remove("user");
            HttpContext.Current.Response.Cookies.Add(new HttpCookie("data") { Expires = DateTime.Now.AddDays(-1) });
        }
        /// <summary>
        /// Проверяет существует ли пользователь с данным логином или почтой в БД
        /// </summary>
        /// <param name="userName">Логин пользователя</param>
        /// <param name="email">Почта пользовтеля</param>
        /// <returns></returns>
        public static bool CheckExistUser(string userName,string email)
        {
            return Services.Users.CheckExistUser(userName, email);
          
        }
        /// <summary>
        /// Выполняет регистрацию пользователя на сайте
        /// </summary>
        /// <param name="userName">Имя пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <param name="dataBird">Дата рождения пользователя</param>

        public static string Register(string userName, string password, DateTime dataBird, string email)
        {
          string salt= Services.Users.Register(userName, password, dataBird, email);
            return salt;
        }

        /// <summary>
        /// Потверждения Email
        /// </summary>
        /// <param name="salt">Случайное слово</param>
        /// <param name="userName">Никнейм</param>
        public static void Confirmed(string salt,string userName)
        {
             Services.Users.ConfrimedEmail(salt,userName);
            }

        public static void SendMail(string subject, string email, string body)
        {
            MailMessage msg = new MailMessage();
            msg.To.Add(email);
            msg.Subject = subject;
            msg.Body = body;
            msg.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Send(msg);
        }
        /// <summary>
        /// Метод позволяющий воспользоваться функцией "Забыли пароль"
        /// </summary>
        /// <param name="email">Почта пользователя.</param>
        /// <param name="password">Пароль пользователя.</param>
        public static void ForgotPW(string email, string password)
        {
            Services.Users.ForgotPW(email, password);
        }
        /// <summary>
        /// Проверка роли пользователя
        /// </summary>
        /// <param name="userName">Имя пользователя</param>
        /// <param name="role">Роль пользователя</param>
        /// <returns><c>true</c> если роль совпадает, <c>false</c> иначе.</returns>
        public static bool CheckRole(string userName, string role)
        {
            return (Services.Users.CheckRole(userName, role));
        }

        #region Криптография

        static byte[] key = Encoding.UTF8.GetBytes("Some salt value0Some salt value0");

        static byte[] IV = Encoding.UTF8.GetBytes("Some salt value0");

        /// <summary>
        /// Шифровка модели.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>System.String.</returns>
        private static string Encrypt(ModelUser model)
        {
            using (Aes myAes = Aes.Create())
            {
                myAes.Key = key;
                myAes.IV = IV;
                byte[] encrypted = EncryptStringToBytes_Aes($"{model.UserName},{model.Password}", myAes.Key, myAes.IV);
                return new BigInteger(encrypted).ToString("x2");
            }
        }
        /// <summary>
        /// Расшифрование модели.
        /// </summary>
        /// <param name="encrypted">The encrypted.</param>
        /// <returns>ModelUser.</returns>
        private static ModelUser Decrypt(string encrypted)
        {
            using (Aes myAes = Aes.Create())
            {
                try
                {
                    myAes.Key = key;
                    myAes.IV = IV;
                    var number = BigInteger.Parse(encrypted, NumberStyles.HexNumber);
                    string roundtrip = DecryptStringFromBytes_Aes(number.ToByteArray(), myAes.Key, myAes.IV);
                    var mas = roundtrip.Split(',');
                    var model = new ModelUser() { UserName = mas[0], Password = mas[1] };
                    return model;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
        /// <summary>
        /// Шифровка строки.
        /// </summary>
        /// <param name="plainText">The plain text.</param>
        /// <param name="Key">The key.</param>
        /// <param name="IV">The iv.</param>
        /// <returns>System.Byte[].</returns>
        /// <exception cref="System.ArgumentNullException">
        /// plainText
        /// or
        /// Key
        /// or
        /// IV
        /// </exception>
        static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;
            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {

                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }


            // Return the encrypted bytes from the memory stream.
            return encrypted;

        }
        /// <summary>
        /// Расшифровка строки.
        /// </summary>
        /// <param name="cipherText">The cipher text.</param>
        /// <param name="Key">The key.</param>
        /// <param name="IV">The iv.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// cipherText
        /// or
        /// Key
        /// or
        /// IV
        /// </exception>
        static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }

            return plaintext;

        }
        #endregion
    }
}
