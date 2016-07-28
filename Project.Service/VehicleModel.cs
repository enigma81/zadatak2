namespace Project.Service
{
    public class VehicleModel : AVehicle
    {
        public int MakeId { get; set; }

        public virtual VehicleMake VehicleMake { get; set; }
    }
}

