using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RouteMaster.API.Migrations
{
    /// <inheritdoc />
    public partial class AddTravelBoundedContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "DocumentType",
                columns: table => new
                {
                    DocumentTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentType", x => x.DocumentTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Trip",
                columns: table => new
                {
                    TripId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trip", x => x.TripId);
                    table.ForeignKey(
                        name: "FK_Trip_Account_UserId",
                        column: x => x.UserId,
                        principalTable: "Account",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleType",
                columns: table => new
                {
                    VehicleTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleType", x => x.VehicleTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Line",
                columns: table => new
                {
                    LineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstStop = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastStop = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    VehicleTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Line", x => x.LineId);
                    table.UniqueConstraint("AK_Line_Code", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Line_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Line_VehicleType_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalTable: "VehicleType",
                        principalColumn: "VehicleTypeId");
                });

            migrationBuilder.CreateTable(
                name: "Stop",
                columns: table => new
                {
                    StopId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(12,9)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(12,9)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stop", x => x.StopId);
                    table.ForeignKey(
                        name: "FK_Stop_VehicleType_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalTable: "VehicleType",
                        principalColumn: "VehicleTypeId");
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleTypeId = table.Column<int>(type: "int", nullable: false),
                    PlateNumber = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    LineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.VehicleId);
                    table.UniqueConstraint("AK_Vehicle_PlateNumber", x => x.PlateNumber);
                    table.ForeignKey(
                        name: "FK_Vehicle_Line_LineId",
                        column: x => x.LineId,
                        principalTable: "Line",
                        principalColumn: "LineId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicle_VehicleType_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalTable: "VehicleType",
                        principalColumn: "VehicleTypeId");
                });

            migrationBuilder.CreateTable(
                name: "LineStop",
                columns: table => new
                {
                    LineId = table.Column<int>(type: "int", nullable: false),
                    StopId = table.Column<int>(type: "int", nullable: false),
                    VehicleTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineStop", x => new { x.LineId, x.StopId });
                    table.ForeignKey(
                        name: "FK_LineStop_Line_LineId",
                        column: x => x.LineId,
                        principalTable: "Line",
                        principalColumn: "LineId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LineStop_Stop_StopId",
                        column: x => x.StopId,
                        principalTable: "Stop",
                        principalColumn: "StopId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LineStop_VehicleType_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalTable: "VehicleType",
                        principalColumn: "VehicleTypeId");
                });

            migrationBuilder.CreateTable(
                name: "Driver",
                columns: table => new
                {
                    DriverId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleTypeId = table.Column<int>(type: "int", nullable: false),
                    DocumentTypeId = table.Column<int>(type: "int", nullable: false),
                    DocumentNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Driver", x => x.DriverId);
                    table.UniqueConstraint("AK_Driver_DocumentTypeId_DocumentNumber", x => new { x.DocumentTypeId, x.DocumentNumber });
                    table.ForeignKey(
                        name: "FK_Driver_DocumentType_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalTable: "DocumentType",
                        principalColumn: "DocumentTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Driver_VehicleType_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalTable: "VehicleType",
                        principalColumn: "VehicleTypeId");
                    table.ForeignKey(
                        name: "FK_Driver_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "VehicleId");
                });

            migrationBuilder.CreateTable(
                name: "TripDetail",
                columns: table => new
                {
                    TripDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TripId = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: true),
                    LineId = table.Column<int>(type: "int", nullable: false),
                    OriginStopId = table.Column<int>(type: "int", nullable: false),
                    DestinationStopId = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripDetail", x => x.TripDetailId);
                    table.ForeignKey(
                        name: "FK_TripDetail_Line_LineId",
                        column: x => x.LineId,
                        principalTable: "Line",
                        principalColumn: "LineId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TripDetail_Stop_DestinationStopId",
                        column: x => x.DestinationStopId,
                        principalTable: "Stop",
                        principalColumn: "StopId");
                    table.ForeignKey(
                        name: "FK_TripDetail_Stop_OriginStopId",
                        column: x => x.OriginStopId,
                        principalTable: "Stop",
                        principalColumn: "StopId");
                    table.ForeignKey(
                        name: "FK_TripDetail_Trip_TripId",
                        column: x => x.TripId,
                        principalTable: "Trip",
                        principalColumn: "TripId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TripDetail_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "VehicleId");
                });

            migrationBuilder.InsertData(
                table: "DocumentType",
                columns: new[] { "DocumentTypeId", "Name" },
                values: new object[,]
                {
                    { 1, "DNI" },
                    { 2, "Carné de extranjería" },
                    { 3, "Pasaporte" }
                });

            migrationBuilder.InsertData(
                table: "VehicleType",
                columns: new[] { "VehicleTypeId", "Name" },
                values: new object[,]
                {
                    { 1, "Autobús" },
                    { 2, "Metro" },
                    { 3, "Subterráneo" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Driver_DocumentTypeId_DocumentNumber",
                table: "Driver",
                columns: new[] { "DocumentTypeId", "DocumentNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Driver_VehicleId",
                table: "Driver",
                column: "VehicleId",
                unique: true,
                filter: "[VehicleId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Driver_VehicleTypeId",
                table: "Driver",
                column: "VehicleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Line_Code",
                table: "Line",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Line_CompanyId",
                table: "Line",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Line_VehicleTypeId",
                table: "Line",
                column: "VehicleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LineStop_StopId",
                table: "LineStop",
                column: "StopId");

            migrationBuilder.CreateIndex(
                name: "IX_LineStop_VehicleTypeId",
                table: "LineStop",
                column: "VehicleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Stop_VehicleTypeId",
                table: "Stop",
                column: "VehicleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Trip_UserId",
                table: "Trip",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TripDetail_DestinationStopId",
                table: "TripDetail",
                column: "DestinationStopId");

            migrationBuilder.CreateIndex(
                name: "IX_TripDetail_LineId",
                table: "TripDetail",
                column: "LineId");

            migrationBuilder.CreateIndex(
                name: "IX_TripDetail_OriginStopId",
                table: "TripDetail",
                column: "OriginStopId");

            migrationBuilder.CreateIndex(
                name: "IX_TripDetail_TripId",
                table: "TripDetail",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_TripDetail_VehicleId",
                table: "TripDetail",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_LineId",
                table: "Vehicle",
                column: "LineId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_PlateNumber",
                table: "Vehicle",
                column: "PlateNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_VehicleTypeId",
                table: "Vehicle",
                column: "VehicleTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Driver");

            migrationBuilder.DropTable(
                name: "LineStop");

            migrationBuilder.DropTable(
                name: "TripDetail");

            migrationBuilder.DropTable(
                name: "DocumentType");

            migrationBuilder.DropTable(
                name: "Stop");

            migrationBuilder.DropTable(
                name: "Trip");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "Line");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "VehicleType");
        }
    }
}
