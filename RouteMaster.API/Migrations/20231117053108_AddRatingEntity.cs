using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RouteMaster.API.Migrations
{
    /// <inheritdoc />
    public partial class AddRatingEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    RatingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<short>(type: "smallint", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassengerId = table.Column<int>(type: "int", nullable: false),
                    TripDetailId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.RatingId);
                    table.ForeignKey(
                        name: "FK_Rating_Account_PassengerId",
                        column: x => x.PassengerId,
                        principalTable: "Account",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rating_TripDetail_TripDetailId",
                        column: x => x.TripDetailId,
                        principalTable: "TripDetail",
                        principalColumn: "TripDetailId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rating_PassengerId",
                table: "Rating",
                column: "PassengerId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_TripDetailId",
                table: "Rating",
                column: "TripDetailId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rating");
        }
    }
}
