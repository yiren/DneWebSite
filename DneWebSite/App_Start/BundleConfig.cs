using System.Web;
using System.Web.Optimization;

namespace DneWebSite
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/slider")
                .Include("~/js/rev-slider-init.js"))
                ;
            bundles.Add(new ScriptBundle("~/script/jq")
                .Include(
                    "~/Scripts/jquery-{version}.min.js",
                    "~/Scripts/jquery-ui-{version}.min.js",
                    "~/Scripts/bootstrap.min.js"));
            //css  
            bundles.Add(new StyleBundle("~/css/base").Include(
                    "~/Content/bootstrap.min.css",
                    "~/Content/bootstrap.theme.min.css",
                    "~/Content/themes/base/jquery-ui.min.css",
                    "~/Content/themes/cupertino/jquery-ui.cupertino.min.css",
                    
                   "~/plugins/bowerPackage/fontawesome/css/font-awesome.min.css"

                   ));

            bundles.Add(new ScriptBundle("~/script")
                .Include(
                    "~/Scripts/jquery-2.1.1.min.js",
                    "~/Content/mdl-v1.1.2/material.min.js",
                    "~/plugins/template/bootstrap/js/bootstrap.min.js",
                    "~/plugins/template/modernizr.js",
                    "~/plugins/template/jquery.parallax-1.1.3.js",
                    "~/plugins/template/jquery.appear.js",
                    "~/plugins/template/rs-plugin/js/jquery.themepunch.revolution.min.js",
                    "~/plugins/template/rs-plugin/js/jquery.themepunch.tools.min.js",
                    "~/plugins/bowerPackage/qtip2/jquery.qtip.min.js",
                    "~/js/templatev1.js",
                    "~/js/qTip2.js",
                    "~/plugins/bowerPackage/angular/angular.min.js",
                    "~/plugins/bowerPackage/angular-ui-router/release/angular-ui-router.min.js",
                    "~/plugins/bowerPackage/angular-animate/angular-animate.min.js",
                    "~/plugins/template/fullcalendar/lib/moment.min.js",
                    "~/plugins/bowerPackage/angular-ui-calendar/src/calendar.js",
                    "~/plugins/bowerPackage/fullcalendar/dist/fullcalendar.min.js",
                    "~/plugins/bowerPackage/fullcalendar/dist/gcal.js",
                    "~/plugins/bowerPackage/fullcalendar/dist/lang-all.js",
                    "~/plugins/bowerPackage/angular-ui-grid/ui-grid.min.js",
                    "~/plugins/bowerPackage/angular-scroll/angular-scroll.min.js",
                    "~/plugins/bowerPackage/angular-bootstrap/ui-bootstrap-tpls.js",
                    "~/plugins/bowerPackage/ng-dialog/js/ngDialog.min.js",
                    "~/plugins/bowerPackage/angularjs-toaster/toaster.min.js",
                    "~/client/app.js",
                    "~/client/router.js",
                    "~/client/controllers/meetingGridController.js",
                    "~/client/controllers/postGridController.js",
                    "~/client/controllers/calendar/calViewController.js",
                    "~/client/controllers/integrityController.js",
                    "~/client/controllers/common/modalController.js"
                ));

            //bundles.Add(new ScriptBundle("~/revSlider").Include("~/"));
            //bundles.Add(new StyleBundle("~/revSliderCss").Include("~/"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.



            BundleTable.EnableOptimizations = true;
            
        }
    }
}
