using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Cadres.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_End()
        {

        }

        protected void Session_Start()
        {

        }

        protected void Session_End()
        {

        }

        protected void Application_BeginRequest()
        {

        }

        protected void Application_EndRequest()
        {

        }

        protected void Application_Error()
        {

        }
    }
}
