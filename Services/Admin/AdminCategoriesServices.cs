using DataModel;
using DataModel.Models;
using IServices.Sublntefac.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Admin
{
    /// <summary>
    /// Реализует методы связанные с категорями
    /// </summary>
    class AdminCategoriesServices : IAdminCategoriesServices
    {
        /// <summary>
        /// Добавляет родительскую категорию
        /// </summary>
        /// <param name="name">Название категории</param>
        public void AddCategory(string name)
        {
            using (var db = new DataContext())
            {
                db.Categories.Add(new Category() { Name = name });

                db.SaveChanges();
            }
        }

        public void Update(int id)
        {
            using (var db = new DataContext())
            {
                var category = db.Categories.FirstOrDefault(_ => _.Id == id);

                db.SaveChanges();
            }


        }
    }
}
