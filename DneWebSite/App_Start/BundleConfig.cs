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

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      vendorBasePath + "bootstrap/dist/js/bootstrap.min.js",
                      vendorBasePath + "/respond/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      vendorBasePath + "/bootstrap/dist/css/bootstrap.min.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/fullCalendar").Include(
                    vendorBasePath + "fullcalendar/dist/fullcalendar.js",
                    vendorBasePath + "fullcalendar/dist/lang-all.js"
                    ));
        }
    }
}
