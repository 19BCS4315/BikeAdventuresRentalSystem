using BikeAdventures.BikeService.DataAccessLayer.Models;
using BikeAdventures.PaymentService.DataAccessLayer.Models;
using BikeAdventures.RentService.DataAccessLayer.Models;
using BikeAdventures.UserAuthentication.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace BikeAdventures.UserAuthentication.DataAccessLayer.Data
{
    public class UserData : DbContext
    {
        public DbSet<AuthUser> Users { get; set; }
        public DbSet<Bike> Bikes { get; set; } = null!;
        public DbSet<Rental> Rentals { get; set; } = null!;
        public DbSet<RentalItem> RentalItems { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Payment> Payments { get; set; } = null!;

        public UserData(DbContextOptions<UserData> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RentalItem>().HasOne(ri => ri.Bike).WithMany().HasForeignKey(ri => ri.BikeId);
            modelBuilder.Entity<RentalItem>().HasOne(ri => ri.Customer).WithMany().HasForeignKey(ri => ri.CustomerId);
            modelBuilder.Entity<Rental>().HasOne(r => r.Customer).WithMany().HasForeignKey(r => r.CustomerId);

            modelBuilder.Entity<Payment>().HasKey(p => p.PaymentId);
            modelBuilder.Entity<Payment>().Property(p => p.PaymentType).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Payment>().Property(p => p.PaymentStatus).HasMaxLength(50).IsRequired();


            modelBuilder.Entity<RentalItem>().HasKey(ri => ri.RentalItemId);


            modelBuilder.Entity<Rental>().HasKey(r => r.RentalId);


            modelBuilder.Entity<Bike>().HasKey(b => b.BikeId);
            modelBuilder.Entity<Bike>().Property(b => b.BikeType).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Bike>().Property(b => b.Brand).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Bike>().Property(b => b.Model).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Bike>().Property(b => b.RentalPricePerHour).HasColumnType("decimal(18 ,2)");
            modelBuilder.Entity<Bike>().Property(b => b.RentalPricePerDay).HasColumnType("decimal(18 ,2)");
            modelBuilder.Entity<Bike>().Property(b => b.RentalPricePerWeek).HasColumnType("decimal(18 ,2)");


            modelBuilder.Entity<Customer>().HasKey(c => c.CustomerId);



            base.OnModelCreating(modelBuilder);
        }
    }
}
