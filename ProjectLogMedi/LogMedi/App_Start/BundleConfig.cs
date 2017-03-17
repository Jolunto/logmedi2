using System.Web;
using System.Web.Optimization;

namespace LogMedi
{
    public class BundleConfig
    {
        // Para obtener más información sobre Bundles, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.unobtrusive-ajax.min.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"
                    ));
            bundles.Add(new ScriptBundle("~/bundles/theme").Include(
                      "~/Content/plugin/slimScroll/jquery.slimscroll.min.js",
                      "~/Content/plugin/fastclick/fastclick.js",
                      "~/Content/dist/js/app.min.js",
                      "~/Content/dist/js/demo.js",
                      "~/Scripts/Custom.js",
                      "~/Content/plugin/jquery-ui/jquery-ui.min.js",
                      "~/Content/dist/js/bootstrapValidator.min.js",
                      "~/Content/plugin/datepicker/bootstrap-datepicker.es.min.js"
                    ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                 "~/Content/bootstrap/css/bootstrap.min.css",
                  "~/Content/plugin/font-awesome/css/font-awesome.min.css",
                  "~/Content/plugin/ionicons/css/ionicons.min.css",
                  "~/Content/dist/css/AdminLTE.min.css",
                  "~/Content/dist/css/skins/_all-skins.min.css",
                  "~/Content/plugin/jquery-ui/jquery-ui.min.css",
                  "~/Content/plugin/datepicker/datepicker3.min.css",
                  "~/Content/dist/css/bootstrapValidator.min.css"

               ));
        }
    }
}


