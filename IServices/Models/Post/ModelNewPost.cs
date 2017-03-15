using DataModel.Models;
using IServices.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Модели интерфейса для поста.
/// </summary>
namespace IServices.Models.Post
{
    /// <summary>
    /// Модель нового поста
    /// </summary>
    public class ModelNewPost
    {
        /// <summary>
        /// Название поста
        /// </summary>
        public string NamePost { get; set; }
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
        public List<ModelUser> Users {get;set;}
       

    }
}
