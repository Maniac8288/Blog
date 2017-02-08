using Blog.Infrastructura;
using IServices;
using IServices.Models;
using PostModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class BaseController : Controller
    {
        public IMainServices Services { get; set; }
        public PostContext db = new PostContext();
        public BaseController()
        {
            Services = DependencyResolver.Current.GetService<IMainServices>();
            User = WebUser.CurrentUser;

        }

        public new ModelUser User { get; set; }
    }
}