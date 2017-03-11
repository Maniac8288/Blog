using IServices.Models.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

/// <summary>
/// Интерфейс функцианала админки
/// </summary>
namespace IServices.Sublntefac.Admin
{
    /// <summary>
    /// Интерфейс, который реализует методы для управления постами
    /// </summary>
    public interface IAdminPostsServices
    {
        /// <summary>
        /// Удаление выбраных постов
        /// </summary>
        /// <param name="id">Выбраные посты</param>
        /// <param name="mapPath">Расположение к папке с постом</param>
        void DeletePosts(List<int> id,string map);
        /// <summary>
        /// Добавление  нового поста
        /// </summary>
        /// <param name="model">Модель поста</param>
        /// <param name="IdCategory">Ид категории</param>
        void AddPost(ModelNewPost model,int IdCategory);
        /// <summary>
        /// Возвращает модель редактирование поста
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ModelPost GetEditPost(int id);
        /// <summary>
        /// Изменяет выбранный пост в БД
        /// </summary>
        /// <param name="model">Выбраный пост</param>
        /// <param name="IdCategory">ID категории</param>
        void EditPost(ModelNewPost model, int IdCategory);
        /// <summary>
        /// Добавление изображение в Priview 
        /// </summary>
        /// <param name="upload">Изображения</param>
        /// <param name="mapPath">Путь для сохранения файла</param>
        /// <param name="model">Модель поста</param>
        void Image(HttpPostedFileBase upload, string mapPath,ModelNewPost model);
        /// <summary>
        /// Загржает изображение на сервер и получает путь к файлу изображения
        /// </summary>
        /// <param name="upload">Изображения</param>
        /// <param name="CKEditorFuncNum">Идентификационный номер анонимного функции обратного вызова после загрузки</param>
        /// <param name="mapPath">Путь для сохранения файла</param>
        /// <returns>Возвращает строку с Ajax запросом</returns>
        string ProcessRequest(HttpPostedFileBase upload, string CKEditorFuncNum, string mapPath, ModelNewPost model);
        /// <summary>
        /// Выводит пост с информацией "Preview"
        /// </summary>
        /// <returns></returns>
         List<ModelPostPreview> PostPreview();
        /// <summary>
        /// Вывод всех категорий
        /// </summary>
        /// <returns>Модель Категории.</returns>
        ModelCategories GetCategory();
    }
}
