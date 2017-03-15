using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IServices.Models;
using IServices.Models.Post;
using DataModel.Models;

/// <summary>
/// Интерфейс функцианала публичной части
/// </summary>
namespace IServices.Sublntefac.Public
{
    /// <summary>
    /// Отображание постов на странице
    /// </summary>
    public interface IPostServices
    {
        /// <summary>
        /// Вывод поста с информацией  "Детальней"
        /// </summary>
        /// <returns></returns>
        List<ModelPost> PostDetails();
        /// <summary>
        /// Вывод поста с информацией "Preview"
        /// </summary>
        /// <returns></returns>
        List<ModelPostPreview> PostPreview();
        /// <summary>
        /// Ставит лайк посту
        /// </summary>
        /// <param name="PostId">Id поста</param>
        /// <param name="UserID">Id пользователя</param>
        void GetLike(int PostId, int UserID);
        /// <summary>
        /// Добовляет просмотр к посту
        /// </summary>
        /// <param name="PostID">Номер поста</param>
        void GetView(int PostID);
        /// <summary>
        /// Вывод облако тегов
        /// </summary>
        List<ModelTags> CloudTags();
        ModelCategories GetCategory();
        /// <summary>
        /// Вывод популярных постов
        /// </summary>
     
        List<ModelPost> PostPopular();
        /// <summary>
        /// Добавление комментария
        /// </summary>
        /// <param name="ContentComment">Содержимое комментария</param>
        /// <param name="UserId">ИД пользователя.</param>
        /// <param name="PostId">Ид поста</param>
        void AddComent(string ContentComment, int UserId, int PostId);
        /// <summary>
        /// Вывод комментарий
        /// </summary>
        /// <param name="PostID">Ид поста</param>
 
         List<ModelComment> Comment(int PostID);
       

    }
}
