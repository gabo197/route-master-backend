﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RouteMaster.API.Domain.Persistence.Contexts;

#nullable disable

namespace RouteMaster.API.Migrations
{
    [DbContext(typeof(RouteMasterContext))]
    [Migration("20230818015823_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RouteMaster.API.Models.Account", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("AccountType")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Account");

                    b.HasDiscriminator<int>("AccountType");
                });

            modelBuilder.Entity("RouteMaster.API.Models.Address", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int>("DistrictId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("ProvinceId")
                        .HasColumnType("int");

                    b.Property<string>("StreetLine1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetLine2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("CountryId", "DepartmentId", "ProvinceId", "DistrictId");

                    b.ToTable("Address", (string)null);
                });

            modelBuilder.Entity("RouteMaster.API.Models.AuditLog", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastLogin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastLogout")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId");

                    b.ToTable("AuditLog", (string)null);
                });

            modelBuilder.Entity("RouteMaster.API.Models.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CountryId"), 1L, 1);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryId");

                    b.ToTable("Country", (string)null);
                });

            modelBuilder.Entity("RouteMaster.API.Models.Department", b =>
                {
                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryId", "DepartmentId");

                    b.ToTable("Department", (string)null);
                });

            modelBuilder.Entity("RouteMaster.API.Models.District", b =>
                {
                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int>("ProvinceId")
                        .HasColumnType("int");

                    b.Property<int>("DistrictId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryId", "DepartmentId", "ProvinceId", "DistrictId");

                    b.ToTable("District", (string)null);
                });

            modelBuilder.Entity("RouteMaster.API.Models.Province", b =>
                {
                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int>("ProvinceId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryId", "DepartmentId", "ProvinceId");

                    b.ToTable("Province", (string)null);
                });

            modelBuilder.Entity("RouteMaster.API.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RouteMaster.API.Models.Administrator", b =>
                {
                    b.HasBaseType("RouteMaster.API.Models.Account");

                    b.ToTable("Account", (string)null);

                    b.HasDiscriminator().HasValue(0);
                });

            modelBuilder.Entity("RouteMaster.API.Models.Passenger", b =>
                {
                    b.HasBaseType("RouteMaster.API.Models.Account");

                    b.Property<int>("PaymentMethodId")
                        .HasColumnType("int");

                    b.ToTable("Account", (string)null);

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("RouteMaster.API.Models.Account", b =>
                {
                    b.HasOne("RouteMaster.API.Models.User", "User")
                        .WithOne("Account")
                        .HasForeignKey("RouteMaster.API.Models.Account", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("RouteMaster.API.Models.Address", b =>
                {
                    b.HasOne("RouteMaster.API.Models.Passenger", "Passenger")
                        .WithOne("Address")
                        .HasForeignKey("RouteMaster.API.Models.Address", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RouteMaster.API.Models.District", "District")
                        .WithMany("Addresses")
                        .HasForeignKey("CountryId", "DepartmentId", "ProvinceId", "DistrictId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("District");

                    b.Navigation("Passenger");
                });

            modelBuilder.Entity("RouteMaster.API.Models.AuditLog", b =>
                {
                    b.HasOne("RouteMaster.API.Models.Passenger", "Passenger")
                        .WithOne("AuditLog")
                        .HasForeignKey("RouteMaster.API.Models.AuditLog", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Passenger");
                });

            modelBuilder.Entity("RouteMaster.API.Models.Department", b =>
                {
                    b.HasOne("RouteMaster.API.Models.Country", "Country")
                        .WithMany("Departments")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("RouteMaster.API.Models.District", b =>
                {
                    b.HasOne("RouteMaster.API.Models.Province", "Province")
                        .WithMany("Districts")
                        .HasForeignKey("CountryId", "DepartmentId", "ProvinceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Province");
                });

            modelBuilder.Entity("RouteMaster.API.Models.Province", b =>
                {
                    b.HasOne("RouteMaster.API.Models.Department", "Department")
                        .WithMany("Provinces")
                        .HasForeignKey("CountryId", "DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("RouteMaster.API.Models.Country", b =>
                {
                    b.Navigation("Departments");
                });

            modelBuilder.Entity("RouteMaster.API.Models.Department", b =>
                {
                    b.Navigation("Provinces");
                });

            modelBuilder.Entity("RouteMaster.API.Models.District", b =>
                {
                    b.Navigation("Addresses");
                });

            modelBuilder.Entity("RouteMaster.API.Models.Province", b =>
                {
                    b.Navigation("Districts");
                });

            modelBuilder.Entity("RouteMaster.API.Models.User", b =>
                {
                    b.Navigation("Account")
                        .IsRequired();
                });

            modelBuilder.Entity("RouteMaster.API.Models.Passenger", b =>
                {
                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("AuditLog")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
