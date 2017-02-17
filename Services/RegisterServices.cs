using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IServices;
using DataModel;
using Services.Exextension;

namespace Services
{
    /// <summary>
    /// Класс реализующий регистрацию на сайте
    /// </summary>
    class RegisterServices : IRegisterServices
    {
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
                    Password = salt + password.sha256(),
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
                if (db.ChecksEmail.Any(x => x.ConfirmationCode == salt)) {
                    user.Status = true;
                    check.ConfirmedEmail = true;
                    db.SaveChanges();
                    return true;
                }
                else return false;
            }
        }
    }
          
 }
    






