using IServices;
using IServices.Sublntefac.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Функционал админки
/// </summary>
namespace Services
{
    /// <summary>
    /// Управление публичной частью
    /// </summary>
    public class MainServices : IMainServices
    {
        public MainServices()
        {
            Users = new UserServices();
            Post = new PostServices();
       
        
        }
        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        public IUserServices Users { get; set; }
        /// <summary>
        /// Отображение постов
        /// </summary>
        public IPostServices Post { get; set; }
        
      

    }
}
