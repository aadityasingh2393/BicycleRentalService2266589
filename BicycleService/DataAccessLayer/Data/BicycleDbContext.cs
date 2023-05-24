

using BicycleRentalSystem.BicycleService.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace BicycleRentalSystem.BicycleService.DataAccessLayer.Data
{
    public class BicycleDbContext:DbContext
    {
        public BicycleDbContext(DbContextOptions<BicycleDbContext>options):base(options) { }
        public virtual DbSet<Bicycle> Bicycle { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bicycle>().HasKey(b => b.BicycleId);
            modelBuilder.Entity<Bicycle>().Property(b => b.BicycleType).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Bicycle>().Property(b => b.Brand).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Bicycle>().Property(b => b.Model).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Bicycle>().Property(b => b.PurchaseDate).HasColumnType("dateTime");
            modelBuilder.Entity<Bicycle>().Property(b => b.PurchasePrice).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Bicycle>().Property(b => b.RentalPricePerHour).HasColumnType("decimal(18, 2)");
            modelBuilder.Entity<Bicycle>().Property(b => b.RentalPricePerDay).HasColumnType("decimal(18, 2)");
            modelBuilder.Entity<Bicycle>().Property(b => b.RentalPricePerWeek).HasColumnType("decimal(18, 2)");
            modelBuilder.Entity<Bicycle>().Property(b => b.AvailableQuantity).IsRequired();

            base.OnModelCreating(modelBuilder);

        }


    }
}
