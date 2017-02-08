using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View(db.Posts.OrderByDescending(x => x.dateAddPost));
        }

       public ActionResult News()
        {
            return View();
        }
        public ActionResult Paper()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}