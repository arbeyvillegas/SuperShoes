using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using SuperShoes.Domain;

namespace SuperShoes.Services
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            IUnityContainer container = new UnityContainer();
            UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            section.Configure(container);
            UnityServiceLocator locator = new UnityServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => locator);
        }
    }
}
