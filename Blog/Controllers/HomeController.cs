using Blog.Infrastructura;
using PostModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View(db.Posts.OrderByDescending(x => x.dateAddPost));
        }

       public ActionResult News()
        {
            return View();
        }
        public ActionResult Paper()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        [FilterUser(Roles ="User")]
        public ActionResult Cabinet()
        {
            return View();
        }
        public ActionResult Tag(string tags)
        {
            if(tags == null)
            {
                return HttpNotFound();
            }
            return View(db.Posts.Where(x=>x.Tags.Contains(tags)));
        }
        public ActionResult Category(string category)
        {
            return View(db.Posts.Where(x => x.selectedCategory == category));
        }
        public ActionResult Post(int? id)
        {
            if (db.Posts.Find(id) == null)
            {
                return HttpNotFound();
            }
            PostDataStorage.collectionsTags = PostDataStorage.Storage.TagsSplit(db.Posts.Find(id));
            return View(db.Posts.Find(id));
        }
    }
}