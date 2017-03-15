using Blog.Infrastructura;
using IServices.Models.Post;
using Services.Exextension;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

/// <summary>
/// Контролеры админки.
/// </summary>
namespace Blog.Areas.Admin.Controllers
{
    /// <summary>
    /// Контролер главной части админки.
    /// </summary>
    /// <seealso cref="Blog.Areas.Admin.Controllers.BaseController" />
    public class DashboardController : BaseController
    {
        // GET: Admin/Home
        /// <summary>
        /// Главная страница админки
        /// </summary>
        /// <returns></returns>
        [FilterUser(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Информация о количестве просмотров
        /// </summary>
        /// <returns></returns>
        public ActionResult Viwes()
        {
            int count = AdminServices.ControlPosts.CountViews();
            return View(count);
        }
        /// <summary>
        /// Информация о количестве лайков
        /// </summary>
        /// <returns></returns>
        public ActionResult Likes()
        {
            int count = AdminServices.ControlPosts.CountLike();
            return View(count);
        }
        /// <summary>
        /// Информация о количестве постов
        /// </summary>
        /// <returns></returns>
        public ActionResult CountPosts()
        {
            int count = AdminServices.ControlPosts.CountPosts();
            return View(count);
        }
        /// <summary>
        /// Информация о количестве пользователей
        /// </summary>
        /// <returns></returns>
        public ActionResult CountsUsers()
        {
            int count = AdminServices.ControlPosts.CountUsers();
            return View(count);
        }
        /// <summary>
        /// Информация о количестве комментарий
        /// </summary>
        /// <returns></returns>
        public ActionResult CountsComments()
        {
            int count = AdminServices.ControlPosts.CountComments();
            return View(count);
        }
    }


}