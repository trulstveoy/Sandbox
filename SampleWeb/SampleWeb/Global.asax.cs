using System;
using System.Collections.Generic;
<<<<<<< HEAD
=======
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
>>>>>>> index view created
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
<<<<<<< HEAD
=======
using System.Web.Optimization;
>>>>>>> index view created
using System.Web.Routing;

namespace SampleWeb
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
<<<<<<< HEAD
=======

>>>>>>> index view created
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
<<<<<<< HEAD
=======
            BundleConfig.RegisterBundles(BundleTable.Bundles);
>>>>>>> index view created
        }
    }
}