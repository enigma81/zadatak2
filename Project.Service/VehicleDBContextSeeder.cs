using System.Collections.Generic;
using System.Data.Entity;

namespace Project.Service
{
    public class VehicleDBContextSeeder : CreateDatabaseIfNotExists<VehicleDBContext>
    {
        protected override void Seed(VehicleDBContext context)
        {
            VehicleMake vehicle1 = new VehicleMake()
            {
                Name = "Ford",
                Abrv = "Ford",
                VehicleModels = new List<VehicleModel>()
                {
                    new VehicleModel()
                    {
                        Name = "Ford Focus",
                        Abrv = "Ford"
                    },
                    new VehicleModel()
                    {
                        Name = "Mustang GT",
                        Abrv = "Ford"
                    }
                }
            };

            VehicleMake vehicle2 = new VehicleMake()
            {
                Name = "Bayerische Motoren Werke",
                Abrv = "BMW",
                VehicleModels = new List<VehicleModel>()
                {
                    new VehicleModel()
                    {
                        Name = "i8 Plug-in Hybrid",
                        Abrv = "BMW"
                    },
                    new VehicleModel()
                    {
                        Name = "X5",
                        Abrv = "BMW"
                    }
                }
            };

            context.VehicleMake.Add(vehicle1);
            context.VehicleMake.Add(vehicle2);
            base.Seed(context);
        }
    }
}