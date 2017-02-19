﻿
using DataModel;
using IServices.Sublntefac.Public;
using Services.Exextension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    /// <summary>
    /// Класс реализующий вход и регистрацию на сайте
    /// </summary>
    public class UserServices : IUserServices
    {
        #region Авторизация
        /// <summary>
        /// Метод проверяет совпадает ли логин и пароль с данными из БД
        /// </summary>
        /// <param name="userName">Имя пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <returns>Возвращает совпадает ли данные с БД</returns>
        public bool Login(string userName, string password)
        {
            using (var db = new DataContext())
            {
                var auth = db.Users.Any(_ => _.UserName == userName && _.Password == (_.Salt + password).sha256() && _.Status==true);
                 if (auth)
                {
                 var user =  db.Users.FirstOrDefault(_ => _.UserName == userName);
                    user.LastVisit = DateTime.Now; 
                    db.SaveChanges();
                }
                return auth;
            }
        }
        /// <summary>
        /// Проверяет роль пользователя
        /// </summary>
        /// <param name="check">Совпадает ли роль с БД</param>
        /// <param name="role">Роль пользователя</param>
        /// <param name="UserName">Имя пользователя</param>
        /// <returns>Возвращает совпадает ли роль с БД</returns>
        public static bool check(bool check, string role, string UserName)
        {
            using (var db = new DataContext())
            {
                var t = db.Users.Where(x => x.Roles.Any(y => y.Name == role));
                check = t.Any(x => x.UserName == UserName);
            }
            return check;
        }
        #endregion
        #region Регистрация
        /// <summary>
        /// Метод реализующий регистрацию 
        /// </summary>
        /// <param name="userName">Имя пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <param name="dataBird">Дата рождения пользователя</param>
        public string Register(string userName, string password, DateTime dataBird, string email)
        {

            string salt = Security.getSalt();
            using (var db = new DataContext())
            {
                User user = new User()
                {
                    UserName = userName,
                    Password = (salt + password).sha256(),
                    Salt = salt,
                    Datebirth = dataBird,
                    Email = email,
                    Status = false,
                    CheckEmail = new CheckEmail
                    {
                        ConfirmedEmail = false,
                        ConfirmationCode = salt
                    },
                    Roles = db.Roles.Where(_ => _.Id == TypeRoles.User).ToList()
                };
                db.Users.Add(user);
                db.SaveChanges();
            }
            return salt;
        }
        /// <summary>
        /// Изменяет в БД Статус и потверждение емайла на true
        /// </summary>
        /// <param name="salt">Соль</param>
        /// <param name="userName">Никнейм</param>
        /// <returns></returns>
        public bool ConfrimedEmail(string salt, string userName)
        {
            using (var db = new DataContext())
            {
                var user = db.Users.FirstOrDefault(_ => _.UserName == userName);
                var check = db.ChecksEmail.FirstOrDefault(x => x.UserId == user.Id);
                if (db.ChecksEmail.Any(x => x.ConfirmationCode == salt))
                {
                    user.Status = true;
                    check.ConfirmedEmail = true;
                    db.SaveChanges();
                    return true;
                }
                else return false;
            }
        }
        #endregion
    }
}

