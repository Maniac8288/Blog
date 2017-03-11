using Blog.Infrastructura;
using IServices;
using IServices.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

/// <summary>
///Контролеры админки.
/// </summary>
namespace Blog.Areas.Admin.Controllers
{
    /// <summary>
    /// Базовый контролер 
    /// </summary>
    public class BaseController : Controller
    {   
     
        /// <summary>
        /// Интерфейс админки
        /// </summary>
        public IAdminServices AdminServices { get; set; }

        /// <summary>
        /// Конструктор базового контролера админки <see cref="BaseController"/> .
        /// </summary>
        public BaseController()
        {
           
            AdminServices = DependencyResolver.Current.GetService<IAdminServices>();
            User = WebUser.CurrentUser;

        }
        /// <summary>
        /// Модель пользователя 
        /// </summary>
        public new ModelUser User { get; set; }
    }
} 