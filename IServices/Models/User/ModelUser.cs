using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Модели интерфейса для пользователя
/// </summary>
namespace IServices.Models.User
{
    /// <summary>
    /// Модель пользователя
    /// </summary>
    public class ModelUser
    {
        /// <summary>
        /// Ид пользователя
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Логин пользователя
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Дата рождения 
        /// </summary>
        public string dateBird { get; set; }
        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Фото пользователя
        /// </summary>
        public string Photo { get; set; }
        /// <summary>
        /// Почта пользователя
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Авторизован пользователь или нет
        /// </summary>
        public bool IsAuth { get; set; }
        /// <summary>
        /// Роль пользователя
        /// </summary>
        public List<ModelRole> Roles { get; set; }
    }
}
