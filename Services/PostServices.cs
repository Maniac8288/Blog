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

    public class PostServices : IPostServices
    {

        public List<ModelPostPreview> PostPreview()
        {
            using (var db = new DataContext())
            {
                var posts = db.Posts.Select(Preview()).ToList();
                return posts;
            }
        }

        public List<ModelPost> PostDetails()
        {
            using (var db = new DataContext())
            {
                var products = db.Posts.Select(Details()).ToList();
                return products;
            }
        }

        public static Expression<Func<Post, ModelPostPreview>> Preview()
        {
            return post => new ModelPostPreview()
            {
                PostID = post.PostID,
                NamePost = post.NamePost,
                upload = post.upload,
                selectedCategory = post.selectedCategory,
                dateAddPost = post.dateAddPost,
                Tags = post.Tags,
                contentPost = post.contentPost,
                Author = post.Author
            };
        }

        public static Expression<Func<Post, ModelPost>> Details()
        {
            return post => new ModelPost()
            {

                PostID = post.PostID,
                NamePost = post.NamePost,
                upload = post.upload,
                selectedCategory = post.selectedCategory,
                dateAddPost = post.dateAddPost,
                Tags = post.Tags,
                contentPost = post.contentPost,
                Author = post.Author
            };
        }
        public static List<string> collectionsTags = new List<string>();
        public static List<string> TagsSplit(ModelPostPreview model)
        {
            return model.Tags.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }
        public void AddCategory()
        {
            using (var db = new DataContext())
            {
                db.Categories.Add(new Category() { Name = "" });
                db.Categories.Add(new Category() { Name = "", ParentId = 1 });
                db.SaveChanges();
            }
        }

        public static List<Category>  GetCategory()
        {
            using (var db = new DataContext())
            {
              var  categories = db.Categories.Where(_ => !_.ParentId.HasValue).Include(_ => _.Сhild).ToList();
                return categories;
            }
        }


        public void UpdateCategory(int id)
        {
            using (var db = new DataContext())
            {
                var category = db.Categories.Include(_ => _.Сhild).FirstOrDefault(_ => _.Id == id);
                category.Сhild.Add(new Category() { Name = "sd1" });
                category.Сhild.Add(new Category() { Name = "sd2" });
                db.SaveChanges();

            }
        }

        public void UpdateCategoryParent(int parentId, string name)
        {
            using (var db = new DataContext())
            {
                db.Categories.Add(new Category() { Name = name, ParentId = parentId });
                db.SaveChanges();

            }
        }

        public void Update(int id, string name)
        {
            using (var db = new DataContext())
            {
                var category = db.Categories.FirstOrDefault(_ => _.Id == id);
                category.Name = name;
                db.SaveChanges();
            }

        }

        public void Update2(int id, string name)
        {
            using (var db = new DataContext())
            {
                var category = new Category() { Id = id };
                db.Categories.Attach(category);
                category.Name = name;
                db.Entry(category).Property(_ => _.Name).IsModified = true;
                db.SaveChanges();
            }
        }
    }
}
