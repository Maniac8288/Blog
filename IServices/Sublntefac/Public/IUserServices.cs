﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Интерфейс функцианала публичной части
/// </summary>
namespace IServices.Sublntefac.Public
{
    /// <summary>
    /// Реализация авторизации и регистрации
    /// </summary>
   public  interface IUserServices
    {
        #region Авторизация        
        /// <summary>
        /// Проверяет логин  и пароль пользователя
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        bool Login(string userName, string password);
        /// <summary>
        /// Возвращает ID пользователя
        /// </summary>
        /// <param name="UserName">Name of the user.</param>
        /// <returns></returns>
        int IdUser(string UserName);
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
        /// <summary>
        /// Проверка роли пользователя
        /// </summary>
        /// <param name="role">Роль пользователя</param>
        /// <param name="userName">Имя пользователя</param>
        /// <returns></returns>
        bool CheckRole(string userName, string role);
        #endregion
    }
}
