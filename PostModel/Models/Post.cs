using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PostModel.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Post
    {/// <summary>
    /// Название поста
    /// </summary>
         public string NamePost { get; set; }
        /// <summary>
        /// Коллекция постов
        /// </summary>
        public static List<Category> Categories { get; set; }

        public string selectedCategory { get; set; }
        /// <summary>
        /// Содержимое поста
        /// </summary>
        public string contentPost { get; set; }
        /// <summary>
        /// Тэги
        /// </summary>
        public string Tags { get; set; }
 
        public List<string> CollectionTags = new List<string>();
        /// <summary>
        /// Дата создания
        /// </summary>
        public string dateAddPost { get; set; }
        /// <summary>
        /// Название картинки
        /// </summary>
        public string upload { get; set; }
        public int PostID { get; set; }
       
    }
   
}