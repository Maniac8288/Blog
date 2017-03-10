using System.Collections.Generic;
/// <summary>
/// The DataModel namespace.
/// </summary>
namespace DataModel
{
    /// <summary>
    /// Модель с ролями.
    /// </summary>
    public class Role
    {
        /// <summary>
        /// ИД роли.
        /// </summary>
        /// <value>ИД.</value>
        public TypeRoles Id { get; set; }
        /// <summary>
        /// Название роли.
        /// </summary>
        /// <value>Имя.</value>
        public string Name { get; set; }
        /// <summary>
        /// Пользователи.
        /// </summary>
        /// <value>Пользователи.</value>
        public List<User> Users { get; set; }
    }
    /// <summary>
    /// Enum Роли
    /// </summary>
    public enum TypeRoles
    {
        Admin,
        User
    }
}