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
        public int Id { get; set; }

        public string Name { get; set; }

        public Category Parent { get; set; }

        public int? ParentId { get; set; }

        public List<Category> Сhild { get; set; }

        public List<Post> Posts { get; set; }

    }
}
