using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Service
{
    public class VehicleModel : AVehicle
    {
        public int MakeId { get; set; }
        [ForeignKey("MakeId")]
        public virtual VehicleMake VehicleMake { get; set; }
    }
}

