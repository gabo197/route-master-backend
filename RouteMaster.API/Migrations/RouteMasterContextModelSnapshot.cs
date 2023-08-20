﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RouteMaster.API.Domain.Persistence.Contexts;

#nullable disable

namespace RouteMaster.API.Migrations
{
    [DbContext(typeof(RouteMasterContext))]
    partial class RouteMasterContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RouteMaster.API.Domain.Models.Account", b =>
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

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Account");

                    b.HasDiscriminator<int>("AccountType");
                });

            modelBuilder.Entity("RouteMaster.API.Domain.Models.Address", b =>
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

            modelBuilder.Entity("RouteMaster.API.Domain.Models.AuditLog", b =>
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

            modelBuilder.Entity("RouteMaster.API.Domain.Models.Country", b =>
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

                    b.HasData(
                        new
                        {
                            CountryId = 1,
                            IsActive = true,
                            Name = "Perú"
                        });
                });

            modelBuilder.Entity("RouteMaster.API.Domain.Models.Department", b =>
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

                    b.HasData(
                        new
                        {
                            CountryId = 1,
                            DepartmentId = 1,
                            IsActive = true,
                            Name = "Lima"
                        });
                });

            modelBuilder.Entity("RouteMaster.API.Domain.Models.District", b =>
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

                    b.HasData(
                        new
                        {
                            CountryId = 1,
                            DepartmentId = 1,
                            ProvinceId = 1,
                            DistrictId = 1,
                            IsActive = true,
                            Name = "Ancón"
                        },
                        new
                        {
                            CountryId = 1,
                            DepartmentId = 1,
                            ProvinceId = 1,
                            DistrictId = 2,
                            IsActive = true,
                            Name = "Ate"
                        },
                        new
                        {
                            CountryId = 1,
                            DepartmentId = 1,
                            ProvinceId = 1,
                            DistrictId = 3,
                            IsActive = true,
                            Name = "Barranco"
                        },
                        new
                        {
                            CountryId = 1,
                            DepartmentId = 1,
                            ProvinceId = 1,
                            DistrictId = 4,
                            IsActive = true,
                            Name = "Breña"
                        },
                        new
                        {
                            CountryId = 1,
                            DepartmentId = 1,
                            ProvinceId = 1,
                            DistrictId = 5,
                            IsActive = true,
                            Name = "Carabayllo"
                        },
                        new
                        {
                            CountryId = 1,
                            DepartmentId = 1,
                            ProvinceId = 1,
                            DistrictId = 6,
                            IsActive = true,
                            Name = "Chaclacayo"
                        },
                        new
                        {
                            CountryId = 1,
                            DepartmentId = 1,
                            ProvinceId = 1,
                            DistrictId = 7,
                            IsActive = true,
                            Name = "Chorrillos"
                        },
                        new
                        {
                            CountryId = 1,
                            DepartmentId = 1,
                            ProvinceId = 1,
                            DistrictId = 8,
                            IsActive = true,
                            Name = "Cieneguilla"
                        },
                        new
                        {
                            CountryId = 1,
                            DepartmentId = 1,
                            ProvinceId = 1,
                            DistrictId = 9,
                            IsActive = true,
                            Name = "Comas"
                        },
                        new
                        {
                            CountryId = 1,
                            DepartmentId = 1,
                            ProvinceId = 1,
                            DistrictId = 10,
                            IsActive = true,
                            Name = "El Agustino"
                        },
                        new
                        {
                            CountryId = 1,
                            DepartmentId = 1,
                            ProvinceId = 1,
                            DistrictId = 11,
                            IsActive = true,
                            Name = "Independencia"
                        },
                        new
                        {
                            CountryId = 1,
                            DepartmentId = 1,
                            ProvinceId = 1,
                            DistrictId = 12,
                            IsActive = true,
                            Name = "Jesús María"
                        },
                        new
                        {
                            CountryId = 1,
                            DepartmentId = 1,
                            ProvinceId = 1,
                            DistrictId = 13,
                            IsActive = true,
                            Name = "La Molina"
                        },
                        new
                        {
                            CountryId = 1,
                            DepartmentId = 1,
                            ProvinceId = 1,
                            DistrictId = 14,
                            IsActive = true,
                            Name = "La Victoria"
                        },
                        new
                        {
                            CountryId = 1,
                            DepartmentId = 1,
                            ProvinceId = 1,
                            DistrictId = 15,
                            IsActive = true,
                            Name = "Lima"
                        },
                        new
                        {
                            CountryId = 1,
                            DepartmentId = 1,
                            ProvinceId = 1,
                            DistrictId = 16,
                            IsActive = true,
                            Name = "Lince"
                        },
                        new
                        {
                            CountryId = 1,
                            DepartmentId = 1,
                            ProvinceId = 1,
                            DistrictId = 17,
                            IsActive = true,
                            Name = "Los Olivos"
                        },
                        new
                        {
                            CountryId = 1,
                            DepartmentId = 1,
                            ProvinceId = 1,
                            DistrictId = 18,
                            IsActive = true,
                            Name = "Lurigancho"
                        },
                        new
                        {
                            CountryId = 1,
                            DepartmentId = 1,
                            ProvinceId = 1,
                            DistrictId = 19,
                            IsActive = true,
                            Name = "Lurín"
                        },
                        new
                        {
                            CountryId = 1,
                            DepartmentId = 1,
                            ProvinceId = 1,
                            DistrictId = 20,
                            IsActive = true,
                            Name = "Magdalena del Mar"
                        },
                        new
                        {
                            CountryId = 1,
                            DepartmentId = 1,
                            ProvinceId = 1,
                            DistrictId = 21,
                            IsActive = true,
                            Name = "Miraflores"
                        },
                        new
                        {
                            CountryId = 1,
                            DepartmentId = 1,
                            ProvinceId = 1,
                            DistrictId = 22,
                            IsActive = true,
                            Name = "Pachacámac"
                        },
                        new
                        {
                            CountryId = 1,
                            DepartmentId = 1,
                            ProvinceId = 1,
                            DistrictId = 23,
                            IsActive = true,
                            Name = "Pucusana"
                        },
                        new
                        {
                            CountryId = 1,
                            DepartmentId = 1,
                            ProvinceId = 1,
                            DistrictId = 24,
                            IsActive = true,
                            Name = "Pueblo Libre"
                        },
                        new
                        {
                            CountryId = 1,
                            DepartmentId = 1,
                            ProvinceId = 1,
                            DistrictId = 25,
                            IsActive = true,
                            Name = "Puente Piedra"
                        },
                        new
                        {
                            CountryId = 1,
                            DepartmentId = 1,
                            ProvinceId = 1,
                            DistrictId = 26,
                            IsActive = true,
                            Name = "Punta Hermosa"
                        },
                        new
                        {
                            CountryId = 1,
                            DepartmentId = 1,
                            ProvinceId = 1,
                            DistrictId = 27,
                            IsActive = true,
                            Name = "Punta Negra"
                        },
                        new
                        {
                            CountryId = 1,
                            DepartmentId = 1,
                            ProvinceId = 1,
                            DistrictId = 28,
                            IsActive = true,
                            Name = "Rímac"
                        },
                        new
                        {
                            CountryId = 1,
                            DepartmentId = 1,
                            ProvinceId = 1,
                            DistrictId = 29,
                            IsActive = true,
                            Name = "San Bartolo"
                        },
                        new
                        {
                            CountryId = 1,
                            DepartmentId = 1,
                            ProvinceId = 1,
                            DistrictId = 30,
                            IsActive = true,
                            Name = "San Borja"
                        },
                        new
                        {
                            CountryId = 1,
                            DepartmentId = 1,
                            ProvinceId = 1,
                            DistrictId = 31,
                            IsActive = true,
                            Name = "San Isidro"
                        },
                        new
                        {
                            CountryId = 1,
                            DepartmentId = 1,
                            ProvinceId = 1,
                            DistrictId = 32,
                            IsActive = true,
                            Name = "San Juan de Lurigancho"
                        },
                        new
                        {
                            CountryId = 1,
                            DepartmentId = 1,
                            ProvinceId = 1,
                            DistrictId = 33,
                            IsActive = true,
                            Name = "San Juan de Miraflores"
                        },
                        new
                        {
                            CountryId = 1,
                            DepartmentId = 1,
                            ProvinceId = 1,
                            DistrictId = 34,
                            IsActive = true,
                            Name = "San Luis"
                        },
                        new
                        {
                            CountryId = 1,
                            DepartmentId = 1,
                            ProvinceId = 1,
                            DistrictId = 35,
                            IsActive = true,
                            Name = "San Martín de Porres"
                        },
                        new
                        {
                            CountryId = 1,
                            DepartmentId = 1,
                            ProvinceId = 1,
                            DistrictId = 36,
                            IsActive = true,
                            Name = "San Miguel"
                        },
                        new
                        {
                            CountryId = 1,
                            DepartmentId = 1,
                            ProvinceId = 1,
                            DistrictId = 37,
                            IsActive = true,
                            Name = "Santa Anita"
                        },
                        new
                        {
                            CountryId = 1,
                            DepartmentId = 1,
                            ProvinceId = 1,
                            DistrictId = 38,
                            IsActive = true,
                            Name = "Santa María del Mar"
                        },
                        new
                        {
                            CountryId = 1,
                            DepartmentId = 1,
                            ProvinceId = 1,
                            DistrictId = 39,
                            IsActive = true,
                            Name = "Santa Rosa"
                        },
                        new
                        {
                            CountryId = 1,
                            DepartmentId = 1,
                            ProvinceId = 1,
                            DistrictId = 40,
                            IsActive = true,
                            Name = "Santiago de Surco"
                        },
                        new
                        {
                            CountryId = 1,
                            DepartmentId = 1,
                            ProvinceId = 1,
                            DistrictId = 41,
                            IsActive = true,
                            Name = "Surquillo"
                        },
                        new
                        {
                            CountryId = 1,
                            DepartmentId = 1,
                            ProvinceId = 1,
                            DistrictId = 42,
                            IsActive = true,
                            Name = "Villa El Salvador"
                        },
                        new
                        {
                            CountryId = 1,
                            DepartmentId = 1,
                            ProvinceId = 1,
                            DistrictId = 43,
                            IsActive = true,
                            Name = "Villa María del Triunfo"
                        },
                        new
                        {
                            CountryId = 1,
                            DepartmentId = 1,
                            ProvinceId = 2,
                            DistrictId = 1,
                            IsActive = true,
                            Name = "Bellavista"
                        },
                        new
                        {
                            CountryId = 1,
                            DepartmentId = 1,
                            ProvinceId = 2,
                            DistrictId = 2,
                            IsActive = true,
                            Name = "Callao"
                        },
                        new
                        {
                            CountryId = 1,
                            DepartmentId = 1,
                            ProvinceId = 2,
                            DistrictId = 3,
                            IsActive = true,
                            Name = "Carmen de La Legua"
                        },
                        new
                        {
                            CountryId = 1,
                            DepartmentId = 1,
                            ProvinceId = 2,
                            DistrictId = 4,
                            IsActive = true,
                            Name = "La Perla"
                        },
                        new
                        {
                            CountryId = 1,
                            DepartmentId = 1,
                            ProvinceId = 2,
                            DistrictId = 5,
                            IsActive = true,
                            Name = "La Punta"
                        },
                        new
                        {
                            CountryId = 1,
                            DepartmentId = 1,
                            ProvinceId = 2,
                            DistrictId = 6,
                            IsActive = true,
                            Name = "Mi Perú"
                        },
                        new
                        {
                            CountryId = 1,
                            DepartmentId = 1,
                            ProvinceId = 2,
                            DistrictId = 7,
                            IsActive = true,
                            Name = "Ventanilla"
                        });
                });

            modelBuilder.Entity("RouteMaster.API.Domain.Models.Province", b =>
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

                    b.HasData(
                        new
                        {
                            CountryId = 1,
                            DepartmentId = 1,
                            ProvinceId = 1,
                            IsActive = true,
                            Name = "Lima Metropolitana"
                        },
                        new
                        {
                            CountryId = 1,
                            DepartmentId = 1,
                            ProvinceId = 2,
                            IsActive = true,
                            Name = "Callao"
                        });
                });

            modelBuilder.Entity("RouteMaster.API.Domain.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasAlternateKey("Email");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RouteMaster.API.Domain.Models.Administrator", b =>
                {
                    b.HasBaseType("RouteMaster.API.Domain.Models.Account");

                    b.ToTable("Account", (string)null);

                    b.HasDiscriminator().HasValue(0);
                });

            modelBuilder.Entity("RouteMaster.API.Domain.Models.Passenger", b =>
                {
                    b.HasBaseType("RouteMaster.API.Domain.Models.Account");

                    b.Property<int>("PaymentMethodId")
                        .HasColumnType("int");

                    b.ToTable("Account", (string)null);

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("RouteMaster.API.Domain.Models.Account", b =>
                {
                    b.HasOne("RouteMaster.API.Domain.Models.User", "User")
                        .WithOne("Account")
                        .HasForeignKey("RouteMaster.API.Domain.Models.Account", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("RouteMaster.API.Domain.Models.Address", b =>
                {
                    b.HasOne("RouteMaster.API.Domain.Models.Passenger", "Passenger")
                        .WithOne("Address")
                        .HasForeignKey("RouteMaster.API.Domain.Models.Address", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RouteMaster.API.Domain.Models.District", "District")
                        .WithMany("Addresses")
                        .HasForeignKey("CountryId", "DepartmentId", "ProvinceId", "DistrictId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("District");

                    b.Navigation("Passenger");
                });

            modelBuilder.Entity("RouteMaster.API.Domain.Models.AuditLog", b =>
                {
                    b.HasOne("RouteMaster.API.Domain.Models.Passenger", "Passenger")
                        .WithOne("AuditLog")
                        .HasForeignKey("RouteMaster.API.Domain.Models.AuditLog", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Passenger");
                });

            modelBuilder.Entity("RouteMaster.API.Domain.Models.Department", b =>
                {
                    b.HasOne("RouteMaster.API.Domain.Models.Country", "Country")
                        .WithMany("Departments")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("RouteMaster.API.Domain.Models.District", b =>
                {
                    b.HasOne("RouteMaster.API.Domain.Models.Province", "Province")
                        .WithMany("Districts")
                        .HasForeignKey("CountryId", "DepartmentId", "ProvinceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Province");
                });

            modelBuilder.Entity("RouteMaster.API.Domain.Models.Province", b =>
                {
                    b.HasOne("RouteMaster.API.Domain.Models.Department", "Department")
                        .WithMany("Provinces")
                        .HasForeignKey("CountryId", "DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("RouteMaster.API.Domain.Models.Country", b =>
                {
                    b.Navigation("Departments");
                });

            modelBuilder.Entity("RouteMaster.API.Domain.Models.Department", b =>
                {
                    b.Navigation("Provinces");
                });

            modelBuilder.Entity("RouteMaster.API.Domain.Models.District", b =>
                {
                    b.Navigation("Addresses");
                });

            modelBuilder.Entity("RouteMaster.API.Domain.Models.Province", b =>
                {
                    b.Navigation("Districts");
                });

            modelBuilder.Entity("RouteMaster.API.Domain.Models.User", b =>
                {
                    b.Navigation("Account")
                        .IsRequired();
                });

            modelBuilder.Entity("RouteMaster.API.Domain.Models.Passenger", b =>
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
