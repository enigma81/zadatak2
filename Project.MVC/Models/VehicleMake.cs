using System.Collections.Generic;
using Project.Service;

namespace Project.MVC.Models
{
    public class VehicleMake
    {
        private VehicleService service = new VehicleService();

        public IEnumerable<Service.VehicleMake> VehicleMakes
        {
            get
            {
                return service.VehicleMakes;
            }
        }
    }
}