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
{       /// <summary>
        /// Модель лайков
        /// </summary>
    public class ModelLike
    {
        /// <summary>
        /// Ид лайка
        /// </summary>
        /// <value>ИД лайка.</value>
        public int id { get; set; }
        /// <summary>
        /// Пользователь
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// Пост
        /// </summary>
        public int PostID { get; set; }

    }
}
