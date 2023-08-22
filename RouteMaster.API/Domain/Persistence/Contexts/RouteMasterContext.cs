using EntityFramework.Exceptions.SqlServer;
using Microsoft.EntityFrameworkCore;
using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Domain.Persistence.Contexts
{
    public class RouteMasterContext : DbContext
    {
        public RouteMasterContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Passenger> Passengers { get; set; } = null!;
        public DbSet<Administrator> Administrators { get; set; } = null!;
        public DbSet<AuditLog> AuditLogs { get; set; } = null!;
        public DbSet<Address> Addresses { get; set; } = null!;
        public DbSet<Country> Countries { get; set; } = null!;
        public DbSet<Department> Departments { get; set; } = null!;
        public DbSet<District> Districts { get; set; } = null!;
        public DbSet<Province> Provinces { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseExceptionProcessor();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //User

            modelBuilder.Entity<User>().ToTable("User");

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasAlternateKey(u => u.Email);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Account)
                .WithOne(a => a.User)
                .HasForeignKey<Account>(a => a.UserId);

            //Account

            modelBuilder.Entity<Account>()
                .HasDiscriminator(u => u.AccountType)
                .HasValue<Administrator>(AccountTypes.Administrator)
                .HasValue<Passenger>(AccountTypes.Passenger);

            //Pasenger

            modelBuilder.Entity<Passenger>().ToTable("Account");

            modelBuilder.Entity<Passenger>()
                .HasOne(p => p.Address)
                .WithOne(p => p.Passenger)
                .HasForeignKey<Address>();

            modelBuilder.Entity<Passenger>()
                .HasOne(p => p.AuditLog)
                .WithOne(p => p.Passenger)
                .HasForeignKey<AuditLog>();

            //Administrator

            modelBuilder.Entity<Administrator>().ToTable("Account");

            //AuditLog

            modelBuilder.Entity<AuditLog>().ToTable("AuditLog");

            modelBuilder.Entity<AuditLog>();

            modelBuilder.Entity<Address>().ToTable("Address");

            //Address

            modelBuilder.Entity<Address>()
                .HasOne(a => a.District)
                .WithMany(d => d.Addresses)
                .HasForeignKey(a => new { a.CountryId, a.DepartmentId, a.ProvinceId, a.DistrictId });

            //Country

            modelBuilder.Entity<Country>().ToTable("Country");

            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    CountryId = 1,
                    Name = "Perú",
                    IsActive = true
                });

            //Department

            modelBuilder.Entity<Department>().ToTable("Department");

            modelBuilder.Entity<Department>()
                .HasKey(d => new { d.CountryId, d.DepartmentId });

            modelBuilder.Entity<Department>()
                .HasOne(d => d.Country)
                .WithMany(c => c.Departments)
                .HasForeignKey(d => d.CountryId);

            modelBuilder.Entity<Department>().HasData(
                new Department
                {
                    CountryId = 1,
                    DepartmentId = 1,
                    Name = "Lima",
                    IsActive = true
                });

            //Province

            modelBuilder.Entity<Province>().ToTable("Province");

            modelBuilder.Entity<Province>()
                .HasKey(p => new { p.CountryId, p.DepartmentId, p.ProvinceId });

            modelBuilder.Entity<Province>()
                .HasOne(d => d.Department)
                .WithMany(c => c.Provinces)
                .HasForeignKey(d => new { d.CountryId, d.DepartmentId });

            modelBuilder.Entity<Province>().HasData(
                new Province
                {
                    CountryId = 1,
                    DepartmentId = 1,
                    ProvinceId = 1,
                    Name = "Lima Metropolitana",
                    IsActive = true
                },
                new Province
                {
                    CountryId = 1,
                    DepartmentId = 1,
                    ProvinceId = 2,
                    Name = "Callao",
                    IsActive = true
                });

            //District

            modelBuilder.Entity<District>().ToTable("District");

            modelBuilder.Entity<District>()
                .HasKey(d => new { d.CountryId, d.DepartmentId, d.ProvinceId, d.DistrictId });

            modelBuilder.Entity<District>()
                .HasOne(d => d.Province)
                .WithMany(c => c.Districts)
                .HasForeignKey(d => new { d.CountryId, d.DepartmentId, d.ProvinceId });

            modelBuilder.Entity<District>().HasData(
                new District
                {
                    CountryId = 1,
                    DepartmentId = 1,
                    ProvinceId = 1,
                    DistrictId = 1,
                    Name = "Ancón",
                    IsActive = true
                },
                new District
                {
                    CountryId = 1,
                    DepartmentId = 1,
                    ProvinceId = 1,
                    DistrictId = 2,
                    Name = "Ate",
                    IsActive = true
                },
                new District
                {
                    CountryId = 1,
                    DepartmentId = 1,
                    ProvinceId = 1,
                    DistrictId = 3,
                    Name = "Barranco",
                    IsActive = true
                },
                new District
                {
                    CountryId = 1,
                    DepartmentId = 1,
                    ProvinceId = 1,
                    DistrictId = 4,
                    Name = "Breña",
                    IsActive = true
                },
                new District
                {
                    CountryId = 1,
                    DepartmentId = 1,
                    ProvinceId = 1,
                    DistrictId = 5,
                    Name = "Carabayllo",
                    IsActive = true
                },
                new District
                {
                    CountryId = 1,
                    DepartmentId = 1,
                    ProvinceId = 1,
                    DistrictId = 6,
                    Name = "Chaclacayo",
                    IsActive = true
                },
                new District
                {
                    CountryId = 1,
                    DepartmentId = 1,
                    ProvinceId = 1,
                    DistrictId = 7,
                    Name = "Chorrillos",
                    IsActive = true
                },
                new District
                {
                    CountryId = 1,
                    DepartmentId = 1,
                    ProvinceId = 1,
                    DistrictId = 8,
                    Name = "Cieneguilla",
                    IsActive = true
                },
                new District
                {
                    CountryId = 1,
                    DepartmentId = 1,
                    ProvinceId = 1,
                    DistrictId = 9,
                    Name = "Comas",
                    IsActive = true
                },
                new District
                {
                    CountryId = 1,
                    DepartmentId = 1,
                    ProvinceId = 1,
                    DistrictId = 10,
                    Name = "El Agustino",
                    IsActive = true
                },
                new District
                {
                    CountryId = 1,
                    DepartmentId = 1,
                    ProvinceId = 1,
                    DistrictId = 11,
                    Name = "Independencia",
                    IsActive = true
                },
                new District
                {
                    CountryId = 1,
                    DepartmentId = 1,
                    ProvinceId = 1,
                    DistrictId = 12,
                    Name = "Jesús María",
                    IsActive = true
                },
                new District
                {
                    CountryId = 1,
                    DepartmentId = 1,
                    ProvinceId = 1,
                    DistrictId = 13,
                    Name = "La Molina",
                    IsActive = true
                },
                new District
                {
                    CountryId = 1,
                    DepartmentId = 1,
                    ProvinceId = 1,
                    DistrictId = 14,
                    Name = "La Victoria",
                    IsActive = true
                },
                new District
                {
                    CountryId = 1,
                    DepartmentId = 1,
                    ProvinceId = 1,
                    DistrictId = 15,
                    Name = "Lima",
                    IsActive = true
                },
                new District
                {
                    CountryId = 1,
                    DepartmentId = 1,
                    ProvinceId = 1,
                    DistrictId = 16,
                    Name = "Lince",
                    IsActive = true
                },
                new District
                {
                    CountryId = 1,
                    DepartmentId = 1,
                    ProvinceId = 1,
                    DistrictId = 17,
                    Name = "Los Olivos",
                    IsActive = true
                },
                new District
                {
                    CountryId = 1,
                    DepartmentId = 1,
                    ProvinceId = 1,
                    DistrictId = 18,
                    Name = "Lurigancho",
                    IsActive = true
                },
                new District
                {
                    CountryId = 1,
                    DepartmentId = 1,
                    ProvinceId = 1,
                    DistrictId = 19,
                    Name = "Lurín",
                    IsActive = true
                },
                new District
                {
                    CountryId = 1,
                    DepartmentId = 1,
                    ProvinceId = 1,
                    DistrictId = 20,
                    Name = "Magdalena del Mar",
                    IsActive = true
                },
                new District
                {
                    CountryId = 1,
                    DepartmentId = 1,
                    ProvinceId = 1,
                    DistrictId = 21,
                    Name = "Miraflores",
                    IsActive = true
                },
                new District
                {
                    CountryId = 1,
                    DepartmentId = 1,
                    ProvinceId = 1,
                    DistrictId = 22,
                    Name = "Pachacámac",
                    IsActive = true
                },
                new District
                {
                    CountryId = 1,
                    DepartmentId = 1,
                    ProvinceId = 1,
                    DistrictId = 23,
                    Name = "Pucusana",
                    IsActive = true
                },
                new District
                {
                    CountryId = 1,
                    DepartmentId = 1,
                    ProvinceId = 1,
                    DistrictId = 24,
                    Name = "Pueblo Libre",
                    IsActive = true
                },
                new District
                {
                    CountryId = 1,
                    DepartmentId = 1,
                    ProvinceId = 1,
                    DistrictId = 25,
                    Name = "Puente Piedra",
                    IsActive = true
                },
                new District
                {
                    CountryId = 1,
                    DepartmentId = 1,
                    ProvinceId = 1,
                    DistrictId = 26,
                    Name = "Punta Hermosa",
                    IsActive = true
                },
                new District
                {
                    CountryId = 1,
                    DepartmentId = 1,
                    ProvinceId = 1,
                    DistrictId = 27,
                    Name = "Punta Negra",
                    IsActive = true
                },
                new District
                {
                    CountryId = 1,
                    DepartmentId = 1,
                    ProvinceId = 1,
                    DistrictId = 28,
                    Name = "Rímac",
                    IsActive = true
                },
                new District
                {
                    CountryId = 1,
                    DepartmentId = 1,
                    ProvinceId = 1,
                    DistrictId = 29,
                    Name = "San Bartolo",
                    IsActive = true
                },
                new District
                {
                    CountryId = 1,
                    DepartmentId = 1,
                    ProvinceId = 1,
                    DistrictId = 30,
                    Name = "San Borja",
                    IsActive = true
                },
                new District
                {
                    CountryId = 1,
                    DepartmentId = 1,
                    ProvinceId = 1,
                    DistrictId = 31,
                    Name = "San Isidro",
                    IsActive = true
                },
                new District
                {
                    CountryId = 1,
                    DepartmentId = 1,
                    ProvinceId = 1,
                    DistrictId = 32,
                    Name = "San Juan de Lurigancho",
                    IsActive = true
                },
                new District
                {
                    CountryId = 1,
                    DepartmentId = 1,
                    ProvinceId = 1,
                    DistrictId = 33,
                    Name = "San Juan de Miraflores",
                    IsActive = true
                },
                new District
                {
                    CountryId = 1,
                    DepartmentId = 1,
                    ProvinceId = 1,
                    DistrictId = 34,
                    Name = "San Luis",
                    IsActive = true
                },
                new District
                {
                    CountryId = 1,
                    DepartmentId = 1,
                    ProvinceId = 1,
                    DistrictId = 35,
                    Name = "San Martín de Porres",
                    IsActive = true
                },
                new District
                {
                    CountryId = 1,
                    DepartmentId = 1,
                    ProvinceId = 1,
                    DistrictId = 36,
                    Name = "San Miguel",
                    IsActive = true
                },
                new District
                {
                    CountryId = 1,
                    DepartmentId = 1,
                    ProvinceId = 1,
                    DistrictId = 37,
                    Name = "Santa Anita",
                    IsActive = true
                },
                new District
                {
                    CountryId = 1,
                    DepartmentId = 1,
                    ProvinceId = 1,
                    DistrictId = 38,
                    Name = "Santa María del Mar",
                    IsActive = true
                },
                new District
                {
                    CountryId = 1,
                    DepartmentId = 1,
                    ProvinceId = 1,
                    DistrictId = 39,
                    Name = "Santa Rosa",
                    IsActive = true
                },
                new District
                {
                    CountryId = 1,
                    DepartmentId = 1,
                    ProvinceId = 1,
                    DistrictId = 40,
                    Name = "Santiago de Surco",
                    IsActive = true
                },
                new District
                {
                    CountryId = 1,
                    DepartmentId = 1,
                    ProvinceId = 1,
                    DistrictId = 41,
                    Name = "Surquillo",
                    IsActive = true
                },
                new District
                {
                    CountryId = 1,
                    DepartmentId = 1,
                    ProvinceId = 1,
                    DistrictId = 42,
                    Name = "Villa El Salvador",
                    IsActive = true
                },
                new District
                {
                    CountryId = 1,
                    DepartmentId = 1,
                    ProvinceId = 1,
                    DistrictId = 43,
                    Name = "Villa María del Triunfo",
                    IsActive = true
                },
                new District
                {
                    CountryId = 1,
                    DepartmentId = 1,
                    ProvinceId = 2,
                    DistrictId = 1,
                    Name = "Bellavista",
                    IsActive = true
                },
                new District
                {
                    CountryId = 1,
                    DepartmentId = 1,
                    ProvinceId = 2,
                    DistrictId = 2,
                    Name = "Callao",
                    IsActive = true
                },
                new District
                {
                    CountryId = 1,
                    DepartmentId = 1,
                    ProvinceId = 2,
                    DistrictId = 3,
                    Name = "Carmen de La Legua",
                    IsActive = true
                },
                new District
                {
                    CountryId = 1,
                    DepartmentId = 1,
                    ProvinceId = 2,
                    DistrictId = 4,
                    Name = "La Perla",
                    IsActive = true
                },
                new District
                {
                    CountryId = 1,
                    DepartmentId = 1,
                    ProvinceId = 2,
                    DistrictId = 5,
                    Name = "La Punta",
                    IsActive = true
                },
                new District
                {
                    CountryId = 1,
                    DepartmentId = 1,
                    ProvinceId = 2,
                    DistrictId = 6,
                    Name = "Mi Perú",
                    IsActive = true
                },
                new District
                {
                    CountryId = 1,
                    DepartmentId = 1,
                    ProvinceId = 2,
                    DistrictId = 7,
                    Name = "Ventanilla",
                    IsActive = true
                });

        }
    }
}
