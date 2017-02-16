using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Areas.Admin.Controllers
{
    public class AdminController : BaseController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Users()
        {
            var usres = Services.Admin.Users();
            return View(usres);
        }
        public ActionResult NewPost()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Delete( List<int> Select)
        {
            Services.Admin.Delete(Select);
            return RedirectToAction("Users");
        }
        [HttpPost]
        public ActionResult Block(List<int> Select)
        {
            Services.Admin.Block(Select);
            return RedirectToAction("Users");

        }
    }
}