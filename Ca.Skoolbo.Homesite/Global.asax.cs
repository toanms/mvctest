using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ca.Skoolbo.Homesite.Extensions;

namespace Ca.Skoolbo.Homesite
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(RegularExpressionCustom), typeof(RegularExpressionAttributeAdapter));
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            ViewEngines.Engines.Clear();

            ViewEngines.Engines.Add(new RazorViewEngine());
        }
    }
}
