using Blog.Infrastructura;
using IServices;
using IServices.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Areas.Admin.Controllers
{
    /// <summary>
    /// Базовый контролер 
    /// </summary>
    public class BaseController : Controller
    {
        public IMainServices Services { get; set; }
        public IAdminServices AdminServices { get; set; }

        public BaseController()
        {
            Services = DependencyResolver.Current.GetService<IMainServices>();
            AdminServices = DependencyResolver.Current.GetService<IAdminServices>();
            User = WebUser.CurrentUser;

        }

        public new ModelUser User { get; set; }
    }
} 