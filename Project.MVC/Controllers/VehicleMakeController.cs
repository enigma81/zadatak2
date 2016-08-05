using System.Web.Mvc;
using Project.MVC.Models;

namespace Project.MVC.Controllers
{
    public class VehicleMakeController : Controller
    {
        private VehicleMakeRepo vehicle = new VehicleMakeRepo();
        
        // GET: VehicleMake
        public ActionResult Index()
        {
            return View(vehicle.GetAll());
        }
    }
}