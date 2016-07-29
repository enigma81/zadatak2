using System.Collections.Generic;
using System.Data.Entity;

namespace Project.Service
{
    internal class SeedData
    {
        private List<VehicleMake> _Vehicles;

        public SeedData()
        {
            _Vehicles = new List<VehicleMake>()
            {
                new VehicleMake()
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
                },

                new VehicleMake()
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
                },

                new VehicleMake()
                {
                    Name = "Audi AG",
                    Abrv = "AUDI",
                    VehicleModels = new List<VehicleModel>()
                    {
                        new VehicleModel()
                        {
                            Name = "AUDI A6",
                            Abrv = "A6"
                        }
                    }
                }
             }; // List<VehicleMake>
        }

        public List<VehicleMake> Vehicles
        {
            get
            {
                return _Vehicles;
            }
        }
    }

    public class VehicleDBContextSeederModelChanges : DropCreateDatabaseIfModelChanges<VehicleDBContext>
    {
        protected override void Seed(VehicleDBContext context)
        {
            var seedData = new SeedData();

            context.VehicleMake.AddRange(seedData.Vehicles);
            base.Seed(context);
        }
    }

    public class VehicleDBContextSeederNotExists : CreateDatabaseIfNotExists<VehicleDBContext>
    {
        protected override void Seed(VehicleDBContext context)
        {
            var seedData = new SeedData();

            context.VehicleMake.AddRange(seedData.Vehicles);
            base.Seed(context);
        }
    }
}