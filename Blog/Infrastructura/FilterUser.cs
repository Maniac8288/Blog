
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
/// <summary>
/// Инфраструктура сайта
/// </summary>
namespace Blog.Infrastructura
{
    /// <summary>
    /// Класс отвечающий за фильтрацию пользователей.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.AuthorizeAttribute" />
    public class FilterUser: AuthorizeAttribute
    {
        /// <summary>
        /// Вызывается, когда процесс запрашивает авторизацию.
        /// </summary>
        /// <param name="filterContext">Контекст фильтра, инкапсулирующий сведения для использования объекта <see cref="T:System.Web.Mvc.AuthorizeAttribute" />.</param>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            
            base.OnAuthorization(filterContext);
        }
        /// <summary>
        /// В случае переопределения предоставляет точку входа для пользовательской проверки авторизации.
        /// </summary>
        /// <param name="httpContext">Контекст HTTP, который инкапсулирует все НТТР-данные об индивидуальном НТТР-запросе.</param>
        /// <returns>Значение true, если пользователь авторизован. В противном случае — значение false.</returns>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            /// Извлечение имен и ролей пользователей, авторизованных 
            /// для получения доступа 
            var role = Roles;
            var user = Users;
          
            var cookie = httpContext.Request.Cookies["User"];
            string UserName;
            bool IsAuth = false;
            if (WebUser.CurrentUser.UserName == null && cookie != null)
            {
                UserName = cookie.Values["UserName"];
                if (cookie.Values["IsAuth"] == "True") IsAuth = true;
            }
            else
            {
                UserName = WebUser.CurrentUser.UserName;
            }
            bool check = false;
            if (role != "")
            {
                check = Services.UserServices.check(check, role, WebUser.CurrentUser.UserName);
             
            }
            if (user == UserName || check)
            {
                return WebUser.CurrentUser.IsAuth;
            }
            return false;

        }
    }
}