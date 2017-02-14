
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Infrastructura
{
    public class FilterUser: AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            
            base.OnAuthorization(filterContext);
        }

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
            bool u = false;
            if (role != "")
            {
                /// Проверка соответствия роли пользователя 
                //using (var db = new DataContext())
                //{
                //    var t = db.Users.Where(x => x.Roles.Any(y => y.Name == role));
                //    u = t.Any(x => x.UserName == WebUser.CurrentUser.UserName);
                //}
            }
            if (user == UserName || u)
            {
                return WebUser.CurrentUser.IsAuth;
            }
            return false;

        }
    }
}