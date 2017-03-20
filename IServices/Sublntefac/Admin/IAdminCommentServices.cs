using IServices.Models.Post;
using IServices.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices.Sublntefac.Admin
{
    public interface IAdminCommentServices
    {
        // <summary>
        /// Вывод всех комментериев
        /// </summary>
        /// <returns></returns>
        List<ModelComment> GetComments(string user);
        /// <summary>
        /// Удаление комментария
        /// </summary>
        /// <param name="Id">Ид комментария</param>
        void DeleteComment(int Id,int? PareantId);
        /// <summary>
        /// Редактирование содержимого коментария
        /// </summary>
        /// <param name="id">Ид комментария</param>
        /// <param name="content">Содержимое комментария</param>
        void EditComment(int id, string content);
        /// <summary>
        /// Выполняет поиск пользователей
        /// </summary>
        /// <param name="term">Ввод</param>
        /// <returns></returns>
        List<ModelUser> Search(string term);
    }
}
