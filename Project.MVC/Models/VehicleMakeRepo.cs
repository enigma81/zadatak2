using System.Collections.Generic;
using Project.Service;
using System.Linq;

namespace Project.MVC.Models
{
    public class VehicleMakeRepo
    {
        public IEnumerable<VehicleMake> GetAll()
        {
            return GetAllVehicleMake();
        }

        private IEnumerable<VehicleMake> GetAllVehicleMake()
        {
            using (var db = new VehicleDBContext())
            {
                VehicleService1<VehicleMake> service = new VehicleService1<VehicleMake>(db);

                return service.Get().ToList();
            }
        }
    }
}