using Blog.Infrastructura;
using IServices.Models.Post;
using Services.Exextension;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Areas.Admin.Controllers
{
    public class AdminController : BaseController
    {
        // GET: Admin/Home
        /// <summary>
        /// Главная страница админки
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        #region Управления постами
        /// <summary>
        /// Страница с добавлением нового поста
        /// </summary>
        /// <returns></returns>
        public ActionResult NewPost()
        {
            return View();
        }
        /// <summary>
        /// Добавление поста
        /// </summary>
        /// <param name="model">Модель поста</param>
        /// <param name="IdCategory">Ид категории</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult NewPost(ModelNewPost model, int IdCategory, HttpPostedFileBase Upload)
        {
            string map = Server.MapPath("~/img/");
            AdminServices.ControlPosts.Image(Upload, map, model);
            AdminServices.ControlPosts.AddPost(model, IdCategory);
            return RedirectToAction("Posts");
        }
        /// <summary>
        /// Создает перемнную в которой находится путь для сохранения файла и далее выполняет метод сохраняющий изображения 
        /// </summary>
        /// <param name="Upload">Файл</param>
        /// <param name="CKEditorFuncNum">Идентификационный номер анонимного функции обратного вызова после загрузки</param>
        /// <returns></returns>
        public ActionResult AddImage(HttpPostedFileBase Upload, string CKEditorFuncNum,ModelNewPost model)
        {
            string map = Server.MapPath("~/img/");
            string output = AdminServices.ControlPosts.ProcessRequest(Upload, CKEditorFuncNum, map,model);
            return Content(output);
        }
        /// <summary>
        /// Страница с управлением постами
        /// </summary>
        /// <returns></returns>
        public ActionResult Posts()
        {

            return View();
        }
        /// <summary>
        /// Удаление постов
        /// </summary>
        /// <param name="id">Список выбраных постов</param>
        /// <returns></returns>
        public ActionResult DeletePosts()
        {
            string map = Server.MapPath("~/img/");
            var list = Request.Form["list"].Split(',').Select(Int32.Parse).ToList();
            AdminServices.ControlPosts.DeletePosts(list,map);
            return Json("Пост успешно удален");
        }
        public ActionResult EditPost(int id)
        {
          var model =  AdminServices.ControlPosts.GetEditPost(id);
            return View(model);
        }
        /// <summary>
        /// Редактирование поста
        /// </summary>
        /// <param name="model">Модель поста</param>
        /// <param name="IdCategory">ID категории</param>
        /// <param name="Upload">Изображение для Preview</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditPost (ModelNewPost model , int IdCategory, HttpPostedFileBase Upload)
        {
            string map = Server.MapPath("~/img/");
            AdminServices.ControlPosts.Image(Upload, map, model);
            AdminServices.ControlPosts.EditPost(model, IdCategory);
            return RedirectToAction("Posts");

        }
        public ActionResult upPosts()
        {
            var posts = Services.Post.PostPreview();
            return View(posts);
        }
#endregion
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
        public ActionResult upUsers()
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
        #region Страница с категориями
        /// <summary>
        /// Страница с категориями 
        /// </summary>
        /// <returns></returns>
        public ActionResult Categories()
        {
            return View();
        }
        /// <summary>
        /// Добавление родительской категории
        /// </summary>
        /// <param name="name">Название категории</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddMainCategory(string name)
        {
            AdminServices.Categories.AddCategory(name);
            return Json("Запрос успешно выполнен");
        }
        /// <summary>
        /// Добавление дочерний категории
        /// </summary>
        /// <param name="namePareantCategory">Имя родительской категории</param>
        /// <param name="nameChild">Название новой дочерний категории</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult addChildCategory(string namePareantCategory, string nameChild)
        {
            AdminServices.Categories.addChildCategory(namePareantCategory, nameChild);
            return Json("Запрос успешно выполнен");
        }
        /// <summary>
        /// Удаление родительской категории
        /// </summary>
        /// <param name="name">Имя родительской категории</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DeletePareant(string name)
        {
            AdminServices.Categories.DeletePareant(name);
            return Json("Запрос успешно выполнен");
        }
        /// <summary>
        /// Удаляет дочернию категорию
        /// </summary>
        /// <param name="NamePareant">Имя родительской категории</param>
        /// <param name="NameChild">Имя дочерний категории</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DeleteChild(string NamePareant, string NameChild)
        {
            AdminServices.Categories.DeleteChild(NamePareant, NameChild);
            return Json("Запрос успешно выполнен");
        }
        /// <summary>
        /// Изменяет название выбранной категории
        /// </summary>
        /// <param name="namePareant">Выбраная родительская категория</param>
        /// <param name="newName">Новое название категории</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ChangeNamePareant(string namePareant, string newName)
        {
            AdminServices.Categories.ChangeNamePareant(namePareant, newName);
            return Json("Запрос успешно выполнен");
        }
        [HttpPost]
        public ActionResult ChangeNameChild(string namePareant, string childName, string newName)
        {
            AdminServices.Categories.ChangeNameChild(namePareant, childName, newName);
            return Json("Запрос успешно выполнен");
        }


        public ActionResult upCategories()
        {

            return View();
        }
  
        public ActionResult SelectCategory()
        {
            var model = Services.Post.GetCategory();
            return View(model);
        }
        #endregion



    }


}