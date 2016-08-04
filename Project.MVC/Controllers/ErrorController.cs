using System.Web.Mvc;

namespace Project.MVC.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult ErrorMessage()
        {
            return View();
        }
    }
}