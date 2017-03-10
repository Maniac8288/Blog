
using IServices.Sublntefac;
using IServices.Sublntefac.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Интерфейс 
/// </summary>
namespace IServices
{
    /// <summary>
    /// Интерфейс публичной части сайта
    /// </summary>
    public interface IMainServices
    {
        /// <summary>
        /// Реализация авторизации и регистрации на сайте
        /// </summary>
        IUserServices Users { get; set; }
        /// <summary>
        /// Отображение постов на сайте
        /// </summary>
        IPostServices Post { get; set; }
       
    }
}
