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
                name: "BusStop",
                columns: table => new
                {
                    BusStopId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(12,9)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(12,9)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusStop", x => x.BusStopId);
                });

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
                name: "LineType",
                columns: table => new
                {
                    LineTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineType", x => x.LineTypeId);
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
                name: "BusLine",
                columns: table => new
                {
                    BusLineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstStop = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastStop = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    LineTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusLine", x => x.BusLineId);
                    table.UniqueConstraint("AK_BusLine_Code", x => x.Code);
                    table.ForeignKey(
                        name: "FK_BusLine_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusLine_LineType_LineTypeId",
                        column: x => x.LineTypeId,
                        principalTable: "LineType",
                        principalColumn: "LineTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bus",
                columns: table => new
                {
                    BusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlateNumber = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    BusLineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bus", x => x.BusId);
                    table.UniqueConstraint("AK_Bus_PlateNumber", x => x.PlateNumber);
                    table.ForeignKey(
                        name: "FK_Bus_BusLine_BusLineId",
                        column: x => x.BusLineId,
                        principalTable: "BusLine",
                        principalColumn: "BusLineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusLineStop",
                columns: table => new
                {
                    BusLineId = table.Column<int>(type: "int", nullable: false),
                    BusStopId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusLineStop", x => new { x.BusLineId, x.BusStopId });
                    table.ForeignKey(
                        name: "FK_BusLineStop_BusLine_BusLineId",
                        column: x => x.BusLineId,
                        principalTable: "BusLine",
                        principalColumn: "BusLineId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusLineStop_BusStop_BusStopId",
                        column: x => x.BusStopId,
                        principalTable: "BusStop",
                        principalColumn: "BusStopId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusDriver",
                columns: table => new
                {
                    BusDriverId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentTypeId = table.Column<int>(type: "int", nullable: false),
                    DocumentNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusDriver", x => x.BusDriverId);
                    table.UniqueConstraint("AK_BusDriver_DocumentTypeId_DocumentNumber", x => new { x.DocumentTypeId, x.DocumentNumber });
                    table.ForeignKey(
                        name: "FK_BusDriver_Bus_BusId",
                        column: x => x.BusId,
                        principalTable: "Bus",
                        principalColumn: "BusId");
                    table.ForeignKey(
                        name: "FK_BusDriver_DocumentType_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalTable: "DocumentType",
                        principalColumn: "DocumentTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TripDetail",
                columns: table => new
                {
                    TripDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TripId = table.Column<int>(type: "int", nullable: false),
                    BusId = table.Column<int>(type: "int", nullable: true),
                    BusLineId = table.Column<int>(type: "int", nullable: false),
                    OriginBusStopId = table.Column<int>(type: "int", nullable: false),
                    DestinationBusStopId = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripDetail", x => x.TripDetailId);
                    table.ForeignKey(
                        name: "FK_TripDetail_BusLine_BusLineId",
                        column: x => x.BusLineId,
                        principalTable: "BusLine",
                        principalColumn: "BusLineId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TripDetail_BusStop_DestinationBusStopId",
                        column: x => x.DestinationBusStopId,
                        principalTable: "BusStop",
                        principalColumn: "BusStopId");
                    table.ForeignKey(
                        name: "FK_TripDetail_BusStop_OriginBusStopId",
                        column: x => x.OriginBusStopId,
                        principalTable: "BusStop",
                        principalColumn: "BusStopId");
                    table.ForeignKey(
                        name: "FK_TripDetail_Bus_BusId",
                        column: x => x.BusId,
                        principalTable: "Bus",
                        principalColumn: "BusId");
                    table.ForeignKey(
                        name: "FK_TripDetail_Trip_TripId",
                        column: x => x.TripId,
                        principalTable: "Trip",
                        principalColumn: "TripId",
                        onDelete: ReferentialAction.Cascade);
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
                table: "LineType",
                columns: new[] { "LineTypeId", "Name" },
                values: new object[,]
                {
                    { 1, "Autobús" },
                    { 2, "Metro" },
                    { 3, "Subterráneo" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bus_BusLineId",
                table: "Bus",
                column: "BusLineId");

            migrationBuilder.CreateIndex(
                name: "IX_Bus_PlateNumber",
                table: "Bus",
                column: "PlateNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BusDriver_BusId",
                table: "BusDriver",
                column: "BusId",
                unique: true,
                filter: "[BusId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BusDriver_DocumentTypeId_DocumentNumber",
                table: "BusDriver",
                columns: new[] { "DocumentTypeId", "DocumentNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BusLine_Code",
                table: "BusLine",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BusLine_CompanyId",
                table: "BusLine",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_BusLine_LineTypeId",
                table: "BusLine",
                column: "LineTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BusLineStop_BusStopId",
                table: "BusLineStop",
                column: "BusStopId");

            migrationBuilder.CreateIndex(
                name: "IX_Trip_UserId",
                table: "Trip",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TripDetail_BusId",
                table: "TripDetail",
                column: "BusId");

            migrationBuilder.CreateIndex(
                name: "IX_TripDetail_BusLineId",
                table: "TripDetail",
                column: "BusLineId");

            migrationBuilder.CreateIndex(
                name: "IX_TripDetail_DestinationBusStopId",
                table: "TripDetail",
                column: "DestinationBusStopId");

            migrationBuilder.CreateIndex(
                name: "IX_TripDetail_OriginBusStopId",
                table: "TripDetail",
                column: "OriginBusStopId");

            migrationBuilder.CreateIndex(
                name: "IX_TripDetail_TripId",
                table: "TripDetail",
                column: "TripId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusDriver");

            migrationBuilder.DropTable(
                name: "BusLineStop");

            migrationBuilder.DropTable(
                name: "TripDetail");

            migrationBuilder.DropTable(
                name: "DocumentType");

            migrationBuilder.DropTable(
                name: "BusStop");

            migrationBuilder.DropTable(
                name: "Bus");

            migrationBuilder.DropTable(
                name: "Trip");

            migrationBuilder.DropTable(
                name: "BusLine");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "LineType");
        }
    }
}
