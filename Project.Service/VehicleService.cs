using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace Project.Service
{
    public class VehicleService
    {
        public List<VehicleMake> GetVehicleMake()
        {
            using (var db = new VehicleDBContext())
            {
                return db.VehicleMake.ToList();
            }
        }

        public List<VehicleModel> GetVehicleModel()
        {
            using (var db = new VehicleDBContext())
            {
                return db.VehicleModel.ToList();
            }
        }

        public void InsertVehicleMake(VehicleMake vehicle)
        {
            VehicleMake toInsert = new VehicleMake();

            using (var db = new VehicleDBContext())
            {
                Mapper.Initialize(cfg => cfg.CreateMap<VehicleMake, VehicleMake>());

                if (String.IsNullOrEmpty(vehicle.Name))
                    throw new Exception("Name required");

                Mapper.Map(vehicle, toInsert);

                db.VehicleMake.Add(toInsert);
                db.SaveChanges();
            }

        }

        public void UpdateVehicleMake(VehicleMake update)
        {
            using (var db = new VehicleDBContext())
            {
                Mapper.Initialize(cfg => cfg.CreateMap<VehicleMake, VehicleMake>());
                VehicleMake toUpdate = db.VehicleMake.FirstOrDefault(x => x.Id == update.Id);

                Mapper.Map(update, toUpdate);
                db.SaveChanges();
            }

        }
        public void DeleteVehicleMake(VehicleMake delete)
        {
            using (var db = new VehicleDBContext())
            {
                VehicleMake toDelete = db.VehicleMake.FirstOrDefault(x => x.Id == delete.Id);
                db.VehicleMake.Remove(toDelete);
                db.SaveChanges();
            }
        }

        public VehicleMake GetById(int Id)
        {
            using (var db = new VehicleDBContext())
            {
                return db.VehicleMake.FirstOrDefault(x => x.Id == Id);
            }
        }

    }// VehicleService
}
