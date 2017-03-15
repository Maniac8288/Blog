using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Модель БД
/// </summary>
namespace DataModel.Models
{
    /// <summary>
    /// Модель поста
    /// </summary>
    public class Post
    {
        /// <summary>
        /// Название поста
        /// </summary>
        public string NamePost { get; set; }
        /// <summary>
        /// Информация о выбранной категории
        /// </summary>
        public Category SelectCategories { get; set; }
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
        public int AuthorID { get; set; }
        /// <summary>
        /// Количество лайков 
        /// </summary>
        /// <value>
        /// The count like.
        /// </value>
        public int CountLike { get; set; }
        /// <summary>
        /// Количество просмотров
        /// </summary>
        public int CountViews { get; set; }
        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>
        /// The users.
        /// </value>
        public List<User> Users { get; set; }
        public List<Tag> CollectionTag { get; set; }
        public List<Comment> Comments { get; set; }

    }
}
