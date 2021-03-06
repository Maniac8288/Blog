﻿using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using DataModel.Models;
using IServices.Sublntefac.Public;
using IServices.Models.Post;
using System.Web;
using IServices.Models.User;

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
                var postCollection = db.Posts.Select(Preview()).ToList();
                var posts = new List<ModelPostPreview>();
                foreach (var post in postCollection)
                {
                    post.Category = GetCategoryByID(post.CategoryId);
                    posts.Add(post);
                }

                return posts;
            }
        }
        /// <summary>
        /// Вывод популярных постов
        /// </summary>
        /// <returns></returns>
        public List<ModelPost> PostPopular()
        {
            using (var db = new DataContext())
            {
                var postCollection = db.Posts.Select(Details()).ToList();
                var posts = new List<ModelPost>();
                foreach (var post in postCollection)
                {
                    post.Category = GetCategoryByID(post.CategoryId);
                    posts.Add(post);
                }
                return posts;
            }
        }
        /// <summary>
        /// Вывод самых комментируемых постов
        /// </summary>
        /// <returns></returns>
        public List<ModelPost> MostCommented()
        {
            using (var db = new DataContext())
            {
                var postCollection = db.Posts.Select(Details()).ToList();
                
                var comment = postCollection.OrderByDescending(x => x.Comments.Count(c => c.Id == x.PostID)).ToList();
                return comment;
            }
        }
        /// <summary>
        /// Последние комментарии
        /// </summary>
        /// <returns></returns>
        public List<ModelComment> LatestComments()
        {
            using (var db = new DataContext())
            {
                var comments = db.Comments.Select(ConvertComment()).ToList();
                return comments.OrderByDescending(x=>x.Id).Take(3).ToList();
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
                var postCollection = db.Posts.Select(Details()).ToList();
                var posts = new List<ModelPost>();
                foreach (var post in postCollection)
                {
                    
                    post.Category = GetCategoryByID(post.CategoryId);
                    post.User = GetUserByID().Where(x=>x.Id==post.AuthorID).ToList();
                    posts.Add(post);
                    
                }
                
                return posts;
            }
        }
        /// <summary>
        /// Вывод облако тегов
        /// </summary>
        /// <returns></returns>
        public List<ModelTags> CloudTags()
        {
            using (var db = new DataContext())
            {
                var tags = db.Tags.Distinct().Take(10).Select(Tags()).ToList();
                return tags;


            }
        }
        /// <summary>
        /// Нахождение категории по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private static ModelCategory GetCategoryByID(int id)
        {
            using (var db = new DataContext())
            {
                var category = db.Categories.Select(ConverToModelCategory()).FirstOrDefault(x => x.Id == id);
                return category;
            }
        }
       /// <summary>
       /// Нахождение пользователя по ID
       /// </summary>
       /// <returns></returns>
        private static List<ModelUser> GetUserByID()
        {
            using (var db = new DataContext())
            {
                var user = db.Users.Select(ConvertToModelUser()).ToList();
                return user;
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
        /// Вывод комментарий
        /// </summary>
        /// <param name="PostID">Ид поста</param>
        /// <returns>List&lt;ModelComment&gt;.</returns>
        public List<ModelComment> Comment(int PostID)
        {
            using (var db = new DataContext())
            {

                var commentCollection = db.Comments.Where(x => x.Post.FirstOrDefault(c => c.PostID == PostID).PostID == PostID);
                var comment = commentCollection.Select(ConvertComment()).ToList();
                return comment;

            }
        }

        /// <summary>
        /// Ставил лайк
        /// </summary>
        /// <param name="PostId">ИД поста</param>
        /// <param name="UserID">ИД пользователя</param>
        public void GetLike(int PostId, int UserID)
        {
            using (var db = new DataContext())
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
                        post.CountViews++;
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
                        post.CountViews++;
                        db.SaveChanges();
                    }

                }

            }
        }
        /// <summary>
        /// Добавление комментария
        /// </summary>
        /// <param name="ContentComment">Содержимое комментария</param>
        /// <param name="UserId">ИД пользователя.</param>
        /// <param name="PostId">Ид поста</param>
        public void AddComent(ModelComment model, int UserId, int PostId, int? PareantId)
        {
            using (var db = new DataContext())
            {
                if (PareantId == null)
                {
                    var user = db.Users.FirstOrDefault(x => x.Id == UserId);
                    var post = db.Posts.FirstOrDefault(x => x.PostID == PostId);
                    var comment = db.Comments.Add(ConvertComment(model));
                    comment.DateAddComment = DateTime.Now;
                    comment.Post.Add(post);
                    comment.User.Add(user);
                    comment.Answer = true;
                    db.SaveChanges();
                }
                else
                {
                  
                    var user = db.Users.FirstOrDefault(x => x.Id == UserId);
                    var post = db.Posts.FirstOrDefault(x => x.PostID == PostId);
                    var Pareant = db.Comments.FirstOrDefault(x => x.Id == PareantId);
                    Pareant.Answer = false;
                    var comment = db.Comments.Add(ConvertComment(model));
                    comment.Child.Where(_ => _.PareantId == PareantId);
                    comment.PareantId = PareantId;
                    comment.DateAddComment = DateTime.Now;
                    comment.Post.Add(post);
                    comment.User.Add(user);
                    db.SaveChanges();
                }
            }
        }
     
    
        /// <summary>
        /// Подсчитывает количество комментарий данного поста
        /// </summary>
        /// <param name="PostId">Ид поста</param>
        /// <returns></returns>
        public int CountComment(int PostId)
        {
            using (var db = new DataContext())
            {
                var commentCollection = db.Comments.Where(x => x.Post.FirstOrDefault(c => c.PostID == PostId).PostID == PostId);
                return commentCollection.Count();
            }
        }

        /// <summary>
        /// Выполняет поиск постов
        /// </summary>
        /// <param name="term">Ввод</param>
        /// <returns></returns>
        public List<ModelPostPreview> Search(string term)
        {
            using (var db = new DataContext())
            {

                var post = db.Posts.Select(Preview());
                var models = post.Where(a => a.NamePost.Contains(term)).ToList();
                return models;
            }
        }
        #region Конверт модели
        public static Expression<Func<Comment, ModelComment>> ConvertComment()
        {


            return comment => new ModelComment()
            {
                Id = comment.Id,
                PareantId = comment.PareantId,
                ContentComment = comment.ContetntComment,
                DateAddPost = comment.DateAddComment,
                Answer = comment.Answer,
                User = comment.User.Select(u => new ModelUserComment { Id = u.Id, UserName = u.UserName, Photo = u.Photo }).ToList(),
              
            };
        }
        public static Expression<Func<User, ModelUserComment>> ConvertUsers()
        {
            return user => new ModelUserComment()
            {
               Id = user.Id,
               UserName = user.UserName,
               Photo = user.Photo
            };
        }
     

        /// <summary>
        /// Конвертирует в модель PostLike
        /// </summary>
        /// <param name="PostId">Ид поста</param>
        /// <param name="UserId">Ид пользователя</param>
        /// <returns></returns>
        private static PostLike ConvertLike(int PostId, int UserId)
        {
            return new PostLike
            {
                PostID = PostId,
                UserID = UserId
            };
        }
        private static Comment ConvertComment(ModelComment comment)
        {
            return new Comment
            {
                ContetntComment = comment.ContentComment,
                Answer = comment.Answer,
                DateAddComment= comment.DateAddPost,
                Child = new List<Comment> { },
                Post = new List<Post>{ },
                User = new List<User> { }
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
                AuthorID = post.AuthorID,
                Description = post.Description,
                CountLike = post.CountLike


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
                Description = post.Description,
                CountLike = post.CountLike,
                CountViews = post.CountViews,
                AuthorID = post.AuthorID,
                Comments = post.Comments.Select(u => new ModelComment { Id = u.Id, ContentComment = u.ContetntComment }).ToList()

                  



            };
        }
        public static Expression<Func<Tag, ModelTags>> Tags()
        {

            return tag => new ModelTags()
            {
                Id= tag.Id,
                NameTag = tag.NameTag
            };
        }
        public static Expression<Func<Category, ModelCategory>> ConverToModelCategory()
        {
            return category => new ModelCategory()
            {
                Id = category.Id,
                Name = category.Name,
                ParentId = category.ParentId,
            };
        }
        public static Expression<Func<User, ModelUser>> ConvertToModelUser()
        {
            return user => new ModelUser()
            {
                Id= user.Id,
                UserName=user.UserName,
                Email = user.Email
            };
        }




        #endregion

    }
}
