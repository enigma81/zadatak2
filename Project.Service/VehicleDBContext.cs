namespace Project.Service
{
    using System.Data.Entity;

    public class VehicleDBContext : DbContext
    {
        public DbSet<VehicleMake> VehicleMakes { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleModel>().Property(x => x.Name)
                .HasColumnName("Name")
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<VehicleModel>()
                .HasRequired(x => x.VehicleMake)
                .WithMany(x => x.VehicleModels)
                .HasForeignKey(x => x.MakeId);
        }
    }
}
