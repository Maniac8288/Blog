﻿using Blog.Infrastructura;
using IServices.Models.Post;
using IServices.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

/// <summary>
/// Контролеры Админки
/// </summary>
namespace Blog.Areas.Admin.Controllers
{
    /// <summary>
    /// Контролер отвечающий за управленние постами
    /// </summary>
    /// <seealso cref="Blog.Areas.Admin.Controllers.BaseController" />
    public class PostsController : BaseController
    {
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
        public ActionResult NewPost(ModelNewPost model, int IdCategory, HttpPostedFileBase Upload, int User)
        {
            string map = Server.MapPath("~/img/");
            AdminServices.ControlPosts.Image(Upload, map, model);
            AdminServices.ControlPosts.AddPost(model, IdCategory,User);
            return RedirectToAction("Index");
        }
        /// <summary>
        /// Создает перемнную в которой находится путь для сохранения файла и далее выполняет метод сохраняющий изображения 
        /// </summary>
        /// <param name="Upload">Файл</param>
        /// <param name="CKEditorFuncNum">Идентификационный номер анонимного функции обратного вызова после загрузки</param>
        /// <returns></returns>
        public ActionResult AddImage(HttpPostedFileBase Upload, string CKEditorFuncNum, ModelNewPost model)
        {
            string map = Server.MapPath("~/img/");
            string output = AdminServices.ControlPosts.ProcessRequest(Upload, CKEditorFuncNum, map, model);
            return Content(output);
        }
        /// <summary>
        /// Страница с управлением постами
        /// </summary>
        /// <returns></returns>
        [FilterUser(Roles = "Admin")]
        public ActionResult Index()
        {

            return View();
        }
        /// <summary>
        /// Удаление постов
        /// </summary>
        /// <param name="id">Список выбраных постов</param>
        /// <returns></returns>
        public ActionResult DeletePosts(int id)
        {
            string map = Server.MapPath("~/img/");
         
            AdminServices.ControlPosts.DeletePosts(id, map);
            return Json("Пост успешно удален");
        }
        /// <summary>
        /// Редактирование поста.
        /// </summary>
        /// <param name="id">ИД поста.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult EditPost(int id)
        {
            var model = AdminServices.ControlPosts.GetEditPost(id);
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
        public ActionResult EditPost(ModelNewPost model, int IdCategory, HttpPostedFileBase Upload)
        {
            string map = Server.MapPath("~/img/");
            AdminServices.ControlPosts.Image(Upload, map, model);
            AdminServices.ControlPosts.EditPost(model, IdCategory);
            return RedirectToAction("Index");

        }
        /// <summary>
        /// Ajaxes обновление страницы.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult AjaxPosts()
        {
            var posts = AdminServices.ControlPosts.PostPreview();
            return View(posts);
        }
        public ActionResult AutocompleteSearch(string term)
        {
            var model = AdminServices.Comments.Search(term);
            var models = model.Select(x => new { value = x.UserName }).Distinct().ToList();
            return Json(models, JsonRequestBehavior.AllowGet);

        }
        #endregion
    }
}