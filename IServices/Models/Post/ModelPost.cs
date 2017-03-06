using DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices.Models.Post
{
    /// <summary>
    /// Модель поста
    /// </summary>
    public class ModelPost
    {
        /// <summary>
        /// Название поста
        /// </summary>
        public string NamePost { get; set; }
        /// <summary>
        /// Коллекция постов
        /// </summary>
        /// <summary>
        /// Выбраная категория
        /// </summary>
        public Category selectedCategory { get; set; }
        /// <summary>
        /// Краткое описание поста
        /// </summary>
        public string Description { get; set; }
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
        public DateTime dateAddPost { get; set; }
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
        public string Author { get; set;}
        /// <summary>
        /// Количество лайков
        /// </summary>
        public int CountLike { get; set; }
        public ModelCategory Category { get; set; }

    }
}
