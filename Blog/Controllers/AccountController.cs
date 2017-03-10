using Blog.Infrastructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

/// <summary>
/// Контролеры сайта.
/// </summary>
namespace Blog.Controllers
{
    /// <summary>
    ///  Контролер отвечающий за автроризацию на сайте
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class AccountController : Controller
    {
      
        /// <summary>
        /// Страница с авторизацей 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// Пост страница с авторизацией, проверяет Логин и пароль в бд и сохраняет куки с состоянием авторизации 
        /// </summary>
        /// <param name="userName">Логин пользователя</param>
        /// <param name="password">Пароль пользователя </param>
        /// <param name="RememberMe">Сохранить куки</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(string userName, string password, string RememberMe)
        {

            WebUser.Login(userName, password, RememberMe == "on");
            return RedirectToAction("index", "home");
        }
        /// <summary>
        /// Удаляет сессию и куки о состояние пользователя
        /// </summary>
        /// <returns></returns>
        public ActionResult LogOut()
        {
            WebUser.LogOff();
            return RedirectToAction("index", "home");

        }
        /// <summary>
        /// Страница с регистрацией 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        /// <summary>
        ///  Создает нового пользователя в БД и отправляет писмо на почту пользователя
        /// </summary>
        /// <param name="userName">Логин пользователя</param>
        /// <param name="pw1">Пароль пользователя</param>
        /// <param name="dataBird">Дата рождения пользователя</param>
        /// <param name="email">Почта пользователя</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Register(string userName, string pw1,DateTime dataBird,string email)
        {
          var check =  WebUser.CheckExistUser(userName, email);
            if (check == false)
            {
                var salt = WebUser.Register(userName, pw1, dataBird, email);
                WebUser.SendMail("Подтвердите регистрацию", email,
                    $@"Для завершения регистрации перейдите по 
                 <a href='{Url.Action("Confrimed", "Account", new { salt = salt, userName = userName }, Request.Url.Scheme)}'
                 title='Подтвердить регистрацию'>ссылке</a>");
                return RedirectToAction("login");
            }

            else
            {
                ViewData["Message"] = "Пользователь с данным логином или почтой уже существует";
                return View(); }
        }
        /// <summary>
        /// Потверждение почты пользователя
        /// </summary>
        /// <param name="salt">Соль</param>
        /// <param name="userName">Логин пользователя</param>
        /// <returns></returns>
        public ActionResult Confrimed(string salt,string userName)
        {
            if (salt != null)
            {
                WebUser.Confirmed(salt,userName);
                return RedirectToAction("index", "home");
            }
            return View("Error");
        }
        /// <summary>
        /// Страница с востоновлением пароля
        /// </summary>
        /// <returns></returns>
        public ActionResult ForgotPassword()
        {
            return View();
        }
        /// <summary>
        /// Отправляет письмо на почту пользователя
        /// </summary>
        /// <param name="email">Почта пользователя</param>
        /// <returns>Возвращает на главную страницу</returns>
        [HttpPost]
        public ActionResult ForgotPassword(string email)
        {
            WebUser.SendMail("Востоновления пароля", email,
                $@"Для восстановления  пароля перейдите по 
                 <a href='{Url.Action("NewPassword", "Account", new {  email = email }, Request.Url.Scheme)}'
                 title='Подтвердить регистрацию'>ссылке</a>");

            return RedirectToAction("index", "home");
        }
        /// <summary>
        /// Страница для указание нового пароля
        /// </summary>
        /// <returns></returns>
        public ActionResult NewPassword()
        {
            return View();
        }
        /// <summary>
        /// Заменяет старый пароль в БД на новый
        /// </summary>
        /// <param name="email">Почта пользователя</param>
        /// <param name="password">Новый пароль пользователя</param>
        /// <returns>Возвращает на страницу с авторизацией</returns>
        [HttpPost]
        public ActionResult NewPassword(string email, string password)
        {
            WebUser.ForgotPW(email, password);
            return RedirectToAction("login");
        }
    }
}