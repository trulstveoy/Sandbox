using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using StackExchange.Profiling;
using Webbox.Core.Web.Profiling;

namespace Webbox
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            ConfigureCamelCaseJson();
            ConfigureProfiling();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            DurandalBundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void ConfigureProfiling()
        {
            GlobalFilters.Filters.Add(new ProfilingActionFilter());
            GlobalConfiguration.Configuration.Filters.Add(new ProfilingActionApiFilter());
        }

        private static void ConfigureCamelCaseJson()
        {
            var formatters = GlobalConfiguration.Configuration.Formatters;
            var jsonFormatter = formatters.JsonFormatter;
            var settings = jsonFormatter.SerializerSettings;
            settings.Formatting = Formatting.Indented;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}