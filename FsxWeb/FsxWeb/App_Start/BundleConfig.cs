namespace FsxWeb
{
    using System.Web.Optimization;

    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Content/js").Include(
                        "~/Content/libs/"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/site.css"));
        }
    }
}
