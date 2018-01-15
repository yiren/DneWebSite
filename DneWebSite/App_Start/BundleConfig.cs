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
                    "~/Scripts/jquery-2.1.1.min.js",
                    "~/Scripts/jquery-ui-1.12.1.min.js",
                    //"~/Content/bootstrap-material-design/dist/js/material.min.js",
                    //"~/Content/bootstrap-material-design/dist/js/ripples.min.js",
                    "~/Scripts/bootstrap.min.js"));
            //css  

            bundles.Add(new StyleBundle("~/home/css").Include(
                    "~/plugins/template/bootstrap/css/bootstrap.css",
                    //"~/node_modules/font-awesome/css/font-awesome.min.css",
                    //"~/node_modules/angular-ui-grid/ui-grid.min.css",
                    //"~/plugins/template/fontello/css/fontello.css",
                    "~/plugins/template/rs-plugin/css/settings.css",
                    "~/plugins/template/rs-plugin/css/extralayers.css",
                    "~/css/shortcode_timeline1.css",
                    "~/css/animations.css",
                    "~/node_modules/fullcalendar/dist/fullcalendar.min.css",
                    
                    "~/node_modules/angularjs-toaster/toaster.css",
                    "~/node_modules/ng-dialog/css/ngDialog.min.css",
                    "~/node_modules/ng-dialog/css/ngDialog-theme-default.min.css",
                    "~/css/stylev1.css",
                    "~/css/skins/green.css",
                    "~/css/customv1.css"
                )

                );


            bundles.Add(new StyleBundle("~/css/base").Include(
                    "~/Content/bootstrap.min.css",
                    "~/Content/bootstrap.theme.min.css",
                    //"~/Content/material-design-icons/iconfont/material-icons.css",
                    //"~/Content/bootstrap-material-design/dist/css/bootstrap-materail-design.min.css",
                    //"~/Content/bootstrap-material-design/dist/css/ripples.min.css",
                    "~/Content/themes/base/jquery-ui.min.css",
                    "~/Content/themes/cupertino/jquery-ui.cupertino.min.css",

                   "~/node_modules/font-awesome/css/font-awesome.min.css"

                   ));

            bundles.Add(new ScriptBundle("~/script/tt")
                .Include(
                    "~/Scripts/jquery-2.1.1.min.js",
                    "~/plugins/template/bootstrap/js/bootstrap.min.js",
                    "~/plugins/template/modernizr.js",
                    "~/plugins/template/jquery.parallax-1.1.3.js",
                    "~/plugins/template/jquery.appear.js",
                    "~/plugins/template/rs-plugin/js/jquery.themepunch.revolution.min.js",
                    "~/plugins/template/rs-plugin/js/jquery.themepunch.tools.min.js",
                    "~/plugins/bowerPackage/qtip2/jquery.qtip.min.js",
                    //"~/Content/bootstrap-material-design/dist/js/material.min.js",
                    //"~/Content/bootstrap-material-design/dist/js/ripples.min.js",
                    "~/js/templatev1.js",
                    "~/js/qTip2.js",
                    "~/node_modules/angular/angular.min.js",
                    "~/node_modules/angular-ui-router/release/angular-ui-router.min.js",
                    "~/node_modules/angular-animate/angular-animate.min.js",
                    "~/node_modules/moment/min/moment.min.js",
                    "~/node_modules/angular-ui-calendar/src/calendar.js",
                    "~/node_modules/fullcalendar/dist/fullcalendar.min.js",
                    "~/node_modules/fullcalendar/dist/gcal.js",
                    "~/node_modules/fullcalendar/dist/lang-all.js",
                    "~/node_modules/angular-ui-grid/ui-grid.min.js",
                    "~/node_modules/angular-scroll/angular-scroll.min.js",
                    
                    "~/node_modules/angular-ui-bootstrap/dist/ui-bootstrap-tpls.js",
                    
                    "~/node_modules/ng-dialog/js/ngDialog.min.js",
                    "~/node_modules/angularjs-toaster/toaster.min.js",

                    "~/client/app.js",
                    "~/client/router.js",
                    "~/client/controllers/homeController.js",
                    "~/client/controllers/meetingGridController.js",
                    "~/client/controllers/postGridController.js",
                    "~/client/controllers/calendar/calViewController.js",
                    "~/client/controllers/common/modalController.js",
                    "~/client/controllers/integrityController.js",
                    "~/client/controllers/orgCtrlController.min.js",
                    "~/client/controllers/gospController.min.js"

                ));

            //bundles.Add(new ScriptBundle("~/revSlider").Include("~/"));
            //bundles.Add(new StyleBundle("~/revSliderCss").Include("~/"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.

            bundles.Add(new ScriptBundle("~/bundles/jqueryval")
                .Include(
                "~/Scripts/jquery.validate.min.js",
                "~/Scripts/jquery.validate.unobtrusive.min.js"
         
                ));

            BundleTable.EnableOptimizations = true;
            
        }
    }
}
