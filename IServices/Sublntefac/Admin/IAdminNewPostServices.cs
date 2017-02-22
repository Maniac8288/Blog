using DataModel.Models;
using IServices.Models.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices.Sublntefac.Admin
{
    public interface IAdminNewPostServices
    {
        /// <summary>
        /// Добавление нового поста
        /// </summary>
        /// <param name="model">Модель поста</param>
        void AddPost(ModelPost model);
    }
}
