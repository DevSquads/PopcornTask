using System.Web;
using System.Web.Optimization;

namespace PopcornTask {
	public class BundleConfig {
		// For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles) {
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
						/*"~/Scripts/jquery-{version}.js"*/ "~/Scripts/jquery-3.2.1.min.js"));

			bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
						"~/Scripts/jquery.validate*"));

			// Use the development version of Modernizr to develop with and learn from. Then, when you're
			// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
						"~/Scripts/modernizr-*"));

			bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
					  "~/Scripts/bootstrap.js",
					  "~/Scripts/respond.js"));
			bundles.Add(new StyleBundle("~/Content/css").Include(
					  "~/Content/bootstrap.css",
					  "~/Content/font-awesome.css",
					  "~/Content/site.css"));
			bundles.Add(new ScriptBundle("~/bundles/isotope").Include(
					"~/Scripts/Plugins/Isotope/isotope.pkgd.min.js",
					  "~/Scripts/Plugins/Isotope/fitcolumns.js"));

			bundles.Add(new StyleBundle("~/Content/Login").Include(
					"~/Content/main_styles.css",
					  "~/Content/login.css"));
			bundles.Add(new ScriptBundle("~/Scripts/Login").Include(
					  "~/Content/login.js"));
			bundles.Add(new ScriptBundle("~/Scripts/custom").Include(
					  "~/Scripts/custom.js",
					  "~/Scripts/addtoorder.js"));
			bundles.Add(new ScriptBundle("~/Scripts/cart").Include(
					  "~/Scripts/cart.js",
					  "~/Scripts/manageorder.js"));
			bundles.Add(new StyleBundle("~/Content/custom").Include(
					"~/Content/main_styles.css",
					  "~/Content/responsive.css"));
			bundles.Add(new StyleBundle("~/Content/cart").Include(
						"~/Content/cart.css",
						"~/Content/cart_responsive.css"));

		}
	}
}
