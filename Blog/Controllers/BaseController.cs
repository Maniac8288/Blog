using Blog.Infrastructura;
using IServices;
using IServices.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    /// <summary>
    /// Базовый контролер 
    /// </summary>
    public class BaseController : Controller
    {
        public IMainServices Services { get; set; }
       
        public DataContext db = new DataContext();
        public BaseController()
        {
            Services = DependencyResolver.Current.GetService<IMainServices>();
            User = WebUser.CurrentUser;
           
        }

        public new ModelUser User { get; set; }
    }
}