﻿using DataModel;
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
        public void AddPost(ModelPost model, int IdCategory)
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
    }
}