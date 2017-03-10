using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Модели БД.
/// </summary>
namespace DataModel.Models
{
    /// <summary>
    /// Модель категорий
    /// </summary>
    public class Category
    {
        /// <summary>
        ///Ид категории.
        /// </summary>
        /// <value>ИД.</value>
        public int Id { get; set; }
        /// <summary>
        /// Имя категории.
        /// </summary>
        /// <value>Имя.</value>
        public string Name { get; set; }
        /// <summary>
        /// Родительская категория.
        /// </summary>
        /// <value>Родитель.</value>
        public Category Parent { get; set; }
        /// <summary>
        /// Ид родительской категории.
        /// </summary>
        /// <value>ИД родителя.</value>
        public int? ParentId { get; set; }
        /// <summary>
        /// Дочерния категория.
        /// </summary>
        /// <value>Дочерния категория.</value>
        public List<Category> Child { get; set; }
  

    }
}
