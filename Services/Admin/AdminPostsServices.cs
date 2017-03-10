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

/// <summary>
/// Функционал админки
/// </summary>
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
        /// <param name="mapPath">Расположение к папке с постом</param>
        public void DeletePosts(List<int> id, string mapPath)
        {
            using (var db = new DataContext())
            {
                foreach (int item in id)
                {
                    var posts = db.Posts.FirstOrDefault(_ => _.PostID == item);
                    string dir = mapPath + posts.PostID;
                    if (System.IO.Directory.Exists(dir))
                    {
                        System.IO.Directory.Delete(dir, true);
                    }
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
        public void AddPost(ModelNewPost model, int IdCategory)
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
        /// Возвращает нужуню модель поста для редактирования 
        /// </summary>
        /// <param name="id">Ид категории</param>
        /// <returns></returns>   
        public ModelPost GetEditPost(int id)
        {
            using (var db = new DataContext())
            {
                var post = db.Posts.FirstOrDefault(_ => _.PostID == id);
                return ConverPost(post);
            }
        }
        /// <summary>
        /// Редактирование поста
        /// </summary>
        /// <param name="model">Моедль поста</param>
        /// <param name="IdCategory">ID категории</param>
        public void EditPost(ModelNewPost model, int IdCategory)
        {
            using (var db = new DataContext())
            {
                var category = db.Categories.FirstOrDefault(x => x.Id == IdCategory);
                var post = db.Posts.FirstOrDefault(x => x.PostID == model.PostID);
                post.NamePost = model.NamePost;
                post.SelectCategories = category;
                post.Description = model.Description;
                post.Tags = model.Tags;
                post.dateAddPost = model.dateAddPost;
                post.contentPost = model.contentPost;
                post.upload = model.upload;
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Конвертирует модель ModelPost  в Post
        /// </summary>
        /// <param name="posts"></param>
        /// <returns></returns>
        private static Post ConverModelPost(ModelNewPost posts)
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
                Description = posts.Description

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
                Tags = post.Tags,
                Description = post.Description
            };
        }
        /// <summary>
        /// Добавление изображения в Priveiw
        /// </summary>
        /// <param name="upload">Изображение</param>
        /// <param name="mapPath">Путь</param>
        /// <param name="model">Модель поста</param>
        public void Image(HttpPostedFileBase upload, string mapPath, ModelNewPost model)
        {
            if (upload != null)
            {
                using (var db = new DataContext())
                {
                    var post = db.Posts.FirstOrDefault(x => x.PostID == model.PostID);
                    if (post == null)
                    {
                        var postID = db.Posts.Max(x => x.PostID);
                        postID++;
                        string dir = mapPath + postID;
                        if (!Directory.Exists(dir + "/" + "Preview"))
                        {
                            Directory.CreateDirectory(dir + "/" + "Preview");
                        }
                        string newFileName = Path.GetFileName(upload.FileName);
                        var newPatch = Path.Combine(mapPath + "/" + postID + "/" + "Preview", newFileName);
                        upload.SaveAs(newPatch);
                    }
                    else
                    {
                        string dir = mapPath + model.PostID;
                        if (!Directory.Exists(dir + "/" + "Preview"))
                        {
                            Directory.CreateDirectory(dir + "/" + "Preview");
                        }
                        string fileName = Path.GetFileName(upload.FileName);
                        var path = Path.Combine(mapPath + "/" + model.PostID + "/" + "Preview", fileName);
                        upload.SaveAs(path);
                    }
                }
            }
        }
        /// <summary>
        /// Загржает изображение на сервер и получает путь к файлу изображения
        /// </summary>
        /// <param name="upload">Изображения</param>
        /// <param name="CKEditorFuncNum">Идентификационный номер анонимного функции обратного вызова после загрузки</param>
        /// <param name="mapPath">Путь для сохранения файла</param>
        /// <returns>Возвращает строку с Ajax запросом</returns>
        public string ProcessRequest(HttpPostedFileBase upload, string CKEditorFuncNum, string mapPath, ModelNewPost model)
        {
            if (upload.ContentLength <= 0)
                return null;
            using (var db = new DataContext())
            {
                var NewPost = db.Posts.Max(x => x.PostID);
                NewPost++;
                const string uploadFolder = "img";
                // сохраняем файл в папку img в проекте
                Directory.CreateDirectory(mapPath + NewPost);
                var fileName = Path.GetFileName(upload.FileName);
                var path = Path.Combine(mapPath + "/" + NewPost, fileName);
                upload.SaveAs(path);
                var url = string.Format("{0}/{1}/{2}/{3}", "http://localhost:62712/", uploadFolder, NewPost, fileName);
                const string message = "Ваше изображение успешно сохраненно";
                // Ajax запрос для передачи изображение
                var output = string.Format(
                    "<html><body><script>window.parent.CKEDITOR.tools.callFunction({0}, \"{1}\", \"{2}\");</script></body></html>",
                    CKEditorFuncNum, url, message);
                return output;
            }
        }


    }
}
