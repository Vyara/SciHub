namespace SciHub.Web
{
    using System.Web.Optimization;

    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
            "~/Scripts/Kendo/kendo.all.min.js",
            "~/Scripts/Kendo/kendo.aspnetmvc.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jquery-ui").Include(
                "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/sigalr").Include(
                "~/Scripts/jquery.signalR-2.2.0.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/kendo-css").Include(
            "~/Content/Kendo/kendo.common.min.css",
            "~/Content/Kendo/kendo.default.min.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/flatly").Include(
                "~/Content/flatly.bootstrap.min.css",
                "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/celurean").Include(
                "~/Content/celurean.bootstrap.min.css",
                "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/darkly").Include(
                "~/Content/darkly.bootstrap.min.css",
                "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/journal").Include(
                "~/Content/journal.bootstrap.min.css",
                "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/paper").Include(
                "~/Content/paper.bootstrap.min.css",
                "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/spacelab").Include(
                "~/Content/spacelab.bootstrap.min.css",
                "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/superhero").Include(
                "~/Content/superhero.bootstrap.min.css",
                "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/slate").Include(
                "~/Content/slate.bootstrap.min.css",
                "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Content/jquery-ui").Include("~/Content/themes/base/*.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}