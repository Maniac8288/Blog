using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices.Sublntefac.Public
{
   public  interface IUserServices
    {
        #region Авторизация
        bool Login(string userName, string password);
        #endregion
        #region Регистрация 
        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="userName">Никнейм</param>
        /// <param name="password">Пароль</param>
        /// <param name="dataBird">Дата Рождения</param>
        /// <param name="email">Емаил пользователя</param>
        /// <returns>Вывод случайного слово для потверждения Email</returns>
        string Register(string userName, string password, DateTime dataBird, string email);
        /// <summary>
        /// Потверждения Email
        /// </summary>
        /// <param name="salt">Случайное слово</param>
        /// <param name="userName">Никнейм</param>
        /// <returns></returns>
        bool ConfrimedEmail(string salt, string userName);
        void ForgotPW(string email, string password);
        #endregion
    }
}
