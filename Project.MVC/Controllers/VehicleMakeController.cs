using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Service;

namespace Project.MVC.Controllers
{
    public class VehicleMakeController : Controller
    {
        private VehicleService service = new VehicleService();
        // GET: VehicleMake
        public ActionResult Index()
        {
            return View(service.VehicleMakes);
        }
    }
}