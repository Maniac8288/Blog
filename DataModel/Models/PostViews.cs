using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models
{
   public class PostViews
    {
  
        /// <summary>
        /// Индификатор пользователя  с типом данных Guid
        /// </summary>
        public Guid id { get; set; }
        /// <summary>
        /// Номер поста
        /// </summary>
        public int PostID { get; set; }


    }
}
