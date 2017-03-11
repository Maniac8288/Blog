using IServices.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Интерфейс функцианала админки
/// </summary>
namespace IServices.Sublntefac.Admin
{
    /// <summary>
    ///  Реализует методы для управлениями пользователями
    /// </summary>
    public interface IAdminUsersServices
    {
        /// <summary>
        /// Удаляет выбраных пользователей из БД
        /// </summary>
        /// <param name="id">Ид пользователя </param>
        void Delete(List<int> id);
        /// <summary>
        /// Коллекция пользователей 
        /// </summary>
        /// <returns></returns>
        List<ModelUserInfo> Users();
        /// <summary>
        /// Изменяет статус выбранных пользователей в БД на "Заблокированый"
        /// </summary>
        /// <param name="id"></param>
        void Block(List<int> id);
        /// <summary>
        /// Назначить роль пользователю 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="role"></param>
        void roleUsers(List<int> id, string role);
        /// <summary>
        /// Метод реализующий регистрацию 
        /// </summary>
        /// <param name="userName">Имя пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <param name="dataBird">Дата рождения пользователя</param>
        string Register(string userName, string password, DateTime dataBird, string email);

    }
}
