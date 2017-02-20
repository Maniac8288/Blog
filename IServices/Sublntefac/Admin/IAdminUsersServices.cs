using IServices.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices.Sublntefac.Admin
{
   public interface IAdminUsersServices
    {
        /// <summary>
        /// Удаляет выбраных пользователей из БД
        /// </summary>
        /// <param name="id">Ид пользователя </param>
        void Delete(List<int> id);
        /// <summary>
        /// Коллекция пользователей 
        /// </summary>
        /// <returns></returns>
        List<ModelUserInfo> Users();
        /// <summary>
        /// Изменяет статус выбранных пользователей в БД на "Заблокированый"
        /// </summary>
        /// <param name="id"></param>
        void Block(List<int> id);
        void roleUsers(List<int> id, string role);


    }
}
