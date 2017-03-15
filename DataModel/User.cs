using DataModel.Models;
using System;
using System.Collections.Generic;
/// <summary>
/// The DataModel namespace.
/// </summary>
namespace DataModel
{
    /// <summary>
    /// Модель пользователей.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Id Пользователя
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Логин пользователя
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Пароль пользователя
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Дата рождения пользователя
        /// </summary>
        public DateTime Datebirth { get; set; }
        /// <summary>
        /// Аватарка пользователя
        /// </summary>
        public string Photo { get; set; }
        /// <summary>
        /// Соль пользователя
        /// </summary>
        public string Salt { get; set; }
        /// <summary>
        /// Почта пользователя 
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Время последний авторизции пользователя
        /// </summary>
        public DateTime LastVisit { get; set; }
        /// <summary>
        /// Дата регистрации пользователя
        /// </summary>
        public DateTime DateRegister { get; set;}
       /// <summary>
       /// Роли 
       /// </summary>
        public List<Role> Roles { get; set; }
        /// <summary>
        /// Посты
        /// </summary>
        public List<Post> Posts { get; set; }
        /// <summary>
        /// Проверка EMail
        /// </summary>
        public CheckEmail CheckEmail { get; set; }
        /// <summary>
        /// Статус пользователя
        /// </summary>
        public EnumStatusUser StatusUserId { get; set; }
        /// <summary>
        /// Список статусов
        /// </summary>
        public List<Comment> Comments { get; set; }

    }
    /// <summary>
    /// Enum EnumStatusUser
    /// </summary>
    public enum EnumStatusUser
    {
        Locked,
        Confirmed,
        NConfirmed
    }
    /// <summary>
    /// Модель статуса пользователя.
    /// </summary>
    public class StatusUser
    {
        /// <summary>
        /// Ид статуса.
        /// </summary>
        /// <value>ИД.</value>
        public EnumStatusUser Id { get; set; }

        /// <summary>
        /// Название статуса.
        /// </summary>
        /// <value>Имя.</value>
        public string Name { get; set; }
        /// <summary>
        /// Пользователи.
        /// </summary>
        /// <value>Пользователи.</value>
        public List<User> Users { get; set; }
    }
}