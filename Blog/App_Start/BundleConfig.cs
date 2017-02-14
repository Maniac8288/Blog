using System.Web;
using System.Web.Optimization;

namespace Blog
{
    public class BundleConfig
    {
        //Дополнительные сведения об объединении см. по адресу: http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-1.11.1.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Используйте версию Modernizr для разработчиков, чтобы учиться работать. Когда вы будете готовы перейти к работе,
            // используйте средство сборки на сайте http://modernizr.com, чтобы выбрать только нужные тесты.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));
            bundles.Add(new ScriptBundle("~/bundles/site").Include(
                 "~/Scripts/customizer.js",
                      "~/Scripts/hoverIntent.js",
                        "~/Scripts/customizer.js",
                          "~/Scripts/html5shiv.js",
                            "~/Scripts/settings.js",
                           "~/Jcrop-v0.9.12/js/jquery.Jcrop.min.js",
                            "~/Scripts/jquery.color.js",
                             "~/Scripts/superfish.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/style.css",
                         "~/Content/athemes-symbols.css",
                         "~/Jcrop-v0.9.12/css/jquery.Jcrop.min.css"));
        }
    }
}
