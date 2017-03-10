using DataModel;
using System.Data.Entity;
using DataModel.Models;
using IServices.Sublntefac.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Функционал админки
/// </summary>
namespace Services.Admin
{
    /// <summary>
    /// Управление категорями 
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
        /// <summary>
        /// Удаления родительской категории, а также содержимое родительской категории
        /// </summary>
        /// <param name="name">Имя родительской категории</param>
        public void DeletePareant(string name)
        {
            using (var db = new DataContext())  
            {
                var category = db.Categories.Include(x=> x.Child).FirstOrDefault(_ => _.Name==name);
                db.Categories.RemoveRange(category.Child);
                db.Categories.Remove(category);
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Удаляет дочернию категорию
        /// </summary>
        /// <param name="NamePareant">Имя родительской категории</param>
        /// <param name="NameChildren">Имя дочерний категории</param>
        public void DeleteChild (string NamePareant,string NameChildren)
        {
            using (var db = new DataContext())
            {
                var Pareant = db.Categories.Include(x => x.Child).FirstOrDefault(_ => _.Name == NamePareant);
                var Child = Pareant.Child.FirstOrDefault(_ => _.Name == NameChildren);
                db.Categories.Remove(Child);
                db.SaveChanges();
            }

        }
        /// <summary>
        /// Изменяет название родительской категории
        /// </summary>
        /// <param name="namePareant">Выбраная родительская категория</param>
        /// <param name="newName">Новое название катеогрии</param>
        public void ChangeNamePareant(string namePareant, string newName)
        {
            using (var db = new DataContext())
            {
                var category = db.Categories.FirstOrDefault(_ => _.Name == namePareant);
                category.Name = newName;
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Изменяет название дочерней категории
        /// </summary>
        /// <param name="NamePareant">Имя родительской категории</param>
        /// <param name="nameChild">Имя дочерний категории</param>
        /// <param name="newName">Новое имя</param>
        public void ChangeNameChild(string NamePareant, string nameChild, string newName)
        {
            using (var db = new DataContext())
            {
                var Pareant = db.Categories.Include(x => x.Child).FirstOrDefault(_ => _.Name == NamePareant);
                var Child = Pareant.Child.FirstOrDefault(_ => _.Name == nameChild);
                Child.Name = newName;
                db.SaveChanges();
            }

        }
        /// <summary>
        /// Вывод всех родительских категорий
        /// </summary>
        /// <returns></returns>
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
