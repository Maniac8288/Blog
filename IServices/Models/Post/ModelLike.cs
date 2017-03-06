using IServices.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices.Models.Post
{       /// <summary>
        /// Модель лайков
        /// </summary>
    public class ModelLike
    {
        
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
