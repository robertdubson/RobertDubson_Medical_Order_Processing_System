using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DataModel;
using Microsoft.AspNetCore.Identity;
namespace DataLayer
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {

        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<CityEntity> Cities { get; set; }
        public DbSet<ClientEntity> Clients { get; set; }
        public DbSet<DeliveryCompanyAndCityEntity> CompaniesAndCities { get; set; }
        public DbSet<DeliveryCompanyEntity> Companies { get; set; }
        public DbSet<DoctorEntity> Doctors { get; set; }
        public DbSet<FactoryEntity> Factories { get; set; }
        public DbSet<IssuePointEntity> IssuePoints { get; set; }
        public DbSet<MedicalProductEntity> MedicalProducts { get; set; }
        public DbSet<ProductAndFactoryEntity> ProductsAndFactories { get; set; }
        public DbSet<ReceiptAndProductEntity> ReceiptsAndProducts { get; set; }
        public DbSet<ReceiptEntity> Receipts { get; set; }
        public DbSet<StatusEntity> Statuses { get; set; }
        public DbSet<SupplierAndProductEntity> SuppliersAndProducts { get; set; }
        public DbSet<SupplierEntity> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=medicalorderprocessingsystem;Trusted_Connection=True;MultipleActiveResultSets=true;");
            }
        }


    }


}
