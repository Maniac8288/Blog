using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models
{
    /// <summary>
    /// Модель лайков для поста
    /// </summary>
 public class PostLike
    {   public int id { get; set; }
        /// <summary>
        /// Пользователь
        /// </summary>
        public int UserID { get; set;}
        /// <summary>
        /// Пост
        /// </summary>
        public int PostID { get; set; }

    }
}
