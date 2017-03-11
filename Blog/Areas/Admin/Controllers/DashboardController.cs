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
        public ActionResult Index()
        {
            return View();
        }



    }


}