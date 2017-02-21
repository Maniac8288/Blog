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
  public  class AdminCategoriesServices : IAdminCategoriesServices
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
        /// <summary>
        /// Добовляет дочернию категорию
        /// </summary>
        /// <param name="namePareant">Имя родительской категории</param>
        /// <param name="nameChild">Название новой категории</param>
        public void addChildCategory(string namePareant,string nameChild)
        {
            using (var db = new DataContext())
            {
                var category = db.Categories.FirstOrDefault(_ => _.Name == namePareant);
                db.Categories.Add(new Category() { Name = nameChild, ParentId = category.Id });
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
        public static List<Category> GetCategoryPareants()
        {
            using (var db = new DataContext())
            {
                var categories = db.Categories.Where(_ => !_.ParentId.HasValue).ToList();
                return categories;
            }
        }

    }
}
