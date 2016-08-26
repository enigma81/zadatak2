using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service
{
    interface IVehicleService
    {
        IQueryable<VehicleMake> GetVehicleMakes();
        IQueryable<VehicleModel> GetVehicleModels();
    }
}
