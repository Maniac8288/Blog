using Blog;
using DataModel;
using IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    /// <summary>
    /// Класс реализующий вход на сайте
    /// </summary>
    public class UserServices : IUserServices
    {
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
                return db.Users.Any(_ => _.UserName == userName && _.Password == _.Salt+password);
            }
        }
        public static bool check(bool u, string role, string UserName)
        {
            using (var db = new DataContext())
            {
                var t = db.Users.Where(x => x.Roles.Any(y => y.Name == role));
                u = t.Any(x => x.UserName == UserName);
            }
            return u;
        }   
        }
    }

