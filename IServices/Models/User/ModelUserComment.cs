using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices.Models.User
{
  public  class ModelUserComment
    {
        /// <summary>
        /// Ид пользователя
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Логин пользователя
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Фото пользователя
        /// </summary>
        public string Photo { get; set; }

 
      
    }
}
