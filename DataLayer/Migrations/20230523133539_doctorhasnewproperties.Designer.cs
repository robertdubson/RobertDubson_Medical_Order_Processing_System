﻿// <auto-generated />
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataLayer.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230523133539_doctorhasnewproperties")]
    partial class doctorhasnewproperties
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            //modelBuilder
            //    .HasAnnotation("ProductVersion", "3.1.0")
            //    .HasAnnotation("Relational:MaxIdentifierLength", 128)
            //    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            //modelBuilder.Entity("DataModel.AdministratorEntity", b =>
            //    {
            //        b.Property<int>("ID")
            //            .ValueGeneratedOnAdd()
            //            .HasColumnType("int")
            //            .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            //        b.Property<string>("ClientName")
            //            .HasColumnType("nvarchar(max)");

            //        b.Property<string>("EMail")
            //            .HasColumnType("nvarchar(max)");

            //        b.Property<int>("LocationID")
            //            .HasColumnType("int");

            //        b.Property<string>("PasswordHash")
            //            .HasColumnType("nvarchar(max)");

            //        b.Property<string>("Phone")
            //            .HasColumnType("nvarchar(max)");

            //        b.Property<string>("UserName")
            //            .HasColumnType("nvarchar(max)");

            //        b.HasKey("ID");

            //        b.ToTable("Administrators");
            //    });

            //modelBuilder.Entity("DataModel.CityEntity", b =>
            //    {
            //        b.Property<int>("ID")
            //            .ValueGeneratedOnAdd()
            //            .HasColumnType("int")
            //            .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            //        b.Property<string>("CityName")
            //            .HasColumnType("nvarchar(max)");

            //        b.Property<double>("CoordinateX")
            //            .HasColumnType("float");

            //        b.Property<double>("CoordinateY")
            //            .HasColumnType("float");

            //        b.HasKey("ID");

            //        b.ToTable("Cities");
            //    });

            //modelBuilder.Entity("DataModel.ClientEntity", b =>
            //    {
            //        b.Property<int>("ID")
            //            .ValueGeneratedOnAdd()
            //            .HasColumnType("int")
            //            .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            //        b.Property<string>("ClientName")
            //            .HasColumnType("nvarchar(max)");

            //        b.Property<string>("EMail")
            //            .HasColumnType("nvarchar(max)");

            //        b.Property<int>("LocationID")
            //            .HasColumnType("int");

            //        b.Property<string>("PasswordHash")
            //            .HasColumnType("nvarchar(max)");

            //        b.Property<string>("Phone")
            //            .HasColumnType("nvarchar(max)");

            //        b.Property<string>("UserName")
            //            .HasColumnType("nvarchar(max)");

            //        b.HasKey("ID");

            //        b.ToTable("Clients");
            //    });

            //modelBuilder.Entity("DataModel.DeliveryCompanyAndCityEntity", b =>
            //    {
            //        b.Property<int>("ID")
            //            .ValueGeneratedOnAdd()
            //            .HasColumnType("int")
            //            .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            //        b.Property<int>("AvailableCouriers")
            //            .HasColumnType("int");

            //        b.Property<int>("CityID")
            //            .HasColumnType("int");

            //        b.Property<int>("CompanyID")
            //            .HasColumnType("int");

            //        b.HasKey("ID");

            //        b.ToTable("CompaniesAndCities");
            //    });

            //modelBuilder.Entity("DataModel.DeliveryCompanyEntity", b =>
            //    {
            //        b.Property<int>("ID")
            //            .ValueGeneratedOnAdd()
            //            .HasColumnType("int")
            //            .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            //        b.Property<string>("Name")
            //            .HasColumnType("nvarchar(max)");

            //        b.Property<double>("PriceForKm")
            //            .HasColumnType("float");

            //        b.HasKey("ID");

            //        b.ToTable("Companies");
            //    });

            //modelBuilder.Entity("DataModel.DoctorEntity", b =>
            //    {
            //        b.Property<int>("ID")
            //            .ValueGeneratedOnAdd()
            //            .HasColumnType("int")
            //            .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            //        b.Property<string>("EMail")
            //            .HasColumnType("nvarchar(max)");

            //        b.Property<int>("LocationID")
            //            .HasColumnType("int");

            //        b.Property<string>("Name")
            //            .HasColumnType("nvarchar(max)");

            //        b.Property<string>("PasswordHash")
            //            .HasColumnType("nvarchar(max)");

            //        b.Property<string>("Phone")
            //            .HasColumnType("nvarchar(max)");

            //        b.Property<string>("UserName")
            //            .HasColumnType("nvarchar(max)");

            //        b.HasKey("ID");

            //        b.ToTable("Doctors");
            //    });

            //modelBuilder.Entity("DataModel.FactoryEntity", b =>
            //    {
            //        b.Property<int>("ID")
            //            .ValueGeneratedOnAdd()
            //            .HasColumnType("int")
            //            .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            //        b.Property<string>("Address")
            //            .HasColumnType("nvarchar(max)");

            //        b.Property<int>("CityID")
            //            .HasColumnType("int");

            //        b.Property<int>("CompanyID")
            //            .HasColumnType("int");

            //        b.HasKey("ID");

            //        b.ToTable("Factories");
            //    });

            //modelBuilder.Entity("DataModel.IssuePointEntity", b =>
            //    {
            //        b.Property<int>("ID")
            //            .ValueGeneratedOnAdd()
            //            .HasColumnType("int")
            //            .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            //        b.Property<string>("Address")
            //            .HasColumnType("nvarchar(max)");

            //        b.Property<int>("CityID")
            //            .HasColumnType("int");

            //        b.HasKey("ID");

            //        b.ToTable("IssuePoints");
            //    });

            //modelBuilder.Entity("DataModel.MedicalProductEntity", b =>
            //    {
            //        b.Property<int>("ID")
            //            .ValueGeneratedOnAdd()
            //            .HasColumnType("int")
            //            .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            //        b.Property<string>("Description")
            //            .HasColumnType("nvarchar(max)");

            //        b.Property<string>("InstructionToUse")
            //            .HasColumnType("nvarchar(max)");

            //        b.Property<string>("ProductName")
            //            .HasColumnType("nvarchar(max)");

            //        b.HasKey("ID");

            //        b.ToTable("MedicalProducts");
            //    });

            //modelBuilder.Entity("DataModel.ProductAndFactoryEntity", b =>
            //    {
            //        b.Property<int>("ID")
            //            .ValueGeneratedOnAdd()
            //            .HasColumnType("int")
            //            .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            //        b.Property<int>("FactoryID")
            //            .HasColumnType("int");

            //        b.Property<int>("ProductID")
            //            .HasColumnType("int");

            //        b.Property<int>("UnitsInStorage")
            //            .HasColumnType("int");

            //        b.HasKey("ID");

            //        b.ToTable("ProductsAndFactories");
            //    });

            //modelBuilder.Entity("DataModel.ReceiptAndProductEntity", b =>
            //    {
            //        b.Property<int>("ID")
            //            .ValueGeneratedOnAdd()
            //            .HasColumnType("int")
            //            .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            //        b.Property<int>("CityID")
            //            .HasColumnType("int");

            //        b.Property<int>("DeliveryCompanyID")
            //            .HasColumnType("int");

            //        b.Property<int>("FactoryID")
            //            .HasColumnType("int");

            //        b.Property<int>("ProductID")
            //            .HasColumnType("int");

            //        b.Property<int>("ReceiptID")
            //            .HasColumnType("int");

            //        b.HasKey("ID");

            //        b.ToTable("ReceiptsAndProducts");
            //    });

            //modelBuilder.Entity("DataModel.ReceiptEntity", b =>
            //    {
            //        b.Property<int>("ID")
            //            .ValueGeneratedOnAdd()
            //            .HasColumnType("int")
            //            .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            //        b.Property<string>("AppointmentReview")
            //            .HasColumnType("nvarchar(max)");

            //        b.Property<int>("AuthorID")
            //            .HasColumnType("int");

            //        b.Property<int>("ClientID")
            //            .HasColumnType("int");

            //        b.Property<double>("Cost")
            //            .HasColumnType("float");

            //        b.Property<string>("CreationDate")
            //            .HasColumnType("nvarchar(max)");

            //        b.Property<int>("DestinationCityID")
            //            .HasColumnType("int");

            //        b.Property<int>("OrderStatusID")
            //            .HasColumnType("int");

            //        b.Property<bool>("ShipToTheIssuePoint")
            //            .HasColumnType("bit");

            //        b.HasKey("ID");

            //        b.ToTable("Receipts");
            //    });

            //modelBuilder.Entity("DataModel.StatusEntity", b =>
            //    {
            //        b.Property<int>("ID")
            //            .ValueGeneratedOnAdd()
            //            .HasColumnType("int")
            //            .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            //        b.Property<string>("StatusName")
            //            .HasColumnType("nvarchar(max)");

            //        b.HasKey("ID");

            //        b.ToTable("Statuses");
            //    });

            //modelBuilder.Entity("DataModel.SupplierAndProductEntity", b =>
            //    {
            //        b.Property<int>("ID")
            //            .ValueGeneratedOnAdd()
            //            .HasColumnType("int")
            //            .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            //        b.Property<double>("Price")
            //            .HasColumnType("float");

            //        b.Property<int>("ProductID")
            //            .HasColumnType("int");

            //        b.Property<int>("SupplierID")
            //            .HasColumnType("int");

            //        b.HasKey("ID");

            //        b.ToTable("SuppliersAndProducts");
            //    });

            //modelBuilder.Entity("DataModel.SupplierEntity", b =>
            //    {
            //        b.Property<int>("ID")
            //            .ValueGeneratedOnAdd()
            //            .HasColumnType("int")
            //            .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            //        b.Property<string>("Name")
            //            .HasColumnType("nvarchar(max)");

            //        b.HasKey("ID");

            //        b.ToTable("Suppliers");
            //    });
#pragma warning restore 612, 618
        }
    }
}
