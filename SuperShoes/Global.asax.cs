using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SuperShoes
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            IUnityContainer container = new UnityContainer();
            UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            section.Configure(container);
            UnityServiceLocator locator = new UnityServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => locator);
        }
    }
}
