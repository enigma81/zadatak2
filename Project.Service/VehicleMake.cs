using System.Collections.Generic;

namespace Project.Service
{
    public class VehicleMake : AVehicle
    {
        public virtual ICollection<VehicleModel> VehicleModels { get; set; }
    }
}