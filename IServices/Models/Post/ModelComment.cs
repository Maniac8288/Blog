using IServices.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices.Models.Post
{
    /// <summary>
    /// Модель комментариев 
    /// </summary>
    public class ModelComment
    {
        /// <summary>
        /// Ид
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }
        /// <summary>
        /// Содержимое комментария.
        /// </summary>
        public string ContentComment { get; set; }
        /// <summary>
        /// Родительский комментарий
        /// </summary>
        /// <value>Родитель.</value>
        public ModelComment Pareant { get; set; }
        /// <summary>
        /// Ид родительского комментария
        /// </summary>
        /// <value>Ид Родителя.</value>
        public int? PareantId { get; set; }
        /// <summary>
        /// Дочерний комментарий.
        /// </summary>
        /// <value>Дочерний комментарий.</value>
        public List<ModelComment> Child { get; set; }
        /// <summary>
        /// Пользователь которому пренадлежит комментарий
        /// </summary>
        /// <value>The user.</value>
        public List<ModelUserComment> User { get; set; }
        /// <summary>
        /// Пост которому пренадлежит комментарий
        /// </summary>
        /// <value>The post.</value>
        public List<ModelPost> Post { get; set; }
        /// <summary>
        /// Дата добавление поста
        /// </summary>
        public DateTime DateAddPost { get; set; }
        public bool Answer { get; set; }
    }
}
