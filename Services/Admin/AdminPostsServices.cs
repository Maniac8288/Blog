using DataModel;
using DataModel.Models;
using IServices.Models.Post;
using IServices.Sublntefac.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.IO;
using System.Web;

namespace Services.Admin
{
    /// <summary>
    /// Управление постами
    /// </summary>
    public class AdminPostsServices : IAdminPostsServices
    {
        /// <summary>
        /// Удаление выбраных постов
        /// </summary>
        /// <param name="id">Выбраные посты</param>
        public void DeletePosts(List<int> id)
        {
            using (var db = new DataContext())
            {
                foreach (int item in id)
                {
                    var posts = db.Posts.FirstOrDefault(_ => _.PostID == item);
                    db.Posts.Remove(posts);
                }
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Добавление  нового поста
        /// </summary>
        /// <param name="model">Модель поста</param>
        /// <param name="IdCategory">Ид категории</param>
        public void AddPost(ModelPost model, int? IdCategory)
        {
            using (var db = new DataContext())
            {
                var category = db.Categories.FirstOrDefault(x => x.Id == IdCategory);
                var posts = ConverModelPost(model);
                posts.SelectCategories = category;
                db.Posts.Add(posts);
                db.SaveChanges();
                
            }
        }
        /// <summary>
        /// Добавление изображения
        /// </summary>
        /// <param name="model">Модель поста</param>
        /// <param name="Upload">Изображение</param>
        public void AddImage(ModelPost model,HttpPostedFileBase Upload)
        {
            //if (Upload != null)
            //{ 
            //    // получаем имя файла
            //    string fileName = System.IO.Path.GetFileName(Upload.FileName);
            //    // сохраняем файл в папку img в проекте
            //    System.IO.Directory.CreateDirectory(Server.MapPath("~/img/") + model.PostID);
            //    Upload.SaveAs(Server.MapPath("~/img/" + model.PostID + "/" + fileName));
            //}
        }
        public ModelPost EditPost (int id)
        {
            using (var db = new DataContext())
            {
                
                var post = db.Posts.FirstOrDefault(_ => _.PostID == id);
                return ConverPost(post);
            }
        }
        /// <summary>
        /// Конвертирует модель ModelPost  в Post
        /// </summary>
        /// <param name="posts"></param>
        /// <returns></returns>
        private static Post ConverModelPost(ModelPost posts)
        {
            return new Post
            {
                PostID = posts.PostID,
                Author = posts.Author,
                dateAddPost = posts.dateAddPost,
                contentPost = posts.contentPost,
                NamePost = posts.NamePost,
                Tags = posts.Tags,
                upload = posts.upload,

            };
        }
        /// <summary>
        /// Конвертирует модель Post в ModelPost
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        private static ModelPost ConverPost(Post post)
        {
            return new ModelPost
            {
                PostID = post.PostID,
                Author = post.Author,
                dateAddPost = post.dateAddPost,
                contentPost = post.contentPost,
                NamePost = post.NamePost,
                Tags = post.Tags
                

            };
        }
    }
}
