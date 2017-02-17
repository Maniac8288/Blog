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


            string salt =  WebUser.Register(userName, pw1, dataBird,email);
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("testshop2018@gmail.com");
            msg.To.Add(email);
            msg.Subject = "2";
            msg.Body = string.Format("Для завершения регистрации перейдите по " +
                        "<a href=\"{0}\" title=\"Подтвердить регистрацию\">ссылке</a>",
            Url.Action("Confrimed", "Account", new { salt = salt,userName =userName }, Request.Url.Scheme));
            msg.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Send(msg);
            return RedirectToAction("index", "home");
          
        }
        
        public ActionResult Confrimed(string salt,string userName)
        {
            if (salt != null)
            {
                WebUser.Confrimed(salt,userName);
                return RedirectToAction("index", "home");
            }
            return View("Error");
        }
    }
}