using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models
{
     /// <summary>
      /// Модель поста
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
            /// <summary>
            /// Выбраная категория
            /// </summary>
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
            public DateTime  dateAddPost { get; set; }
            /// <summary>
            /// Название картинки
            /// </summary>
            public string upload { get; set; }
            /// <summary>
            /// ID Поста
            /// </summary>
            public int PostID { get; set; }
            /// <summary>
            /// Автор поста
            /// </summary>
            public string Author { get; set; }
            
            public List<User> Users { get; set; }
    }
}
