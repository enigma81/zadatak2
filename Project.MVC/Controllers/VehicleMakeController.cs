using System.Web.Mvc;
using Project.MVC.Models;

namespace Project.MVC.Controllers
{
    public class VehicleMakeController : Controller
    {
        private VehicleMake vehicle = new VehicleMake();


        // GET: VehicleMake
        public ActionResult Index()
        {
            return View(vehicle.VehicleMakes);
        }
    }
}