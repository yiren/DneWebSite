using System.Web;
using System.Web.Optimization;

namespace DneWebSite
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            string vendorBasePath = "~/plugins/bowerPackage";

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        vendorBasePath + "/jquery/dist/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/plugins/jquery.validate*"));

            //bundles.Add(new ScriptBundle("~/revSlider").Include("~/"));
            //bundles.Add(new StyleBundle("~/revSliderCss").Include("~/"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/plugins/modernizr-*"));

            

            
        }
    }
}
