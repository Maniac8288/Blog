using Blog.Infrastructura;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Areas.Admin.Controllers
{
    /// <summary>
    /// Управление комментариями
    /// </summary>
    public class CommentController : BaseController
    {
        /// <summary>
        /// Страница с управлением комментариев
        /// </summary>
        /// <returns></returns>
        [FilterUser(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Обновление Ajax запросом таблицы комментариев
        /// </summary>
        /// <returns></returns>
        public ActionResult AjaxComment(string user)
        {
            var comment = AdminServices.Comments.GetComments(user);
            return View(comment);
        }
        /// <summary>
        /// Удаление коментария
        /// </summary>
        /// <param name="id">Ид комментария</param>
        /// <param name="PareantId">Ид родительского комментария</param>
        /// <returns></returns>
        public ActionResult DeleteComment(int id,int? PareantId)
        {
            AdminServices.Comments.DeleteComment(id,PareantId);
            return Json("Комментарий удален");
        }
        /// <summary>
        /// Редактирование комментария
        /// </summary>
        /// <param name="id">Ид комментария</param>
        /// <param name="content">Содержимое комментария</param>
        /// <returns></returns>
        public ActionResult EditComment(int id,string content)
        {
            AdminServices.Comments.EditComment(id, content);
            return Json("Комментарий успешно отредактирован");
        }
        public ActionResult AutocompleteSearch(string term)
        {
                var model = AdminServices.Comments.Search(term);
                var models = model.Select(x => new { value = x.UserName }).Distinct().ToList();
                return Json(models, JsonRequestBehavior.AllowGet);
            
        }
    }
}
