using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data
{
    public class RentalDbContext : DbContext
    {
        public RentalDbContext(DbContextOptions<RentalDbContext> options) : base(options) { }
        public virtual DbSet<Rental> Rentals { get; set; } = null!;
        public virtual DbSet<RentalItem> RentalItems { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rental>().HasKey(r => r.RentalId);
            modelBuilder.Entity<Rental>().Property(r => r.RentalType).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Rental>().Property(r => r.RentalStartDate).IsRequired();
            modelBuilder.Entity<Rental>().Property(r => r.RentalEndDate).IsRequired();
            modelBuilder.Entity<Rental>().Property(r => r.RentalDuration).IsRequired();
            modelBuilder.Entity<Rental>().Property(r => r.TotalRentalAmount).IsRequired();
            modelBuilder.Entity<Rental>().Property(r => r.PaymentStatus).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Rental>().HasOne(r => r.Customer).WithMany(c => c.Rentals).HasForeignKey(r => r.CustomerId);

            modelBuilder.Entity<RentalItem>().HasKey(ri => ri.RentalItemId);
            modelBuilder.Entity<RentalItem>()
                .HasOne(ri=>ri.Rental)
                .WithMany(r=> r.RentalItems)
                .HasForeignKey(ri=> ri.RentalId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Customer>().HasKey(c => c.CustomerId);
            modelBuilder.Entity<Customer>().HasMany(c => c.Rentals).WithOne(r => r.Customer).HasForeignKey(r => r.CustomerId);


        }
    }
}
