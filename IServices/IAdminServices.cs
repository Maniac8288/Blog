using IServices.Models;
using IServices.Sublntefac.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    /// <summary>
    /// Интерфейс Админки
    /// </summary>
    public interface IAdminServices
    {
        /// <summary>
        /// Реализует методы связанные с пользователями
        /// </summary>
        IAdminUsersServices Users { get; set; }
        /// <summary>
        ///Реализует методы связанные с категорями
        /// </summary>
        IAdminCategoriesServices Categories { get; set; }
    }
}
