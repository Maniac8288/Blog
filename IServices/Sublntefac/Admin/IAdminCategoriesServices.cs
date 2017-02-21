using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices.Sublntefac.Admin
{
    /// <summary>
    /// Реализует методы для управления категориями
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
        /// <summary>
        /// Удаления родительской категории
        /// </summary>
        /// <param name="name">Имя родительской категории</param>
        void DeletePareant(string name);
        /// <summary>
        /// Удаляет дочернию категорию
        /// </summary>
        /// <param name="NamePareant">Имя родительской категории</param>
        /// <param name="NameChildren">Имя дочерний категории</param>
        void DeleteChild(string NamePareant, string NameChildren);
        /// <summary>
        /// Изменяет название родительской категории
        /// </summary>
        /// <param name="namePareant">Выбраная родительская категория</param>
        /// <param name="newName">Новое название катеогрии</param>
        void ChangeNamePareant(string namePareant, string newName);
        /// <summary>
        /// Изменяет название дочерней категории
        /// </summary>
        /// <param name="NamePareant">Имя родительской категории</param>
        /// <param name="nameChild">Имя дочерний категории</param>
        /// <param name="newName">Новое имя</param>
        void ChangeNameChild(string NamePareant, string nameChild, string newName);
    }
}
