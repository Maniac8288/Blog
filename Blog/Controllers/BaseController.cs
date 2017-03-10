using Blog.Infrastructura;
using IServices;
using IServices.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

/// <summary>
/// Контролеры сайта
/// </summary>
namespace Blog.Controllers
{
    /// <summary>
    /// Базовый контролер 
    /// </summary>
    public class BaseController : Controller
    {
        /// <summary>
        /// Переменная для связи с интерфейсом IMainServices 
        /// </summary>
      
        public IMainServices Services { get; set; }

        /// <summary>
        /// Конструктор контролера <see cref="BaseController"/>
        /// </summary>
        public BaseController()
        {
            Services = DependencyResolver.Current.GetService<IMainServices>();
            User = WebUser.CurrentUser;
           
        }
        /// <summary>
        /// Получает сведение о пользователи.
        /// </summary>
        /// <value>Пользователь</value>
        public new ModelUser User { get; set; }
    }
}