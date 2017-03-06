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
                selectedCategory = post.SelectCategories,
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
                selectedCategory = post.SelectCategories,
                dateAddPost = post.dateAddPost,
                Tags = post.Tags,
                contentPost = post.contentPost,
                Author = post.Author,
                Description = post.Description,
                CountLike= post.CountLike,
                CountViews = post.CountViews
                

                
                
            };
        }
        public static List<string> collectionsTags = new List<string>();
        public static List<string> TagsSplit(ModelPostPreview model)
        {
            return model.Tags.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

  
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
        /// Конвертирует из ModelCategory в Category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        private static ModelCategory ConverModelCategory(Category category)
        {

            return  new ModelCategory
            {
                Id = category.Id,
                Name = category.Name,
                ParentId = category.ParentId,
              
            };
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
        public void GetView(int PostID)
        {
            using (var db = new DataContext())
            {
                HttpCookie CookieReq = HttpContext.Current.Request.Cookies["Views"];
                if (CookieReq ==null)
                {
                    HttpCookie ViewsCookie = new HttpCookie("Views");
                  
                    if (ViewsCookie == null || string.IsNullOrWhiteSpace(ViewsCookie.Value))
                    {
                        ModelViews View = new ModelViews();
                        View.id = Guid.NewGuid();
                        View.PostID = PostID;
                        var NewView = ConvertViewsModel(View);
                        db.Views.Add(NewView);
                       var post = db.Posts.FirstOrDefault(x => x.PostID == PostID);
                        post.CountViews++;
                        db.SaveChanges();
                        ViewsCookie.Expires.AddDays(1);
                        ViewsCookie.Value = PostID.ToString();
                        HttpContext.Current.Response.Cookies.Add(ViewsCookie);

                    }

                }
              
            }
        }
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
        /// Конвертирует в модель "Views"
        /// </summary>
        /// <param name="PostId">Пост</param>
        /// <param name="id"></param>
        /// <returns></returns>
        private static Views ConvertViewsModel(ModelViews View)
        {
            return new Views
            {
                id = View.id,
                PostID = View.PostID,
               
            };
        }

    }
}
