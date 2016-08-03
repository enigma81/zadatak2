using System.Collections.Generic;
using System.Data.Entity;

namespace Project.Service
{
    public class SeedData
    {
        private List<VehicleMake> _vehicles;

        public SeedData()
        {
            _vehicles = new List<VehicleMake>()
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
                            Abrv = "Ford",
                            MakeId = 1                            
                        },
                        new VehicleModel()
                        {
                            Name = "Mustang GT",
                            Abrv = "Ford",
                            MakeId = 1
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
                            Abrv = "BMW",
                            MakeId = 2
                        },
                        new VehicleModel()
                        {
                            Name = "X5",
                            Abrv = "BMW",
                            MakeId = 2
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
                            Abrv = "A6",
                            MakeId = 3
                        }
                    }
                }
             }; // List<VehicleMake>
        }

        public List<VehicleMake> Vehicles
        {
            get
            {
                return _vehicles;
            }
        }
    }

    public class VehicleDBContextSeederModelChanges : DropCreateDatabaseIfModelChanges<VehicleDBContext>
    {
        protected override void Seed(VehicleDBContext context)
        {
            var seedData = new SeedData();

            context.VehicleMakes.AddRange(seedData.Vehicles);
            base.Seed(context);
        }
    }

    public class VehicleDBContextSeederNotExists : CreateDatabaseIfNotExists<VehicleDBContext>
    {
        protected override void Seed(VehicleDBContext context)
        {
            var seedData = new SeedData();

            context.VehicleMakes.AddRange(seedData.Vehicles);
            base.Seed(context);
        }
    }
}