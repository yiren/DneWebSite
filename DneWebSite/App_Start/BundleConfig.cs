using System.Web;
using System.Web.Optimization;

namespace DneWebSite
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            string vendorBasePath = "~/assets/vendor";

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        vendorBasePath + "/jquery/dist/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            //bundles.Add(new ScriptBundle("~/revSlider").Include("~/"));
            //bundles.Add(new StyleBundle("~/revSliderCss").Include("~/"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      vendorBasePath + "bootstrap/dist/js/bootstrap.min.js",
                      vendorBasePath + "/respond/respond.js"));

            bundles.Add(new StyleBundle("~/sitecss").Include(
                      "~/css/bootstrap/bootstrap.css",
                      "~/css/animate.css","~/css/animations","~/css/style.css",
                      vendorBasePath + "/respond/respond.js"));

            //FullCalendar Plug-in
            bundles.Add(new ScriptBundle("~/fullCalendar").Include(
                    vendorBasePath + "fullcalendar/dist/fullcalendar.js",
                    vendorBasePath + "fullcalendar/dist/lang-all.js"
                    ));
            bundles.Add(new StyleBundle("~/fullCalendarCss").Include(
                    vendorBasePath+"fullcalendar/dist/fullcalendar.min.css"));
        }
    }
}
