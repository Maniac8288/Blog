﻿using IServices.Models.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Areas.Admin.Controllers
{
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
            AdminServices.ControlPosts.DeletePosts(list, map);
            return Json("Пост успешно удален");
        }
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
            return RedirectToAction("Posts");

        }
        public ActionResult AjaxPosts()
        {
            var posts = Services.Post.PostPreview();
            return View(posts);
        }
        #endregion
    }
}