using Autofac;
using Autofac.Integration.Mvc;
using IServices;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
/// <summary>
/// The App_Start namespace.
/// </summary>
namespace Blog.App_Start
{
    /// <summary>
    /// Class AutofacConfig.
    /// </summary>
    public class AutofacConfig
    {
        /// <summary>
        /// Configures the container.
        /// </summary>
        public static void ConfigureContainer()
        {
            // получаем экземпляр контейнера
            var builder = new ContainerBuilder();

            // регистрируем контроллер в текущей сборке
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // регистрируем споставление типов
            builder.RegisterType<MainServices>().As<IMainServices>();
            builder.RegisterType<AdminServices>().As<IAdminServices>();

            // создаем новый контейнер с теми зависимостями, которые определены выше
            var container = builder.Build();

            // установка сопоставителя зависимостей
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
} 