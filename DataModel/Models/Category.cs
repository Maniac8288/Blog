using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models
{
    /// <summary>
    /// Модель категорий
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Ид категории
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Имя категории
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Коллекция наследников категорий
        /// </summary>
        public List<Category> Childrens { get; set; }
        public List<Post> Posts { get; set; }
    }
}
