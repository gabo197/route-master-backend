using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RouteMaster.API.Migrations
{
    public partial class AddDistrictsSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "CountryId", "IsActive", "Name" },
                values: new object[] { 1, true, "Perú" });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "CountryId", "DepartmentId", "IsActive", "Name" },
                values: new object[] { 1, 1, true, "Lima" });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "CountryId", "DepartmentId", "ProvinceId", "IsActive", "Name" },
                values: new object[] { 1, 1, 1, true, "Lima Metropolitana" });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "CountryId", "DepartmentId", "ProvinceId", "IsActive", "Name" },
                values: new object[] { 1, 1, 2, true, "Callao" });

            migrationBuilder.InsertData(
                table: "District",
                columns: new[] { "CountryId", "DepartmentId", "DistrictId", "ProvinceId", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, true, "Ancón" },
                    { 1, 1, 2, 1, true, "Ate" },
                    { 1, 1, 3, 1, true, "Barranco" },
                    { 1, 1, 4, 1, true, "Breña" },
                    { 1, 1, 5, 1, true, "Carabayllo" },
                    { 1, 1, 6, 1, true, "Chaclacayo" },
                    { 1, 1, 7, 1, true, "Chorrillos" },
                    { 1, 1, 8, 1, true, "Cieneguilla" },
                    { 1, 1, 9, 1, true, "Comas" },
                    { 1, 1, 10, 1, true, "El Agustino" },
                    { 1, 1, 11, 1, true, "Independencia" },
                    { 1, 1, 12, 1, true, "Jesús María" },
                    { 1, 1, 13, 1, true, "La Molina" },
                    { 1, 1, 14, 1, true, "La Victoria" },
                    { 1, 1, 15, 1, true, "Lima" },
                    { 1, 1, 16, 1, true, "Lince" },
                    { 1, 1, 17, 1, true, "Los Olivos" },
                    { 1, 1, 18, 1, true, "Lurigancho" },
                    { 1, 1, 19, 1, true, "Lurín" },
                    { 1, 1, 20, 1, true, "Magdalena del Mar" },
                    { 1, 1, 21, 1, true, "Miraflores" },
                    { 1, 1, 22, 1, true, "Pachacámac" },
                    { 1, 1, 23, 1, true, "Pucusana" },
                    { 1, 1, 24, 1, true, "Pueblo Libre" },
                    { 1, 1, 25, 1, true, "Puente Piedra" },
                    { 1, 1, 26, 1, true, "Punta Hermosa" },
                    { 1, 1, 27, 1, true, "Punta Negra" },
                    { 1, 1, 28, 1, true, "Rímac" },
                    { 1, 1, 29, 1, true, "San Bartolo" },
                    { 1, 1, 30, 1, true, "San Borja" },
                    { 1, 1, 31, 1, true, "San Isidro" },
                    { 1, 1, 32, 1, true, "San Juan de Lurigancho" },
                    { 1, 1, 33, 1, true, "San Juan de Miraflores" },
                    { 1, 1, 34, 1, true, "San Luis" },
                    { 1, 1, 35, 1, true, "San Martín de Porres" },
                    { 1, 1, 36, 1, true, "San Miguel" },
                    { 1, 1, 37, 1, true, "Santa Anita" },
                    { 1, 1, 38, 1, true, "Santa María del Mar" },
                    { 1, 1, 39, 1, true, "Santa Rosa" },
                    { 1, 1, 40, 1, true, "Santiago de Surco" },
                    { 1, 1, 41, 1, true, "Surquillo" },
                    { 1, 1, 42, 1, true, "Villa El Salvador" }
                });

            migrationBuilder.InsertData(
                table: "District",
                columns: new[] { "CountryId", "DepartmentId", "DistrictId", "ProvinceId", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, 1, 43, 1, true, "Villa María del Triunfo" },
                    { 1, 1, 1, 2, true, "Bellavista" },
                    { 1, 1, 2, 2, true, "Callao" },
                    { 1, 1, 3, 2, true, "Carmen de La Legua" },
                    { 1, 1, 4, 2, true, "La Perla" },
                    { 1, 1, 5, 2, true, "La Punta" },
                    { 1, 1, 6, 2, true, "Mi Perú" },
                    { 1, 1, 7, 2, true, "Ventanilla" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "District",
                keyColumns: new[] { "CountryId", "DepartmentId", "DistrictId", "ProvinceId" },
                keyValues: new object[] { 1, 1, 1, 1 });

            migrationBuilder.DeleteData(
                table: "District",
                keyColumns: new[] { "CountryId", "DepartmentId", "DistrictId", "ProvinceId" },
                keyValues: new object[] { 1, 1, 2, 1 });

            migrationBuilder.DeleteData(
                table: "District",
                keyColumns: new[] { "CountryId", "DepartmentId", "DistrictId", "ProvinceId" },
                keyValues: new object[] { 1, 1, 3, 1 });

            migrationBuilder.DeleteData(
                table: "District",
                keyColumns: new[] { "CountryId", "DepartmentId", "DistrictId", "ProvinceId" },
                keyValues: new object[] { 1, 1, 4, 1 });

            migrationBuilder.DeleteData(
                table: "District",
                keyColumns: new[] { "CountryId", "DepartmentId", "DistrictId", "ProvinceId" },
                keyValues: new object[] { 1, 1, 5, 1 });

            migrationBuilder.DeleteData(
                table: "District",
                keyColumns: new[] { "CountryId", "DepartmentId", "DistrictId", "ProvinceId" },
                keyValues: new object[] { 1, 1, 6, 1 });

            migrationBuilder.DeleteData(
                table: "District",
                keyColumns: new[] { "CountryId", "DepartmentId", "DistrictId", "ProvinceId" },
                keyValues: new object[] { 1, 1, 7, 1 });

            migrationBuilder.DeleteData(
                table: "District",
                keyColumns: new[] { "CountryId", "DepartmentId", "DistrictId", "ProvinceId" },
                keyValues: new object[] { 1, 1, 8, 1 });

            migrationBuilder.DeleteData(
                table: "District",
                keyColumns: new[] { "CountryId", "DepartmentId", "DistrictId", "ProvinceId" },
                keyValues: new object[] { 1, 1, 9, 1 });

            migrationBuilder.DeleteData(
                table: "District",
                keyColumns: new[] { "CountryId", "DepartmentId", "DistrictId", "ProvinceId" },
                keyValues: new object[] { 1, 1, 10, 1 });

            migrationBuilder.DeleteData(
                table: "District",
                keyColumns: new[] { "CountryId", "DepartmentId", "DistrictId", "ProvinceId" },
                keyValues: new object[] { 1, 1, 11, 1 });

            migrationBuilder.DeleteData(
                table: "District",
                keyColumns: new[] { "CountryId", "DepartmentId", "DistrictId", "ProvinceId" },
                keyValues: new object[] { 1, 1, 12, 1 });

            migrationBuilder.DeleteData(
                table: "District",
                keyColumns: new[] { "CountryId", "DepartmentId", "DistrictId", "ProvinceId" },
                keyValues: new object[] { 1, 1, 13, 1 });

            migrationBuilder.DeleteData(
                table: "District",
                keyColumns: new[] { "CountryId", "DepartmentId", "DistrictId", "ProvinceId" },
                keyValues: new object[] { 1, 1, 14, 1 });

            migrationBuilder.DeleteData(
                table: "District",
                keyColumns: new[] { "CountryId", "DepartmentId", "DistrictId", "ProvinceId" },
                keyValues: new object[] { 1, 1, 15, 1 });

            migrationBuilder.DeleteData(
                table: "District",
                keyColumns: new[] { "CountryId", "DepartmentId", "DistrictId", "ProvinceId" },
                keyValues: new object[] { 1, 1, 16, 1 });

            migrationBuilder.DeleteData(
                table: "District",
                keyColumns: new[] { "CountryId", "DepartmentId", "DistrictId", "ProvinceId" },
                keyValues: new object[] { 1, 1, 17, 1 });

            migrationBuilder.DeleteData(
                table: "District",
                keyColumns: new[] { "CountryId", "DepartmentId", "DistrictId", "ProvinceId" },
                keyValues: new object[] { 1, 1, 18, 1 });

            migrationBuilder.DeleteData(
                table: "District",
                keyColumns: new[] { "CountryId", "DepartmentId", "DistrictId", "ProvinceId" },
                keyValues: new object[] { 1, 1, 19, 1 });

            migrationBuilder.DeleteData(
                table: "District",
                keyColumns: new[] { "CountryId", "DepartmentId", "DistrictId", "ProvinceId" },
                keyValues: new object[] { 1, 1, 20, 1 });

            migrationBuilder.DeleteData(
                table: "District",
                keyColumns: new[] { "CountryId", "DepartmentId", "DistrictId", "ProvinceId" },
                keyValues: new object[] { 1, 1, 21, 1 });

            migrationBuilder.DeleteData(
                table: "District",
                keyColumns: new[] { "CountryId", "DepartmentId", "DistrictId", "ProvinceId" },
                keyValues: new object[] { 1, 1, 22, 1 });

            migrationBuilder.DeleteData(
                table: "District",
                keyColumns: new[] { "CountryId", "DepartmentId", "DistrictId", "ProvinceId" },
                keyValues: new object[] { 1, 1, 23, 1 });

            migrationBuilder.DeleteData(
                table: "District",
                keyColumns: new[] { "CountryId", "DepartmentId", "DistrictId", "ProvinceId" },
                keyValues: new object[] { 1, 1, 24, 1 });

            migrationBuilder.DeleteData(
                table: "District",
                keyColumns: new[] { "CountryId", "DepartmentId", "DistrictId", "ProvinceId" },
                keyValues: new object[] { 1, 1, 25, 1 });

            migrationBuilder.DeleteData(
                table: "District",
                keyColumns: new[] { "CountryId", "DepartmentId", "DistrictId", "ProvinceId" },
                keyValues: new object[] { 1, 1, 26, 1 });

            migrationBuilder.DeleteData(
                table: "District",
                keyColumns: new[] { "CountryId", "DepartmentId", "DistrictId", "ProvinceId" },
                keyValues: new object[] { 1, 1, 27, 1 });

            migrationBuilder.DeleteData(
                table: "District",
                keyColumns: new[] { "CountryId", "DepartmentId", "DistrictId", "ProvinceId" },
                keyValues: new object[] { 1, 1, 28, 1 });

            migrationBuilder.DeleteData(
                table: "District",
                keyColumns: new[] { "CountryId", "DepartmentId", "DistrictId", "ProvinceId" },
                keyValues: new object[] { 1, 1, 29, 1 });

            migrationBuilder.DeleteData(
                table: "District",
                keyColumns: new[] { "CountryId", "DepartmentId", "DistrictId", "ProvinceId" },
                keyValues: new object[] { 1, 1, 30, 1 });

            migrationBuilder.DeleteData(
                table: "District",
                keyColumns: new[] { "CountryId", "DepartmentId", "DistrictId", "ProvinceId" },
                keyValues: new object[] { 1, 1, 31, 1 });

            migrationBuilder.DeleteData(
                table: "District",
                keyColumns: new[] { "CountryId", "DepartmentId", "DistrictId", "ProvinceId" },
                keyValues: new object[] { 1, 1, 32, 1 });

            migrationBuilder.DeleteData(
                table: "District",
                keyColumns: new[] { "CountryId", "DepartmentId", "DistrictId", "ProvinceId" },
                keyValues: new object[] { 1, 1, 33, 1 });

            migrationBuilder.DeleteData(
                table: "District",
                keyColumns: new[] { "CountryId", "DepartmentId", "DistrictId", "ProvinceId" },
                keyValues: new object[] { 1, 1, 34, 1 });

            migrationBuilder.DeleteData(
                table: "District",
                keyColumns: new[] { "CountryId", "DepartmentId", "DistrictId", "ProvinceId" },
                keyValues: new object[] { 1, 1, 35, 1 });

            migrationBuilder.DeleteData(
                table: "District",
                keyColumns: new[] { "CountryId", "DepartmentId", "DistrictId", "ProvinceId" },
                keyValues: new object[] { 1, 1, 36, 1 });

            migrationBuilder.DeleteData(
                table: "District",
                keyColumns: new[] { "CountryId", "DepartmentId", "DistrictId", "ProvinceId" },
                keyValues: new object[] { 1, 1, 37, 1 });

            migrationBuilder.DeleteData(
                table: "District",
                keyColumns: new[] { "CountryId", "DepartmentId", "DistrictId", "ProvinceId" },
                keyValues: new object[] { 1, 1, 38, 1 });

            migrationBuilder.DeleteData(
                table: "District",
                keyColumns: new[] { "CountryId", "DepartmentId", "DistrictId", "ProvinceId" },
                keyValues: new object[] { 1, 1, 39, 1 });

            migrationBuilder.DeleteData(
                table: "District",
                keyColumns: new[] { "CountryId", "DepartmentId", "DistrictId", "ProvinceId" },
                keyValues: new object[] { 1, 1, 40, 1 });

            migrationBuilder.DeleteData(
                table: "District",
                keyColumns: new[] { "CountryId", "DepartmentId", "DistrictId", "ProvinceId" },
                keyValues: new object[] { 1, 1, 41, 1 });

            migrationBuilder.DeleteData(
                table: "District",
                keyColumns: new[] { "CountryId", "DepartmentId", "DistrictId", "ProvinceId" },
                keyValues: new object[] { 1, 1, 42, 1 });

            migrationBuilder.DeleteData(
                table: "District",
                keyColumns: new[] { "CountryId", "DepartmentId", "DistrictId", "ProvinceId" },
                keyValues: new object[] { 1, 1, 43, 1 });

            migrationBuilder.DeleteData(
                table: "District",
                keyColumns: new[] { "CountryId", "DepartmentId", "DistrictId", "ProvinceId" },
                keyValues: new object[] { 1, 1, 1, 2 });

            migrationBuilder.DeleteData(
                table: "District",
                keyColumns: new[] { "CountryId", "DepartmentId", "DistrictId", "ProvinceId" },
                keyValues: new object[] { 1, 1, 2, 2 });

            migrationBuilder.DeleteData(
                table: "District",
                keyColumns: new[] { "CountryId", "DepartmentId", "DistrictId", "ProvinceId" },
                keyValues: new object[] { 1, 1, 3, 2 });

            migrationBuilder.DeleteData(
                table: "District",
                keyColumns: new[] { "CountryId", "DepartmentId", "DistrictId", "ProvinceId" },
                keyValues: new object[] { 1, 1, 4, 2 });

            migrationBuilder.DeleteData(
                table: "District",
                keyColumns: new[] { "CountryId", "DepartmentId", "DistrictId", "ProvinceId" },
                keyValues: new object[] { 1, 1, 5, 2 });

            migrationBuilder.DeleteData(
                table: "District",
                keyColumns: new[] { "CountryId", "DepartmentId", "DistrictId", "ProvinceId" },
                keyValues: new object[] { 1, 1, 6, 2 });

            migrationBuilder.DeleteData(
                table: "District",
                keyColumns: new[] { "CountryId", "DepartmentId", "DistrictId", "ProvinceId" },
                keyValues: new object[] { 1, 1, 7, 2 });

            migrationBuilder.DeleteData(
                table: "Province",
                keyColumns: new[] { "CountryId", "DepartmentId", "ProvinceId" },
                keyValues: new object[] { 1, 1, 1 });

            migrationBuilder.DeleteData(
                table: "Province",
                keyColumns: new[] { "CountryId", "DepartmentId", "ProvinceId" },
                keyValues: new object[] { 1, 1, 2 });

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumns: new[] { "CountryId", "DepartmentId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 1);
        }
    }
}
