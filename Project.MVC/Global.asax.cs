using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Project.Service;
using System.Data.Entity;

namespace Project.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Database.SetInitializer(new VehicleDBContextSeederNotExists());
            Database.SetInitializer(new VehicleDBContextSeederModelChanges());
        }
    }
}
