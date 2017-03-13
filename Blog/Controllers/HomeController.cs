using Blog.Infrastructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

/// <summary>
/// Контролеры сайта.
/// </summary>
namespace Blog.Controllers
{
    /// <summary>
    /// Контролер для основной части сайта
    /// </summary>
    /// <seealso cref="Blog.Controllers.BaseController" />
    public class HomeController : BaseController
    {
        /// <summary>
        /// Главная страница
        /// </summary>
        /// <returns>Вывод постов из БД отсоротированные по дате</returns>
        public ActionResult Index()
        {
            var posts = Services.Post.PostPreview();
            return View(posts.OrderByDescending(x => x.dateAddPost));
        }
        /// <summary>
        /// Страница с новостями
        /// </summary>
        /// <returns></returns>
       public ActionResult News()
        {
            return View();
        }
        /// <summary>
        /// Страница с контактами
        /// </summary>
        /// <returns></returns>
        
        public ActionResult Contact()
        {
            return View();
        }
        /// <summary>
        /// Страница с личным кабинетам , с доступом "Пользователи"
        /// </summary>
        /// <returns></returns>
        [FilterUser(Roles ="Admin")]
        public ActionResult Cabinet()
        {
            return View();
        }
        /// <summary>
        /// Страница с постами по выбранному тэгу
        /// </summary>
        /// <param name="tags">Тэг по которому идет поиск</param>
        /// <returns>Список постов из БД по выбранному тэгу</returns>
        public ActionResult Tag(string tags)
        {
            if(tags == null)
            {
                return HttpNotFound();
            }
            var posts = Services.Post.PostPreview();
            var tag = posts.Where(x => x.Tags.Contains(tags));
            return View(tag);
        }
        /// <summary>
        /// Страница с постами по выбранной категории
        /// </summary>
        /// <param name="category"></param>
        /// <returns>Вывод постов из БД по выбранной категории</returns>
        public ActionResult Category(int category)
        {
            var posts = Services.Post.PostPreview().Where(x=>x.CategoryId == category);
           
            return View(posts);
        }
        /// <summary>
        /// Страница с определенным постом
        /// </summary>
        /// <param name="id">ID поста</param>
        /// <returns>Вывод поста по определенному ID</returns>
        public ActionResult Post(int id)
        {
            
            var posts = Services.Post.PostDetails();
            var post = posts.FirstOrDefault(x => x.PostID == id);
            if (post != null)
            {
                Services.Post.GetView(id);


                return View(post);
            }
            return View("Error");
        }
        /// <summary>
        /// Вывод древо категорий
        /// </summary>
        /// <returns></returns>
        public ActionResult Categories()
        {

            var model = Services.Post.GetCategory();
            return View(model);


        }
        /// <summary>
        /// Последние посты
        /// </summary>
        /// <returns>Вывод последних постов отсортированных по дате</returns>
        public ActionResult Popular()
        {
            var posts = Services.Post.PostPopular();
            return View(posts.OrderByDescending(x => x.CountViews).Take(4));
        }
        public ActionResult SideBar()
        {
            var posts = Services.Post.PostPreview();
            return View(posts.OrderByDescending(x => x.dateAddPost));

        }
        /// <summary>
        /// Ставит лайк над постом.
        /// </summary>
        /// <param name="PostID">Индифиактор поста.</param>
        /// <param name="UserID">Индификатор пользователя.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public ActionResult GetLike(int PostID, int UserID)
        {
            Services.Post.GetLike(PostID, UserID);
            return Json("Запрос успешно выполнен");
        }
    
    }
}