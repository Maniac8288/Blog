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
    /// Модель категории
    /// </summary>
    public class ModelCategory
    {
        /// <summary>
        /// Ид категории
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название категории
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Родительская категория
        /// </summary>
        public ModelCategory Parent { get; set; }
        /// <summary>
        /// ID родительской категории
        /// </summary>
        public int? ParentId { get; set; }
        /// <summary>
        /// Дочернии категории
        /// </summary>
        public List<ModelCategory> Child { get; set; }

        
    }
}
