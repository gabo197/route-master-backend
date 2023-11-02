using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RouteMaster.API.Domain.Persistence.Contexts;
using RouteMaster.API.Domain.Persistence.Repos;
using RouteMaster.API.Domain.Services;
using RouteMaster.API.Persistence.Repos;
using RouteMaster.API.Services;
using RouteMaster.API.Settings;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// AppSettings Section Reference
var appSettingsSection = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingsSection);

// JSON Web Token Authentication Configuration
var appSettings = appSettingsSection.Get<AppSettings>();
var key = Encoding.ASCII.GetBytes(appSettings!.Secret);

// Authentication Service Configuration
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

// Database Connection Configuration
var connection = String.Empty;
if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddEnvironmentVariables().AddJsonFile("appsettings.Development.json");
    connection = builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");
}
else
{
    connection = Environment.GetEnvironmentVariable("AZURE_SQL_CONNECTIONSTRING");
}
builder.Services.AddDbContext<RouteMasterContext>(options =>
    options.UseSqlServer(connection));
//builder.Services.AddDbContext<RouteMasterContext>(
//        options => options.UseSqlServer(builder.Configuration["RouteMaster:ConnectionString"]));

// Dependency Injection Configuration

// Repos
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICountryRepo, CountryRepo>();
builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();
builder.Services.AddScoped<IProvinceRepo, ProvinceRepo>();
builder.Services.AddScoped<IDistrictRepo, DistrictRepo>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IPassengerRepo, PassengerRepo>();
builder.Services.AddScoped<IWalletRepo, WalletRepo>();
builder.Services.AddScoped<ITicketRepo, TicketRepo>();
builder.Services.AddScoped<ICompanyRepo, CompanyRepo>();
builder.Services.AddScoped<ILineRepo, LineRepo>();
builder.Services.AddScoped<IBusLineRepo, BusLineRepo>();
builder.Services.AddScoped<IRailwayLineRepo, RailwayLineRepo>();
builder.Services.AddScoped<ISubwayLineRepo, SubwayLineRepo>();
builder.Services.AddScoped<ITripRepo, TripRepo>();
builder.Services.AddScoped<IBusTripDetailRepo, BusTripDetailRepo>();
builder.Services.AddScoped<IBusStopRepo, BusStopRepo>();
builder.Services.AddScoped<IRailwayStopRepo, RailwayStopRepo>();
builder.Services.AddScoped<ISubwayStopRepo, SubwayStopRepo>();
builder.Services.AddScoped<IBusLineStopRepo, BusLineStopRepo>();
builder.Services.AddScoped<IRailwayLineStopRepo, RailwayLineStopRepo>();
builder.Services.AddScoped<ISubwayLineStopRepo, SubwayLineStopRepo>();

// Services
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IProvinceService, ProvinceService>();
builder.Services.AddScoped<IDistrictService, DistrictService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPassengerService, PassengerService>();
builder.Services.AddScoped<IWalletService, WalletService>();
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<ILineService, LineService>();
builder.Services.AddScoped<IBusLineService, BusLineService>();
builder.Services.AddScoped<IRailwayLineService, RailwayLineService>();
builder.Services.AddScoped<ISubwayLineService, SubwayLineService>();
builder.Services.AddScoped<ITripService, TripService>();
builder.Services.AddScoped<IBusTripDetailService, BusTripDetailService>();
builder.Services.AddScoped<IBusStopService, BusStopService>();
builder.Services.AddScoped<IRailwayStopService, RailwayStopService>();
builder.Services.AddScoped<ISubwayStopService, SubwayStopService>();
builder.Services.AddScoped<IBusLineStopService, BusLineStopService>();
builder.Services.AddScoped<IRailwayLineStopService, RailwayLineStopService>();
builder.Services.AddScoped<ISubwayLineStopService, SubwayLineStopService>();

// Apply Endpoints Naming Convention
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// AutoMapper Setup
builder.Services.AddAutoMapper(typeof(Program));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "route_master_backend", Version = "v1" });
    //c.EnableAnnotations();
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme.\r\n\r\nEnter your token in the text input below.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

if (app.Environment.IsDevelopment())
{
    
}

app.UseHttpsRedirection();

app.UseRouting();

// CORS Configuration
app.UseCors(options => options
    .SetIsOriginAllowed(x => _ = true)
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials());

// Authentication Support
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
