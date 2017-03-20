using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models
{
    /// <summary>
    /// Модель комментария 
    /// </summary>
    public class Comment
    {
        /// <summary>
        /// Ид
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }
        /// <summary>
        /// Содержимое комментария
        /// </summary>
        public string ContetntComment { get; set; }
        public Comment Pareant { get; set; }
        public int? PareantId { get; set; }
        public List<Comment> Child { get; set; }
        /// <summary>
        /// Пост которому пренадлежит комментарий
        /// </summary>
        /// <value>The post.</value>
        public List<Post> Post { get; set; }
        /// <summary>
        /// Пользователь которому пренадлежит комментарий
        /// </summary>
        /// <value>The user.</value>
        public List<User> User { get; set; }
        /// <summary>
        /// Время добавления поста
        /// </summary>
        public DateTime DateAddComment { get; set;}
        public bool Answer { get; set; }
    }
}
