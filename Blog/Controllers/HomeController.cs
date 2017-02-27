using Blog.Infrastructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class HomeController : BaseController
    {
        /// <summary>
        /// Главная страница
        /// </summary>
        /// <returns>Вывод постов из БД отсоротированные по дате</returns>
        public ActionResult Index()
        {
            var posts = Services.Post.PostPreview();
            return View(posts);
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
        [FilterUser(Roles ="User")]
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
        //public ActionResult Category(string category)
        //{
        //    var posts = Services.Post.PostPreview();
        //    var Category = posts.Where(x => x.selectedCategory.Name == category);
        //    return View(Category);
        //}
        /// <summary>
        /// Страница с определенным постом
        /// </summary>
        /// <param name="id">ID поста</param>
        /// <returns>Вывод поста по определенному ID</returns>
        public ActionResult Post(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var posts = Services.Post.PostDetails();
            var post = posts.FirstOrDefault(x => x.PostID == id);
            if (post != null)
            {
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

    }
}