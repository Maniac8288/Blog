using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

/// <summary>
/// Контролеры админки.
/// </summary>
namespace Blog.Areas.Admin.Controllers
{
    /// <summary>
    /// Контролер отвечающий за управлением категории.
    /// </summary>
    /// <seealso cref="Blog.Areas.Admin.Controllers.BaseController" />
    public class CategoriesController : BaseController
    {

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

        /// <summary>
        /// Ajax обновление категорий.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult AjaxCategories()
        {

            return View();
        }
        /// <summary>
        /// Вывод категорий.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult SelectCategory()
        {
            var model = Services.Post.GetCategory();
            return View(model);
        }
        #endregion
    }
}