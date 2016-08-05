using System.Web.Mvc;
using System.Web.Routing;
using Project.Service;
using System.Data.Entity;
using System;

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

        protected void Application_Error(object sender, EventArgs e)
        {
            //Exception ex = Server.GetLastError();
            //Server.ClearError();
            //Response.Redirect("/Error/ErrorMessage");
        }
    }
}
