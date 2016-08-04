using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Diagnostics.Contracts;

namespace Project.Service
{
    public class VehicleService
    {
        #region Properties
        public IEnumerable<VehicleModel> VehicleModels
        {
            get
            {
                using(var db  = new VehicleDBContext())
                    return db.VehicleModels.ToList();
            }
        }
        public IEnumerable<VehicleMake> VehicleMakes
        {
            get
            {
                using (var db = new VehicleDBContext())
                    return db.VehicleMakes.ToList();
            }
        }
        #endregion
        
        public IEnumerable<VehicleModel> GetVehicleModels(int? makeId, int? page, int pageSize, out int pageCount)
        {
            IEnumerable<VehicleModel> models;

            int pageNumber = page ?? 1;
            
            if (makeId == null)
            {
                // Get all vehicle models
                models = this.VehicleModels;
                pageCount = (int)Math.Ceiling((decimal)models.Count() / (decimal)pageSize);
                return (models.Skip((pageNumber - 1) * pageSize).Take(pageSize));

            }
            else
            {
                models = this.VehicleModels.Where(x => x.MakeId == makeId);     // Get a list of models belonging to a VehicleMake
                pageCount = (int)Math.Ceiling(models.Count() / (decimal)pageSize);
                return (models.Skip((pageNumber - 1) * pageSize).Take(pageSize));
            }
        }

        public VehicleModel GetModelById(int? id)
        {
            Contract.Requires(id != null);
            Contract.Requires(id > 0);

            VehicleModel model;

            try
            {
                model = VehicleModels.SingleOrDefault(x => x.Id == id);
                return model;
            }
            catch (Exception)
            {
                // Have to check how to handle exceptions
                throw new Exception("fatal error");
            }
        }

        // Insert new vehicle
        public bool Insert(AVehicle vehicle, out string error)
        {            
            Contract.Requires(vehicle != null);
            Contract.Requires<ArgumentNullException>(String.IsNullOrEmpty(vehicle.Name) == false,"Name is compulsory");

            using (var db = new VehicleDBContext())
            {
                if (vehicle.GetType() == typeof(VehicleMake))
                {                    
                    Mapper.Initialize(cfg => cfg.CreateMap<VehicleMake, VehicleMake>());

                    VehicleMake toInsert = new VehicleMake();

                    Mapper.Map((VehicleMake)vehicle, toInsert);

                    db.VehicleMakes.Add(toInsert);
                }
                else if (vehicle.GetType() == typeof(VehicleModel))
                {   
                    Mapper.Initialize(cfg => cfg.CreateMap<VehicleModel, VehicleModel>());
                    VehicleModel toInsert = new VehicleModel();

                    Mapper.Map((VehicleModel)vehicle, toInsert);

                    db.VehicleModels.Add(toInsert);
                }
                else
                {
                    throw new Exception("error data input");
                }

                try
                {
                    db.SaveChanges();
                    error = String.Empty;
                    return true;
                }
                catch (Exception e)
                {
                    error = e.Message;
                    return false;
                }                
            }
        }

        // Update vehicle
        public bool Update(AVehicle vehicle, out string error)
        {
            Contract.Requires(vehicle != null);
            Contract.Requires<ArgumentNullException>(String.IsNullOrEmpty(vehicle.Name) == false, "Name is compulsory");

            using (var db = new VehicleDBContext())
            {
                if (vehicle.GetType() == typeof(VehicleMake))
                {
                    VehicleMake toUpdate = new VehicleMake();
                    Mapper.Initialize(cfg => cfg.CreateMap<VehicleMake, VehicleMake>());
                    toUpdate = db.VehicleMakes.FirstOrDefault(x => x.Id == vehicle.Id);

                    Mapper.Map((VehicleMake)vehicle, toUpdate);
                }
                else if (vehicle.GetType() == typeof(VehicleModel))
                {
                    VehicleModel toUpdate = new VehicleModel();
                    Mapper.Initialize(cfg => cfg.CreateMap<VehicleModel, VehicleModel>());
                    toUpdate = db.VehicleModels.FirstOrDefault(x => x.Id == vehicle.Id);

                    Mapper.Map((VehicleModel)vehicle, toUpdate);
                }

                try
                {
                    db.SaveChanges();
                    error = String.Empty;
                    return true;
                }
                catch (Exception e)
                {
                    error = e.Message + " something went wrong";
                    return false;
                }
            }
        }

        // Delete vehicle
        public bool DeleteModel(int id)
        {
            Contract.Requires(id > 0);

            using (var db = new VehicleDBContext())
            {
                VehicleModel toDelete = db.VehicleModels.SingleOrDefault(x => x.Id == id);
                if (toDelete != null)
                {
                    db.VehicleModels.Remove(toDelete);
                    db.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
        }
    }// VehicleService   
    
}


