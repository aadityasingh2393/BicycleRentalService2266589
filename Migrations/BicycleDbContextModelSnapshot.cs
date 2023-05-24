﻿// <auto-generated />
using System;
using BicycleRentalSystem.BicycleService.DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BicycleRentalService.Migrations
{
    [DbContext(typeof(BicycleDbContext))]
    partial class BicycleDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BicycleRentalSystem.BicycleService.DataAccessLayer.Models.Bicycle", b =>
                {
                    b.Property<int>("BicycleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BicycleId"), 1L, 1);

                    b.Property<int>("AvailableQuantity")
                        .HasColumnType("int");

                    b.Property<string>("BicycleType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("dateTime");

                    b.Property<decimal>("PurchasePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("RentalPricePerDay")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("RentalPricePerHour")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("RentalPricePerWeek")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("BicycleId");

                    b.ToTable("Bicycle");
                });
#pragma warning restore 612, 618
        }
    }
}
