using IServices;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using IServices.Models;
using System.Linq.Expressions;
using IServices.Sublntefac;
using Blog;
using DataModel.Models;

namespace Services
{
   
    public class PostServices : IPostServices
    {
        public static DataContext db = new DataContext();
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
            using(var db = new DataContext())
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
                Author=post.Author
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
    }
}
