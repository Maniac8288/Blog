using Blog.Infrastructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Areas.Admin.Controllers
{
    public class UsersController : BaseController
    {

        #region Страница с пользователями
        /// <summary>
        /// Страница с таблицей всех пользователй
        /// </summary>
        /// <returns></returns>
        public ActionResult Users()
        {

            var usres = AdminServices.Users.Users();
            return View(usres);
        }
        /// <summary>
        /// Удаляет выбраных пользователей с БД 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DeleteUsers()
        {
            var list = Request.Form["list"].Split(',').Select(Int32.Parse).ToList();
            AdminServices.Users.Delete(list);
            return Json("Запрос успешно выполнен");
        }
        /// <summary>
        /// Изменяет статус пользователя в БД на "Заблокированный"
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult BlockUsers()
        {
            var list = Request.Form["list"].Split(',').Select(Int32.Parse).ToList();
            AdminServices.Users.Block(list);
            return Json("Запрос успешно выполнен");
        }
        /// <summary>
        /// Вывод содержимое таблицы пользователей  
        /// </summary>
        /// <returns></returns>
        public ActionResult AjaxUsers()
        {
            var users = AdminServices.Users.Users();
            return View(users);
        }
        /// <summary>
        /// Регистрирует нового пользователя и отправляет ему писмо на почту с потверждением аккаунта
        /// </summary>
        /// <param name="userName">Логин пользователя</param>
        /// <param name="email">Почта пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <param name="dataBirth">Дата Рождения пользователя</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AddUser(string userName, string email, string password, DateTime dataBirth)
        {

            var salt = Services.Users.Register(userName, password, dataBirth, email);
            WebUser.SendMail("Подтвердите регистрацию", email,
                $@"Для завершения регистрации перейдите по 
                 <a href='{Url.Action("Confrimed", "Account", new { area = "", salt = salt, userName = userName }, Request.Url.Scheme)}'
                 title='Подтвердить регистрацию'>ссылке</a>");
            return Json("Запрос успешно выполнен");
        }
        /// <summary>
        /// Назначение роли пользователю
        /// </summary>
        /// <param name="role">Выбранная роль</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult roleUsers(string role)
        {
            var list = Request.Form["list"].Split(',').Select(Int32.Parse).ToList();
            AdminServices.Users.roleUsers(list, role);
            return Json("Запрос успешно выполнен");
        }
        #endregion
    }
}