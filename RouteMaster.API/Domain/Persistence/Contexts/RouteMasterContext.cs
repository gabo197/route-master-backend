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
        public DbSet<VehicleType> VehicleTypes { get; set; } = null!;
        public DbSet<Bus> Buses { get; set; } = null!;
        public DbSet<BusDriver> BusDrivers { get; set; } = null!;
        public DbSet<DocumentType> DocumentTypes { get; set; } = null!;
        public DbSet<Trip> Trips { get; set; } = null!;
        public DbSet<TripDetail> TripDetails { get; set; } = null!;
        public DbSet<Line> Lines { get; set; } = null!;
        public DbSet<Stop> Stops { get; set; } = null!;
        public DbSet<Vehicle> Vehicles { get; set; } = null!;
        public DbSet<Driver> Drivers { get; set; } = null!;
        public DbSet<LineStop> LineStops { get; set; } = null!;
        public DbSet<RailwayLine> RailwayLines { get; set; } = null!;
        public DbSet<RailwayStop> RailwayStops { get; set; } = null!;
        public DbSet<RailwayLineStop> RailwayLineStops { get; set; } = null!;
        public DbSet<Railway> Railways { get; set; } = null!;
        public DbSet<RailwayDriver> RailwayDrivers { get; set; } = null!;
        public DbSet<SubwayLine> SubwayLines { get; set; } = null!;
        public DbSet<SubwayStop> SubwayStops { get; set; } = null!;
        public DbSet<SubwayLineStop> SubwayLineStops { get; set; } = null!;
        public DbSet<Subway> Subways { get; set; } = null!;
        public DbSet<SubwayDriver> SubwayDrivers { get; set; } = null!;
        public DbSet<BusTripDetail> BusTripDetails { get; set; }
        public DbSet<RailwayTripDetail> RailwayTripDetails { get; set; }
        public DbSet<SubwayTripDetail> SubwayTripDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseExceptionProcessor();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Vehicle

            modelBuilder.Entity<Vehicle>().ToTable("Vehicle");

            modelBuilder.Entity<Vehicle>().HasKey(v => v.VehicleId);

            modelBuilder.Entity<Vehicle>()
                .HasDiscriminator(l => l.VehicleTypeId)
                .HasValue<Bus>(1)
                .HasValue<Railway>(2)
                .HasValue<Subway>(3);

            modelBuilder.Entity<Vehicle>()
                .HasOne(l => l.VehicleType)
                .WithMany(vt => vt.Vehicles)
                .HasForeignKey(l => l.VehicleTypeId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Vehicle>()
                .Property(b => b.PlateNumber)
                .HasMaxLength(6);

            modelBuilder.Entity<Vehicle>()
                .HasIndex(b => b.PlateNumber)
                .IsUnique();

            modelBuilder.Entity<Vehicle>()
                .HasAlternateKey(b => b.PlateNumber);

            //Bus

            modelBuilder.Entity<Bus>().ToTable("Vehicle");

            modelBuilder.Entity<Bus>()
                .HasOne(b => b.BusLine)
                .WithMany(bl => bl.Buses)
                .HasForeignKey(b => b.LineId);

            //Railway

            modelBuilder.Entity<Railway>().ToTable("Vehicle");

            modelBuilder.Entity<Railway>()
                .HasOne(b => b.RailwayLine)
                .WithMany(bl => bl.Railways)
                .HasForeignKey(b => b.LineId);

            //Subway

            modelBuilder.Entity<Subway>().ToTable("Vehicle");

            modelBuilder.Entity<Subway>()
                .HasOne(b => b.SubwayLine)
                .WithMany(bl => bl.Subways)
                .HasForeignKey(b => b.LineId);

            //Driver

            modelBuilder.Entity<Driver>().ToTable("Driver");

            modelBuilder.Entity<Driver>().HasKey(v => v.DriverId);

            modelBuilder.Entity<Driver>()
                .HasDiscriminator(l => l.VehicleTypeId)
                .HasValue<BusDriver>(1)
                .HasValue<RailwayDriver>(2)
                .HasValue<SubwayDriver>(3);

            modelBuilder.Entity<Driver>()
                .HasOne(l => l.VehicleType)
                .WithMany(vt => vt.Drivers)
                .HasForeignKey(l => l.VehicleTypeId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Driver>()
                .HasOne(bd => bd.DocumentType)         
                .WithMany()
                .HasForeignKey(bd => bd.DocumentTypeId);

            modelBuilder.Entity<Driver>()
                .HasIndex(bd => new { bd.DocumentTypeId, bd.DocumentNumber })
                .IsUnique();

            modelBuilder.Entity<Driver>()
                .HasAlternateKey(bd => new { bd.DocumentTypeId, bd.DocumentNumber });

            //Bus Driver

            modelBuilder.Entity<BusDriver>().ToTable("Driver");

            modelBuilder.Entity<BusDriver>()
                .HasOne(bd => bd.Bus)
                .WithOne(b => b.BusDriver)
                .HasForeignKey<BusDriver>(b => b.VehicleId)
                .IsRequired(false);

            //Railway Driver

            modelBuilder.Entity<RailwayDriver>().ToTable("Driver");

            modelBuilder.Entity<RailwayDriver>()
                .HasOne(bd => bd.Railway)
                .WithOne(b => b.RailwayDriver)
                .HasForeignKey<RailwayDriver>(b => b.VehicleId)
                .IsRequired(false);

            //Subway Driver

            modelBuilder.Entity<SubwayDriver>().ToTable("Driver");

            modelBuilder.Entity<SubwayDriver>()
                .HasOne(bd => bd.Subway)
                .WithOne(b => b.SubwayDriver)
                .HasForeignKey<SubwayDriver>(b => b.VehicleId)
                .IsRequired(false);

            //Line

            modelBuilder.Entity<Line>().ToTable("Line");

            modelBuilder.Entity<Line>().HasKey(v => v.LineId);
            modelBuilder.Entity<Line>().Property(v => v.Logo).HasColumnType("varbinary(max)");

            modelBuilder.Entity<Line>()
                .HasDiscriminator(l => l.VehicleTypeId)
                .HasValue<BusLine>(1)
                .HasValue<RailwayLine>(2)
                .HasValue<SubwayLine>(3);

            modelBuilder.Entity<Line>()
                .HasOne(l => l.Company)
                .WithMany(c => c.Lines)
                .HasForeignKey(l => l.CompanyId);

            modelBuilder.Entity<Line>()
                .HasOne(l => l.VehicleType)
                .WithMany(vt => vt.Lines)
                .HasForeignKey(l => l.VehicleTypeId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Line>()
                .HasIndex(bl => bl.Code)
                .IsUnique();

            modelBuilder.Entity<Line>()
                .HasIndex(bl => bl.OldCode)
                .IsUnique();

            modelBuilder.Entity<Line>()
                .HasAlternateKey(bl => bl.Code);

            //Bus Line

            modelBuilder.Entity<BusLine>().ToTable("Line");

            modelBuilder.Entity<BusLine>()
                .HasMany(bl => bl.BusStops)
                .WithMany(bs => bs.BusLines)
                .UsingEntity<BusLineStop>();

            //Railway Line

            modelBuilder.Entity<RailwayLine>().ToTable("Line");

            modelBuilder.Entity<RailwayLine>()
                .HasMany(rl => rl.RailwayStops)
                .WithMany(rs => rs.RailwayLines)
                .UsingEntity<RailwayLineStop>();

            //Subway Line

            modelBuilder.Entity<SubwayLine>().ToTable("Line");

            modelBuilder.Entity<SubwayLine>()
                .HasMany(sl => sl.SubwayStops)
                .WithMany(ss => ss.SubwayLines)
                .UsingEntity<SubwayLineStop>();

            //Stop

            modelBuilder.Entity<Stop>().ToTable("Stop");

            modelBuilder.Entity<Stop>().HasKey(v => v.StopId);

            modelBuilder.Entity<Stop>()
                .HasDiscriminator(l => l.VehicleTypeId)
                .HasValue<BusStop>(1)
                .HasValue<RailwayStop>(2)
                .HasValue<SubwayStop>(3);

            modelBuilder.Entity<Stop>()
                .HasOne(l => l.VehicleType)
                .WithMany(vt => vt.Stops)
                .HasForeignKey(l => l.VehicleTypeId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<BusStop>().Property(bs => bs.Latitude)
                .HasColumnType("decimal(12,9)");

            modelBuilder.Entity<BusStop>().Property(bs => bs.Longitude)
                .HasColumnType("decimal(12,9)");

            //Bus Stop

            modelBuilder.Entity<BusStop>().ToTable("Stop");

            //Railway Stop

            modelBuilder.Entity<RailwayStop>().ToTable("Stop");

            //Subway Stop

            modelBuilder.Entity<SubwayStop>().ToTable("Stop");

            //Line Stop

            modelBuilder.Entity<LineStop>().ToTable("LineStop");

            modelBuilder.Entity<LineStop>()
                .HasKey(c => new { c.LineId, c.StopId });

            modelBuilder.Entity<LineStop>()
                .HasDiscriminator(ls => ls.VehicleTypeId)
                .HasValue<BusLineStop>(1)
                .HasValue<RailwayLineStop>(2)
                .HasValue<SubwayLineStop>(3);

            modelBuilder.Entity<LineStop>()
                .HasOne(ls => ls.VehicleType)
                .WithMany(vt => vt.LineStops)
                .HasForeignKey(ls => ls.VehicleTypeId)
                .OnDelete(DeleteBehavior.NoAction);

            //Bus Line Stop

            modelBuilder.Entity<BusLineStop>().ToTable("LineStop");

            //Railway Line Stop

            modelBuilder.Entity<RailwayLineStop>().ToTable("LineStop");

            //Subway Line Stop

            modelBuilder.Entity<SubwayLineStop>().ToTable("LineStop");

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

            modelBuilder.Entity<VehicleType>().ToTable("VehicleType");

            modelBuilder.Entity<VehicleType>().HasData(
                new VehicleType
                {
                    VehicleTypeId = 1,
                    Name = "Autobús"
                },
                new VehicleType
                {
                    VehicleTypeId = 2,
                    Name = "Metro"
                },
                new VehicleType
                {
                    VehicleTypeId = 3,
                    Name = "Subterráneo"
                });

            //Trip

            modelBuilder.Entity<Trip>().ToTable("Trip");
            
            modelBuilder.Entity<Trip>()
                .HasOne(t => t.Passenger)
                .WithMany(p => p.Trips)
                .HasForeignKey(t => t.UserId);

            modelBuilder.Entity<Trip>().Property(t => t.TotalPrice)
                .HasColumnType("decimal(5,2)");

            //Trip Detail

            modelBuilder.Entity<TripDetail>().ToTable("TripDetail");

            modelBuilder.Entity<TripDetail>().Property(td => td.Price)
                .HasColumnType("decimal(5,2)");

            modelBuilder.Entity<TripDetail>()
                .HasDiscriminator(td => td.VehicleTypeId)
                .HasValue<BusTripDetail>(1)
                .HasValue<RailwayTripDetail>(2)
                .HasValue<SubwayTripDetail>(3);

            modelBuilder.Entity<TripDetail>()
                .HasOne(td => td.VehicleType)
                .WithMany()
                .HasForeignKey(td => td.VehicleTypeId)
                .OnDelete(DeleteBehavior.NoAction);

            //Bus Trip Detail

            modelBuilder.Entity<BusTripDetail>()
                .HasOne(td => td.Trip)
                .WithMany(t => t.BusTripDetails)
                .HasForeignKey(td => td.TripId);

            modelBuilder.Entity<BusTripDetail>()
                .HasOne(td => td.Bus)
                .WithMany()
                .HasForeignKey(td => td.VehicleId)
                .IsRequired(false);

            modelBuilder.Entity<BusTripDetail>()
                .HasOne(td => td.BusLine)
                .WithMany()
                .HasForeignKey(td => td.LineId);

            modelBuilder.Entity<BusTripDetail>()
                .HasOne(t => t.OriginBusStop)
                .WithMany()
                .HasForeignKey(t => t.OriginStopId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<BusTripDetail>()
                .HasOne(t => t.DestinationBusStop)
                .WithMany()
                .HasForeignKey(t => t.DestinationStopId)
                .OnDelete(DeleteBehavior.NoAction);

            //Railway Trip Detail

            modelBuilder.Entity<RailwayTripDetail>()
                .HasOne(td => td.Trip)
                .WithMany(t => t.RailwayTripDetails)
                .HasForeignKey(td => td.TripId);

            modelBuilder.Entity<RailwayTripDetail>()
                .HasOne(td => td.Railway)
                .WithMany()
                .HasForeignKey(td => td.VehicleId)
                .IsRequired(false);

            modelBuilder.Entity<RailwayTripDetail>()
                .HasOne(td => td.RailwayLine)
                .WithMany()
                .HasForeignKey(td => td.LineId);

            modelBuilder.Entity<RailwayTripDetail>()
                .HasOne(t => t.OriginRailwayStop)
                .WithMany()
                .HasForeignKey(t => t.OriginStopId)
                .OnDelete(DeleteBehavior.NoAction);
            
            modelBuilder.Entity<RailwayTripDetail>()
                .HasOne(t => t.DestinationRailwayStop)
                .WithMany()
                .HasForeignKey(t => t.DestinationStopId)
                .OnDelete(DeleteBehavior.NoAction);

            //Subway Trip Detail

            modelBuilder.Entity<SubwayTripDetail>()
                .HasOne(td => td.Trip)
                .WithMany(t => t.SubwayTripDetails)
                .HasForeignKey(td => td.TripId);

            modelBuilder.Entity<SubwayTripDetail>()
                .HasOne(td => td.Subway)
                .WithMany()
                .HasForeignKey(td => td.VehicleId)
                .IsRequired(false);

            modelBuilder.Entity<SubwayTripDetail>()
                .HasOne(td => td.SubwayLine)
                .WithMany()
                .HasForeignKey(td => td.LineId);
            
            modelBuilder.Entity<SubwayTripDetail>()
                .HasOne(t => t.OriginSubwayStop)
                .WithMany()
                .HasForeignKey(t => t.OriginStopId)
                .OnDelete(DeleteBehavior.NoAction);
            
            modelBuilder.Entity<SubwayTripDetail>()
                .HasOne(t => t.DestinationSubwayStop)
                .WithMany()
                .HasForeignKey(t => t.DestinationStopId)
                .OnDelete(DeleteBehavior.NoAction);

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
