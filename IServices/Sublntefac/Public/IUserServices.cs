using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices.Sublntefac.Public
{
    /// <summary>
    /// Реализация авторизации и регистрации
    /// </summary>
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
        /// <summary>
        /// Заменяет старый пароль в БД на новый
        /// </summary>
        /// <param name="email">Почта пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        void ForgotPW(string email, string password);
        /// <summary>
        /// Проверяет существует ли пользователь с данным логином или почтой в БД
        /// </summary>
        /// <param name="userName">Логин пользователя</param>
        /// <param name="email">Почта пользователя</param>
        /// <returns></returns>
        bool CheckExistUser(string userName, string email);
        #endregion
    }
}
