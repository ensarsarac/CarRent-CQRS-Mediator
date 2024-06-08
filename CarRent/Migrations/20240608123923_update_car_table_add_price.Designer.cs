﻿// <auto-generated />
using System;
using CarRent.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarRent.Migrations
{
    [DbContext(typeof(CarRentContext))]
    [Migration("20240608123923_update_car_table_add_price")]
    partial class update_car_table_add_price
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.31")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CarRent.DAL.Entity.Brand", b =>
                {
                    b.Property<int>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BrandId"), 1L, 1);

                    b.Property<string>("BrandTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BrandId");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("CarRent.DAL.Entity.Car", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarId"), 1L, 1);

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Door")
                        .HasColumnType("int");

                    b.Property<string>("Fuel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Km")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<int>("Luggage")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Passanger")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Seat")
                        .HasColumnType("int");

                    b.Property<string>("Transmission")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("CarId");

                    b.HasIndex("BrandId");

                    b.HasIndex("LocationId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CarRent.DAL.Entity.CarReservation", b =>
                {
                    b.Property<int>("CarReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarReservationId"), 1L, 1);

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DropCarDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DropCarId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TakeCarDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TakeCarId")
                        .HasColumnType("int");

                    b.HasKey("CarReservationId");

                    b.HasIndex("CarId");

                    b.HasIndex("DropCarId");

                    b.HasIndex("TakeCarId");

                    b.ToTable("CarReservations");
                });

            modelBuilder.Entity("CarRent.DAL.Entity.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LocationId"), 1L, 1);

                    b.Property<string>("LocationTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocationId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("CarRent.DAL.Entity.Car", b =>
                {
                    b.HasOne("CarRent.DAL.Entity.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarRent.DAL.Entity.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("CarRent.DAL.Entity.CarReservation", b =>
                {
                    b.HasOne("CarRent.DAL.Entity.Car", "Car")
                        .WithMany("CarReservations")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarRent.DAL.Entity.Location", "DropCarLocation")
                        .WithMany("DropCarLocations")
                        .HasForeignKey("DropCarId")
                        .IsRequired();

                    b.HasOne("CarRent.DAL.Entity.Location", "TakeCarLocation")
                        .WithMany("TakeCarLocations")
                        .HasForeignKey("TakeCarId")
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("DropCarLocation");

                    b.Navigation("TakeCarLocation");
                });

            modelBuilder.Entity("CarRent.DAL.Entity.Car", b =>
                {
                    b.Navigation("CarReservations");
                });

            modelBuilder.Entity("CarRent.DAL.Entity.Location", b =>
                {
                    b.Navigation("DropCarLocations");

                    b.Navigation("TakeCarLocations");
                });
#pragma warning restore 612, 618
        }
    }
}
