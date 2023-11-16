using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RouteMaster.API.Migrations
{
    /// <inheritdoc />
    public partial class AddPassengerFavoriteBusLineEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PassengerFavoriteBusLine",
                columns: table => new
                {
                    PassengerId = table.Column<int>(type: "int", nullable: false),
                    BusLineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassengerFavoriteBusLine", x => new { x.BusLineId, x.PassengerId });
                    table.ForeignKey(
                        name: "FK_PassengerFavoriteBusLine_Account_PassengerId",
                        column: x => x.PassengerId,
                        principalTable: "Account",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PassengerFavoriteBusLine_Line_BusLineId",
                        column: x => x.BusLineId,
                        principalTable: "Line",
                        principalColumn: "LineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PassengerFavoriteBusLine_PassengerId",
                table: "PassengerFavoriteBusLine",
                column: "PassengerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PassengerFavoriteBusLine");
        }
    }
}
