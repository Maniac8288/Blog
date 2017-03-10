using System;
using System.Collections.Generic;
using DataModel;
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
 public   class ModelUserInfo
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
        /// Дата регистрации
        /// </summary>
        public DateTime DateRegister { get; set; }
        /// <summary>
        /// Почта пользователя
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Роль пользователя
        /// </summary>
        public List<ModelRole> Roles { get; set; }
        /// <summary>
        /// Последний визит пользователя
        /// </summary>
        public DateTime LastVisit { get; set; }
        /// <summary>
        /// Статус пользователя
        /// </summary>
        public EnumStatusUser Status { get; set; }
    }
}
