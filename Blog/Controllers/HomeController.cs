using Blog.Infrastructura;
using DataModel.Models;
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
            return View(db.Posts.OrderByDescending(x => x.dateAddPost));
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
            return View(db.Posts.Where(x=>x.Tags.Contains(tags)));
        }
        /// <summary>
        /// Страница с постами по выбранной категории
        /// </summary>
        /// <param name="category"></param>
        /// <returns>Вывод постов из БД по выбранной категории</returns>
        public ActionResult Category(string category)
        {
            return View(db.Posts.Where(x => x.selectedCategory == category));
        }
        /// <summary>
        /// Страница с определенным постом
        /// </summary>
        /// <param name="id">ID поста</param>
        /// <returns>Вывод поста по определенному ID</returns>
        public ActionResult Post(int? id)
        {
            if (db.Posts.Find(id) == null)
            {
                return HttpNotFound();
            }
            PostDataStorage.collectionsTags = PostDataStorage.Storage.TagsSplit(db.Posts.Find(id));
            return View(db.Posts.Find(id));
        }
        /// <summary>
        /// Страница добовления поста на сайт
        /// </summary>
        /// <returns>Новый объект модели</returns>
        [HttpGet]
        public ActionResult AddPost()
        {

            return View();
        }
        /// <summary>
        /// Добовление поста в коллекцию
        /// </summary>
        /// <param name="model">Модель поста</param>
        /// <param name="upload">Добавление картинки</param>
        /// <returns></returns>

        [HttpPost]
        public ActionResult AddPost(Post model, HttpPostedFileBase upload)
        {


            if (upload != null)
            {
                // получаем имя файла
                string fileName = System.IO.Path.GetFileName(upload.FileName);
                model.upload = fileName;
                // сохраняем файл в папку img в проекте
                //System.IO.Directory.CreateDirectory(Server.MapPath("~/img/") + model.PostID);
                upload.SaveAs(Server.MapPath("~/img/"  + "/" + fileName));



            }
            db.Posts.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult TestImage()
        {
            return View();
        }
    }
}