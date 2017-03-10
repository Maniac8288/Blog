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
    /// Модель роли
    /// </summary>
    public class ModelRole
    {
        /// <summary>
        /// Ид роли
        /// </summary>
        public ModelEnumTypeRoles Id { get; set; }
        /// <summary>
        /// Название роли
        /// </summary>
        public string Name { get; set; }
    }
    /// <summary>
    /// Список ролей
    /// </summary>
    public enum ModelEnumTypeRoles
    {
        Admin,
        Moderator,
        User
    }
}
