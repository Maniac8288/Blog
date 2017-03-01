using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using IServices.Models;
using System.Linq.Expressions;
using DataModel.Models;
using IServices.Sublntefac.Public;
using IServices.Models.Post;

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
                Description = post.Description
                
                
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
        

    }
}
