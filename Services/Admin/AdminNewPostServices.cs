using DataModel;
using DataModel.Models;
using IServices.Models.Post;
using IServices.Sublntefac.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Admin
{
  public  class AdminNewPostServices:IAdminNewPostServices
    {
        /// <summary>
        /// Добавление  нового поста
        /// </summary>
        /// <param name="model">Модель поста</param>
        public void AddPost(ModelPost model)
        {
            using (var db = new DataContext()) {
                 
                //db.Posts.Add(model);
                //db.SaveChanges();
            }  
        }
        
    }
}
