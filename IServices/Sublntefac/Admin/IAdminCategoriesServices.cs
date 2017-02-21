using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices.Sublntefac.Admin
{
    /// <summary>
    /// Реализует методы связанные с категорями
    /// </summary>
    public interface IAdminCategoriesServices
    {   
        /// <summary>
        /// Добавление родительской категории 
        /// </summary>
        /// <param name="name">Название категории</param>
        void AddCategory(string name);
        /// <summary>
        /// Добавляет дочернию категорию
        /// </summary>
        /// <param name="namePareant">Имя родильской категории</param>
        /// <param name="nameChild">Название категории</param>
         void addChildCategory(string namePareant, string nameChild);
    }
}
