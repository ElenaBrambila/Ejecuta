using System.Web;
using System.Web.Optimization;

namespace IntegramsaUltimate
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/componentes.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/select2").Include(
                        "~/Scripts/select2.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

             bundles.Add(new ScriptBundle("~/bundles/kendojs").Include(
            "~/Scripts/kendo/kendo.all.min.js",
            "~/Scripts/kendo/kendo.aspnetmvc.min.js",
            "~/Scripts/kendo/kendo.web.min.js",
            "~/Scripts/kendo/cultures/kendo.culture.es-MX.min.js",
          //  "~/Scripts/jquery.clearsearch.js",
          //  "~/Scripts/jquery.bootgrid.fa.min.js",
          //  "~/Scripts/jquery.bootgrid.js",
            "~/Scripts/kendoHDELEON.js",
            "~/Scripts/comun.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/componentes.css",
                      "~/Content/css/select2.css"));



            bundles.Add(new StyleBundle("~/Content/kendo/css").Include(
                         "~/Content/kendo/kendo.common.min.css",
                         "~/Content/kendo/kendo.default.min.css"));

            //Scripts para el área de clientes
            bundles.Add(new StyleBundle("~/Content/kendo/ejemplos").Include(
                         "~/Content/kendo/Ejemplos/examples.css",
                         "~/Content/kendo/Ejemplos/kendo.rtl.min.css",
                         "~/Content/kendo/Ejemplos/kendo.default-v2.min.css"));
        }
    }
}
