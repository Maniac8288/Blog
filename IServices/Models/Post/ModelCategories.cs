using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Модели интерфейса для поста.
/// </summary>
namespace IServices.Models.Post
{
    /// <summary>
    /// Класс отвечает за отображения категорий.
    /// </summary>
    public class ModelCategories
    {
        /// <summary>
        /// Категории.
        /// </summary>
        /// <value>Категории.</value>
        public List<ModelCategory> Categories { get; set; }
        /// <summary>
        /// Только родительские категории.
        /// </summary>
        
        public List<ModelCategory> GetParents() { return Categories.Where(_ => !_.ParentId.HasValue).ToList(); }
        /// <summary>
        /// Получить родительскую категорию.
        /// </summary>
        /// <param name="parentId">Ид родительской категории.</param>
        /// <returns>ModelCategory.</returns>
        public ModelCategory GetParent(int? parentId) { return Categories.FirstOrDefault(_ => _.Id == parentId); }
        /// <summary>
        /// Получение дочерний категории.
        /// </summary>
        /// <param name="parentId">ИД родительской категории.</param>
        /// <returns>List&lt;ModelCategory&gt;.</returns>
        public List<ModelCategory> GetChild(int? parentId) { return Categories.Where(_ => _.ParentId == parentId).ToList(); }
    }
}
