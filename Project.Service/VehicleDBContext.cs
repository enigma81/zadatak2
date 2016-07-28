using System.Data.Entity;

namespace Project.Service
{
    public class VehicleDBContext : DbContext
    {
        public DbSet<VehicleMake> VehicleMake { get; set; }
        public DbSet<VehicleModel> VehicleModel { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{   
        //    modelBuilder.Entity<VehicleMake>().ToTable("VehicleMake");
        //    modelBuilder.Entity<VehicleModel>().ToTable("VehicleModel");
        //}
    }
}
