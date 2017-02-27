using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IServices.Models;
using IServices.Models.Post;
using DataModel.Models;

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

        ModelCategories GetCategory();

    }
}
