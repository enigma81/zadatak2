using System.Web.Mvc;
using Project.Service;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Project.MVC.Controllers
{
    public class VehicleModelController : Controller
    {
        public int pageSize = 2;
                
        private VehicleService service = new VehicleService();

        // GET: VehicleModels
        public ActionResult Index(int? makeId, int? page, string orderBy)
        {
            int pageCount;

            ViewBag.makeId = makeId ?? null;
            ViewBag.page = page ?? 1;
            ViewBag.SortName = string.IsNullOrEmpty(orderBy) ? "Name" : "";
            
            IEnumerable<VehicleModel> models = service.GetVehicleModels(makeId, page, pageSize, out pageCount);
            ViewBag.pageCount = pageCount;

            switch (orderBy)
            {
                case "Name":
                    return View(models.OrderByDescending(x => x.Name));
                default:
                    return View(models.OrderBy(x => x.Name));
            }
            //IEnumerable<VehicleModel> models;
            
            //int pageNumber;
            
            //if (page == null)
            //{
            //    pageNumber = 1;
            //}
            //else
            //{
            //    pageNumber = (int)page;
            //}                

            //if (makeId == null)
            //{
            //    // Get all vehicle models
            //    models = service.VehicleModels;
            //    ViewBag.totalPages = (int)Math.Ceiling((decimal)models.Count() / (decimal)pageSize);
            //    ViewBag.makeId = null;
            //    return View(models.Skip((pageNumber - 1) * pageSize).Take(pageSize));

            //}                                     
            //else
            //{                
            //    models = service.VehicleModels.Where(x => x.MakeId == makeId);     // Get a list of models belonging to a VehicleMake
            //    ViewBag.totalPages = (int)Math.Ceiling((decimal)models.Count() / (decimal)pageSize);
            //    ViewBag.makeId = makeId;
            //    return View(models.Skip((pageNumber - 1) * pageSize).Take(pageSize));
            //} 
        }

        public ActionResult Details(int? id)
        {
            ViewBag.page = ViewBag.page;
            if (id != null && id > 0)
            {
                VehicleModel model = service.GetModelById(id);    // Get vehicle model where id matching
                return View(model);
            }
            else
                return RedirectToAction("Index", "VehicleMake");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(VehicleModel vehicleModel)
        {            
            var error = String.Empty;
            
            if (ModelState.IsValid)
            {
                if (service.Insert(vehicleModel, out error))
                {
                    return RedirectToAction("Index", new { makeId = vehicleModel.MakeId });
                }                
            }
            Response.Write(error);
            
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if(id != null && id > 0)
            {
                VehicleModel toEdit = service.GetModelById(id);
                return View(toEdit);
            }

            return RedirectToAction("Index","VehicleMake");
        }
    
        [HttpPost]
        public ActionResult Edit(VehicleModel vehicleModel)
        {
            var error = string.Empty;

            if (ModelState.IsValid)
            {
                if(service.Update(vehicleModel, out error))
                    return RedirectToAction("Index", new { makeId = vehicleModel.MakeId});
            }

            Response.Write(error);
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                VehicleModel toDelete = service.GetModelById(id);

                try
                {
                    service.DeleteModel(id);
                    return RedirectToAction("Index",
                        new { makeId = ViewBag.makeId, page = ViewBag.page});
                }
                catch (Exception)
                {
                    return RedirectToAction("Index", "VehicleMake"); ;
                }                
            }
            return RedirectToAction("Index", "VehicleMake");
        }
    }
}