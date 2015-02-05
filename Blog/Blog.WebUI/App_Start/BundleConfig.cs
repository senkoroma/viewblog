using System.Web.Optimization;

namespace Blog.WebUI.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            var scripts = new ScriptBundle("~/scripts");

            scripts.Include("~/Scripts/AddComment.js");
            scripts.Include("~/Scripts/jquery.js");
            
            bundles.Add(scripts);

            var styles = new StyleBundle("~/css");

            styles.Include("~/css/bootstrap.css");
            styles.Include("~/css/clean-blog.css");
            styles.Include("~/css/ErrorPage.css");

            bundles.Add(styles);
        }
    }
}