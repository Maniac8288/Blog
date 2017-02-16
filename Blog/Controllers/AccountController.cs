using Blog.Infrastructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string userName, string password, string RememberMe)
        {

            WebUser.Login(userName, password, RememberMe == "on");
            return RedirectToAction("index", "home");
        }
        public ActionResult LogOut()
        {
            WebUser.LogOff();
            return RedirectToAction("index", "home");

        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(string userName, string pw1,DateTime dataBird,string email)
        {
         
       
            WebUser.Register(userName, pw1, dataBird,email);
            return RedirectToAction("index", "home");
          
        }
        
        public ActionResult Confrimed()
        {
            return View();
        }
    }
}