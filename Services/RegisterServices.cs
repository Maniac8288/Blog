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
        public bool Register(string userName, string password,DateTime dataBird,string email)
        {
            try
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
                        Status = true,
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
                return true;
            }
            catch 
            {
                return false;
            }
            
        }

    }
}
