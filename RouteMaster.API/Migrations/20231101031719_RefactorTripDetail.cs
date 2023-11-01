using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RouteMaster.API.Migrations
{
    /// <inheritdoc />
    public partial class RefactorTripDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "TripDetail",
                type: "decimal(5,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VehicleTypeId",
                table: "TripDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPrice",
                table: "Trip",
                type: "decimal(5,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Trip",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateIndex(
                name: "IX_TripDetail_VehicleTypeId",
                table: "TripDetail",
                column: "VehicleTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TripDetail_VehicleType_VehicleTypeId",
                table: "TripDetail",
                column: "VehicleTypeId",
                principalTable: "VehicleType",
                principalColumn: "VehicleTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TripDetail_VehicleType_VehicleTypeId",
                table: "TripDetail");

            migrationBuilder.DropIndex(
                name: "IX_TripDetail_VehicleTypeId",
                table: "TripDetail");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "TripDetail");

            migrationBuilder.DropColumn(
                name: "VehicleTypeId",
                table: "TripDetail");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPrice",
                table: "Trip",
                type: "decimal(5,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Trip",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
