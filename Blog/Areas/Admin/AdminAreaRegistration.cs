using System.Web.Mvc;

namespace Blog.Areas.Admin
{
    /// <summary>
    /// Class AdminAreaRegistration.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.AreaRegistration" />
    public class AdminAreaRegistration : AreaRegistration 
    {
        /// <summary>
        /// Получает имя регистрируемой области.
        /// </summary>
        /// <value>The name of the area.</value>
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }
        /// <summary>
        /// Регистрирует область в приложении MVC ASP.NET, используя указанные сведения о контексте области.
        /// </summary>
        /// <param name="context">Инкапсулирует сведения, необходимые для регистрации области.</param>
        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}