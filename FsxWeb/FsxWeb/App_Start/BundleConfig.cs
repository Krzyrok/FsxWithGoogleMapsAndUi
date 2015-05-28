namespace FsxWeb
{
    using System.Web.Optimization;

    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            var bundle = new ScriptBundle("~/Content/js")
                .Include("~/Content/libs/angular/angular.js")
                .Include("//maps.googleapis.com/maps/api/js?sensor=false")
                .Include("~/Content/libs/lodash/dist/lodash.js")
                .Include("~/Content/libs/angular-google-maps/dist/angular-google-maps.js")
                .Include("~/Scripts/app.js");
            bundles.Add(bundle);

            bundle = new StyleBundle("~/Content/css")
                .Include("~/Content/css/site.css");
            bundles.Add(bundle);

            bundle = new ScriptBundle("~/functionality/home")
                .Include("~/Scripts/plane/planeController.js")
                .Include("~/Scripts/plane/planeService.js");
            bundles.Add(bundle);
        }
    }
}
