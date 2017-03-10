using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using DataModel.Models;
using IServices.Sublntefac.Public;
using IServices.Models.Post;
using System.Web;

/// <summary>
/// Функционал сайта.
/// </summary>
namespace Services
{
    /// <summary>
    /// Реализует методы необходимые для отображения постов
    /// </summary>
    public class PostServices : IPostServices
    {
        /// <summary>
        /// Выводит пост с информацией "Preview"
        /// </summary>
        /// <returns></returns>
        public List<ModelPostPreview> PostPreview()
        {
            using (var db = new DataContext())
            {
                var posts = db.Posts.Select(Preview()).ToList();
             
                return posts;
            }
        }
      
        /// <summary>
        /// Выводит пост с информацией "Детальней"
        /// </summary>
        /// <returns></returns>
        public List<ModelPost> PostDetails()
        {
            using (var db = new DataContext())
            {
                var products = db.Posts.Select(Details()).ToList();
                return products;
            }
        }




        /// <summary>
        /// Вывод всех категорий
        /// </summary>
        /// <returns>Модель Категории.</returns>
        public ModelCategories GetCategory()
        {
            using (var db = new DataContext())
            {
                var categories = db.Categories.ToList();
                return new ModelCategories { Categories = categories.Select(c => ConverModelCategory(c)).ToList() };
            }
        }
        /// <summary>
        /// Вывод всех категорий
        /// </summary>
        /// <returns></returns>
        public static List<Category> GetCategories()
        {
            using (var db = new DataContext())
            {
                var categories = db.Categories.Where(_ => !_.ParentId.HasValue).Include(_ => _.Child).ToList();
                return categories;
            }
        }
       
        /// <summary>
        /// Ставил лайк
        /// </summary>
        /// <param name="PostId">ИД поста</param>
        /// <param name="UserID">ИД пользователя</param>
        public void GetLike(int PostId , int UserID)
        {
            using(var db = new DataContext())
            {
                
                var post = db.Posts.FirstOrDefault(x => x.PostID == PostId);
                var like = ConvertLike(PostId, UserID);
               var UserLikePost = db.PostLikes.FirstOrDefault(x => x.UserID == UserID && x.PostID == PostId);
                if (UserLikePost != null)
                {
                    post.CountLike--;
                    db.PostLikes.Remove(UserLikePost);
                    db.SaveChanges();
                }
                else
                {
                    db.PostLikes.Add(like);
                    post.CountLike++;
                    db.SaveChanges();
                }
            }
        }
        /// <summary>
        /// Добовляет просмотр к посту
        /// </summary>
        /// <param name="PostID">Номер поста</param>
        public void GetView(int PostID)
        {
            using (var db = new DataContext())
            {
                ModelViews View = new ModelViews();
                View.PostID = PostID;
                HttpCookie CookieReq = HttpContext.Current.Request.Cookies["PostViews"];
                if (CookieReq == null)
                {
                    HttpCookie ViewsCookie = new HttpCookie("PostViews");
                    if (ViewsCookie == null || string.IsNullOrWhiteSpace(ViewsCookie.Value))
                    {
                        View.id = Guid.NewGuid();
                        var NewView = ConvertViewsModel(View);
                        db.PostViews.Add(NewView);
                        var post = db.Posts.FirstOrDefault(x => x.PostID == PostID);
                        db.SaveChanges();
                        ViewsCookie.Expires.AddDays(1);
                        ViewsCookie.Value = View.id.ToString();
                        HttpContext.Current.Response.Cookies.Add(ViewsCookie);
                    }
                }
                else
                {
                    Guid Value = Guid.Parse(CookieReq.Value);
                    if (db.PostViews.FirstOrDefault(x => x.id == Value && x.PostID == View.PostID) == null)
                    {
                        View.id = Value;
                        var NewView = ConvertViewsModel(View);
                        db.PostViews.Add(NewView);
                        var post = db.Posts.FirstOrDefault(x => x.PostID == PostID);
                        db.SaveChanges();
                    }

                }

            }
        }
       
        #region Конверт модели
        /// <summary>
        /// Конвертирует в модель PostLike
        /// </summary>
        /// <param name="PostId">Ид поста</param>
        /// <param name="UserId">Ид пользователя</param>
        /// <returns></returns>
        private static PostLike ConvertLike(int PostId, int UserId )
        {
            return new PostLike
            {
               PostID = PostId,
               UserID = UserId
            };
        }
        /// <summary>
        /// Конвертирует модель в PostViews
        /// </summary>
        /// <param name="View">Модель ModelViews</param>
        /// <returns></returns>
        private static PostViews ConvertViewsModel(ModelViews View)
        {
            return new PostViews
            {
                id = View.id,
                PostID = View.PostID,
               
            };
        }
        /// <summary>
        /// Конвертирует из ModelCategory в Category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        private static ModelCategory ConverModelCategory(Category category)
        {

            return new ModelCategory
            {
                Id = category.Id,
                Name = category.Name,
                ParentId = category.ParentId,

            };
        }

        /// <summary>
        /// Перезапись модели Post  из модели ModelPostPreview
        /// </summary>
        /// <returns></returns>
        public static Expression<Func<Post, ModelPostPreview>> Preview()
        {
            return post => new ModelPostPreview()
            {
                PostID = post.PostID,
                NamePost = post.NamePost,
                upload = post.upload,
                CategoryId = post.SelectCategories.Id,
                dateAddPost = post.dateAddPost,
                Tags = post.Tags,
                contentPost = post.contentPost,
                Author = post.Author,
                Description = post.Description
            };
        }


        /// <summary>
        /// Перезапись модели Post из ModelPost
        /// </summary>
        /// <returns></returns>
        public static Expression<Func<Post, ModelPost>> Details()
        {

            return post => new ModelPost()
            {

                PostID = post.PostID,
                NamePost = post.NamePost,
                upload = post.upload,
                CategoryId = post.SelectCategories.Id,
                dateAddPost = post.dateAddPost,
                Tags = post.Tags,
                contentPost = post.contentPost,
                Author = post.Author,
                Description = post.Description,
                CountLike = post.CountLike,
                CountViews = post.CountViews

            };
        }
        #endregion

    }
}
