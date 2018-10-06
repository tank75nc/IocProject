using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MyIocContainer;

namespace IOC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = new IocContainer();
            IOCRegistration.Configure(container);
            ControllerBuilder.Current.SetControllerFactory(new IocControllerFactory(container));
        }
    }

    public static class IOCRegistration
    {
        public static void Configure(IMyContainer pContainer)
        {
            pContainer.Register<Controllers.HomeController, Controllers.HomeController>();
            pContainer.Register<Controllers.UsersController, Controllers.UsersController>();
            pContainer.Register<Controllers.LocationsController, Controllers.LocationsController>();
        }
    }
}
