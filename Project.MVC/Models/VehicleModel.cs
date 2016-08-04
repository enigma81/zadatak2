using Project.Service;
using System.Collections.Generic;

namespace Project.MVC.Models
{
    public class VehicleModel
    {
        private VehicleService service = new VehicleService();

        public IEnumerable<Service.VehicleModel> VehicleModels
        {
            get
            {
                return service.VehicleModels;
            }
        }
    }
}