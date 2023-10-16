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
        public DbSet<AccountType> AccountTypes { get; set; } = null!;
        public DbSet<PaymentMethod> PaymentMethods { get; set; } = null!;
        public DbSet<Passenger> Passengers { get; set; } = null!;
        public DbSet<Administrator> Administrators { get; set; } = null!;
        public DbSet<AuditLog> AuditLogs { get; set; } = null!;
        public DbSet<Address> Addresses { get; set; } = null!;
        public DbSet<Country> Countries { get; set; } = null!;
        public DbSet<Department> Departments { get; set; } = null!;
        public DbSet<District> Districts { get; set; } = null!;
        public DbSet<Province> Provinces { get; set; } = null!;
        public DbSet<Wallet> Wallets { get; set; } = null!;
        public DbSet<Account> Accounts { get; set; } = null!;
        public DbSet<TransactionType> TransactionTypes { get; set; } = null!;
        public DbSet<Transaction> Transactions { get; set; } = null!;
        public DbSet<TransferTransaction> TransferTransactions { get; set; } = null!;
        public DbSet<PaymentTransaction> PaymentTransactions { get; set; } = null!;
        public DbSet<RechargeTransaction> RechargeTransactions { get; set; } = null!;
        public DbSet<Ticket> Tickets { get; set; } = null!;
        public DbSet<BusStop> BusStops { get; set; } = null!;
        public DbSet<BusLine> BusLines { get; set; } = null!;
        public DbSet<BusLineStop> BusLineStops { get; set; } = null!;
        public DbSet<Company> Companies { get; set; } = null!;
        public DbSet<LineType> LineTypes { get; set; } = null!;
        public DbSet<Bus> Buses { get; set; } = null!;
        public DbSet<BusDriver> BusDrivers { get; set; } = null!;
        public DbSet<DocumentType> DocumentTypes { get; set; } = null!;
        public DbSet<Trip> Trips { get; set; } = null!;
        public DbSet<TripDetail> TripDetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseExceptionProcessor();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Bus

            modelBuilder.Entity<Bus>().ToTable("Bus");

            modelBuilder.Entity<Bus>()
                .HasOne(b => b.BusLine)
                .WithMany(bl => bl.Buses)
                .HasForeignKey(b => b.BusLineId);
            
            modelBuilder.Entity<Bus>()
                .Property(b => b.PlateNumber)
                .HasMaxLength(6);
            
            modelBuilder.Entity<Bus>()
                .HasIndex(b => b.PlateNumber)
                .IsUnique();

            modelBuilder.Entity<Bus>()
                .HasAlternateKey(b => b.PlateNumber);

            //Bus Driver

            modelBuilder.Entity<BusDriver>().ToTable("BusDriver");

            modelBuilder.Entity<BusDriver>()
                .HasOne(bd => bd.Bus)
                .WithOne(b => b.BusDriver)
                .HasForeignKey<BusDriver>(b => b.BusId)
                .IsRequired(false); 

            modelBuilder.Entity<BusDriver>()
                .HasOne(bd => bd.DocumentType)
                .WithMany(dt => dt.BusDrivers)
                .HasForeignKey(bd => bd.DocumentTypeId);

            modelBuilder.Entity<BusDriver>()
                .HasIndex(bd => new {bd.DocumentTypeId, bd.DocumentNumber})
                .IsUnique();

            modelBuilder.Entity<BusDriver>()
                .HasAlternateKey(bd => new {bd.DocumentTypeId, bd.DocumentNumber});

            //Bus Line

            modelBuilder.Entity<BusLine>().ToTable("BusLine");

            modelBuilder.Entity<BusLine>()
                .HasOne(bl => bl.Company)
                .WithMany(c => c.BusLines)
                .HasForeignKey(bl => bl.CompanyId);

            modelBuilder.Entity<BusLine>()
                .HasOne(bl => bl.LineType)
                .WithMany(lt => lt.BusLines)
                .HasForeignKey(bl => bl.LineTypeId);

            modelBuilder.Entity<BusLine>()
                .HasMany(bl => bl.BusStops)
                .WithMany(bs => bs.BusLines)
                .UsingEntity<BusLineStop>();

            modelBuilder.Entity<BusLine>()
                .HasIndex(bl => bl.Code)
                .IsUnique();

            modelBuilder.Entity<BusLine>()
                .HasAlternateKey(bl => bl.Code);

            //Bus Stop

            modelBuilder.Entity<BusStop>().ToTable("BusStop");

            //Bus Line Stop

            modelBuilder.Entity<BusLineStop>().ToTable("BusLineStop");

            //Company

            modelBuilder.Entity<Company>().ToTable("Company");

            //Document Type

            modelBuilder.Entity<DocumentType>().ToTable("DocumentType");

            modelBuilder.Entity<DocumentType>().HasData(
                new DocumentType
                {
                    DocumentTypeId = 1,
                    Name = "DNI"
                },
                new DocumentType
                {
                    DocumentTypeId = 2,
                    Name = "Carné de extranjería"
                },
                new DocumentType
                {
                    DocumentTypeId = 3,
                    Name = "Pasaporte"
                });

            //Line Type

            modelBuilder.Entity<LineType>().ToTable("LineType");

            modelBuilder.Entity<LineType>().HasData(
                new LineType
                {
                    LineTypeId = 1,
                    Name = "Autobús"
                },
                new LineType
                {
                    LineTypeId = 2,
                    Name = "Metro"
                },
                new LineType
                {
                    LineTypeId = 3,
                    Name = "Subterráneo"
                });

            //Trip

            //Ticket

            modelBuilder.Entity<Ticket>().ToTable("Ticket");
            modelBuilder.Entity<Ticket>().HasKey(t => t.TicketId);
            modelBuilder.Entity<Ticket>().Property(t => t.TicketId).IsRequired();

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Transaction)
                .WithOne()
                .HasForeignKey<Ticket>(t => t.TransactionId)
                .IsRequired(false);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Passenger)
                .WithMany(u => u.Tickets)
                .HasForeignKey(t => t.UserId)
                .IsRequired();

            //Wallet

            modelBuilder.Entity<Wallet>().ToTable("Wallet");

            modelBuilder.Entity<Wallet>().Property(w => w.Balance).HasColumnType("decimal(5,2)");
            modelBuilder.Entity<Wallet>().ToTable(t=>t.HasCheckConstraint("CK_Wallet_Balance", "Balance <= 500.00"));

            modelBuilder.Entity<Wallet>()
                .HasOne(w => w.Passenger)
                .WithOne(u => u.Wallet)
                .HasForeignKey<Wallet>(w => w.UserId);

            // modelBuilder.Entity<Wallet>()
            //     .HasMany(w => w.Transactions)
            //     .WithOne(t => t.Wallet)
            //     .HasForeignKey(t => t.WalletId);

            //TransactionType

            modelBuilder.Entity<TransactionType>().ToTable("TransactionType");

            modelBuilder.Entity<TransactionType>().HasData(
                new TransactionType
                {
                    TransactionTypeId = 1,
                    Name = "Payment"
                },
                new TransactionType
                {
                    TransactionTypeId = 2,
                    Name = "Recharge"
                },
                new TransactionType
                {
                    TransactionTypeId = 3,
                    Name = "Transfer"
                });

            //Transaction

            modelBuilder.Entity<Transaction>().ToTable("Transaction");

            modelBuilder.Entity<Transaction>().Property(t => t.Amount)
                .HasColumnType("decimal(5,2)");

            modelBuilder.Entity<Transaction>().ToTable(t => t.HasCheckConstraint("CK_Transaction_Amount", "Amount > 0.00"));

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.TransactionType)
                .WithMany(tt => tt.Transactions)
                .HasForeignKey(t => t.TransactionTypeId);

            modelBuilder.Entity<Transaction>()
                .HasDiscriminator(t => t.TransactionTypeId)
                .HasValue<PaymentTransaction>(1)
                .HasValue<RechargeTransaction>(2)
                .HasValue<TransferTransaction>(3);

            //PaymentTransaction

            modelBuilder.Entity<PaymentTransaction>().ToTable("Transaction");

            modelBuilder.Entity<PaymentTransaction>()
                .HasOne(t => t.Wallet)
                .WithMany(w => w.PaymentTransactions)
                .HasForeignKey(t => t.WalletId);

            //RechargeTransaction

            modelBuilder.Entity<RechargeTransaction>().ToTable("Transaction");

            modelBuilder.Entity<RechargeTransaction>()
                .HasOne(t => t.Wallet)
                .WithMany(w => w.RechargeTransactions)
                .HasForeignKey(t => t.WalletId);

            //TransferTransaction

            modelBuilder.Entity<TransferTransaction>().ToTable("Transaction");

            modelBuilder.Entity<TransferTransaction>()
                .HasOne(t => t.RecipientWallet)
                .WithMany(w => w.RecievedTransferTransactions)
                .HasForeignKey(t => t.RecipientWalletId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TransferTransaction>()
                .HasOne(t => t.Wallet)
                .WithMany(w => w.SentTransferTransactions)
                .HasForeignKey(t => t.WalletId);

            //AccountTypes

            modelBuilder.Entity<AccountType>().ToTable("AccountType");

            modelBuilder.Entity<AccountType>().HasData(
                new AccountType
                {
                    AccountTypeId = 1,
                    Name = "Administrator"
                },
                new AccountType
                {
                    AccountTypeId = 2,
                    Name = "Passenger"
                });

            //Payment Methods

            modelBuilder.Entity<PaymentMethod>().ToTable("PaymentMethod");

            modelBuilder.Entity<PaymentMethod>().HasData(
                new PaymentMethod
                {
                    PaymentMethodId = 1,
                    Name = "Tarjeta de crédito"
                },
                new PaymentMethod
                {
                    PaymentMethodId = 2,
                    Name = "Tarjeta de débito"
                },
                new PaymentMethod
                {
                    PaymentMethodId = 3,
                    Name = "Yape / Plin"
                }
                );

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

            modelBuilder.Entity<Account>().ToTable("Account");

            modelBuilder.Entity<Account>()
                .HasOne(a => a.AccountType)
                .WithMany(a => a.Accounts)
                .HasForeignKey(a => a.AccountTypeId);

            modelBuilder.Entity<Account>()
                .HasDiscriminator(u => u.AccountTypeId)
                .HasValue<Administrator>(1)
                .HasValue<Passenger>(2);

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

            modelBuilder.Entity<Passenger>()
                .HasOne(p => p.PaymentMethod)
                .WithMany(p => p.Passengers)
                .HasForeignKey(p => p.PaymentMethodId);

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
