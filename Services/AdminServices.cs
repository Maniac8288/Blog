    using IServices;
using IServices.Sublntefac.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Admin;

/// <summary>
/// Функционал сайта
/// </summary>
namespace Services
{
    /// <summary>
    /// Управление админкой
    /// </summary>
    public class AdminServices : IAdminServices
    {
        public AdminServices()
        {
            Users = new AdminUsersServices();
            Categories = new AdminCategoriesServices();
            ControlPosts = new AdminPostsServices();
        }
        /// <summary>
        /// Управление пользователями
        /// </summary>
        public IAdminUsersServices Users { get; set; }
        /// <summary>
        /// Управление категориями
        /// </summary>
        public IAdminCategoriesServices Categories { get; set; }
        /// <summary>
        /// Управление постами
        /// </summary>
        public IAdminPostsServices ControlPosts { get; set; }



    }
}
