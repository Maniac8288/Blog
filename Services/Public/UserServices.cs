
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
                var sha = db.Users.FirstOrDefault(_ => _.UserName == userName);
                string ShaPassword = (sha.Salt + password).sha256();

                var auth = db.Users.Any(_ => _.UserName == userName && _.Password == ShaPassword && _.StatusUserId != EnumStatusUser.Locked);
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
        /// <summary>
        /// Заменяет старый пароль в БД на новый
        /// </summary>
        /// <param name="email">Почта пользователя</param>
        /// <param name="password">Новый пароль</param>
        public void ForgotPW(string email, string password)
        {
            using ( var db = new DataContext()){
                var user = db.Users.FirstOrDefault(_ => _.Email == email);
                user.Password = (user.Salt+password).sha256();
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Возвращает ID пользователя
        /// </summary>
        /// <param name="UserName">Имя пользователя</param>
        /// <returns></returns>
        public int IdUser(string UserName)
        {
            using (var db = new DataContext())
            {
              var user =  db.Users.FirstOrDefault(x => x.UserName == UserName);
                return user.Id;

            }
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
              
                
                    User NewUser = new User()
                    {
                        UserName = userName,
                        Password = (salt + password).sha256(),
                        Salt = salt,
                        Datebirth = dataBird,
                        Email = email,
                        StatusUserId = EnumStatusUser.NConfirmed,
                        CheckEmail = new CheckEmail
                        {
                            ConfirmedEmail = false,
                            ConfirmationCode = salt
                        },
                        Roles = db.Roles.Where(_ => _.Id == TypeRoles.User).ToList()
                    };
                    db.Users.Add(NewUser);
                    db.SaveChanges();
                    return salt;
                
               
               
            }
            
        }
        /// <summary>
        /// Проверка существует ли пользователь
        /// </summary>
        /// <param name="userName">Логин пользователя</param>
        /// <param name="email">Почта пользователя</param>
        /// <returns></returns>
        public bool CheckExistUser(string userName, string email)
        {
            using (var db = new DataContext())
            {
                var user = db.Users.FirstOrDefault(x => x.UserName == userName || x.Email == email);
                if (user == null)
                {
                    return false;
                }
                else return true;

            }
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
                    user.StatusUserId = EnumStatusUser.Confirmed;
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

