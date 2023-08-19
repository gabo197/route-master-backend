using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using RouteMaster.API.Domain.Persistence.Contexts;
using RouteMaster.API.Domain.Persistence.Repos;
using RouteMaster.API.Domain.Services;
using RouteMaster.API.Persistence.Repos;
using RouteMaster.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Database Connection Configuration
builder.Services.AddDbContext<RouteMasterContext>(
        options => options.UseSqlServer(builder.Configuration["RouteMaster:ConnectionString"]));

// Dependency Injection Configuration

// Repos
builder.Services.AddScoped<ICountryRepo, CountryRepo>();
builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();
builder.Services.AddScoped<IProvinceRepo, ProvinceRepo>();
builder.Services.AddScoped<IDistrictRepo, DistrictRepo>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Services
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IProvinceService, ProvinceService>();
builder.Services.AddScoped<IDistrictService, DistrictService>();

// Apply Endpoints Naming Convention
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// AutoMapper Setup
builder.Services.AddAutoMapper(typeof(Program));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
