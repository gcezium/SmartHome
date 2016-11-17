using System.Web;
using System.Web.Optimization;

namespace Cezium.SmartHome.UI
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

#if DEBUG
            BundleTable.EnableOptimizations = false;
#endif

            bundles.Add(new ScriptBundle("~/bundles/js-lib")
                .Include("~/Scripts/jquery-{version}.js")
                .Include("~/Scripts/angular.min.js")

                .Include("~/app/lib/angular/*.js")
                .Include("~/app/lib/jquery/*.js")

                .Include("~/Scripts/angular-messages.js")
                .Include("~/Scripts/angular-message-format.js")
                .Include("~/app/lib/angular/angular-ui-router.js")

                .Include("~/app/shared/components/*.js")
                .Include("~/app/shared/services/*.js")
                .Include("~/app/shared/app.components.js")

                .Include("~/app/modules/dashboard/*.js")
                .Include("~/app/modules/dashboard/components/*.js")
                .Include("~/app/modules/control/*.js")

                .Include("~/app/app.js")
            );


            bundles.Add(new ScriptBundle("~/bundles/admin-lte")
                .Include("~/Content/AdminLTE/bootstrap/js/bootstrap.js")
                .Include("~/Content/AdminLTE/dist/js/app.js")
                .Include("~/Content/AdminLTE/plugins/icheck/icheck.js")
            );


            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/AdminLTE/bootstrap/css/bootstrap.min.css")
                .Include("~/Content/css/font-awesome.min.css")
                .Include("~/Content/css/ionicons.min.css")
                .Include("~/Content/AdminLTE/dist/css/AdminLTE.min.css")
                .Include("~/Content/AdminLTE/dist/css/skins/_all-skins.min.css")
                .Include("~/Content/AdminLTE/plugins/iCheck/all.css")
                .Include("~/Content/css/main.css")
            );
        }
    }
}
