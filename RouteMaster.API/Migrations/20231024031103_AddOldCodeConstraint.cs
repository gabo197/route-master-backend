using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RouteMaster.API.Migrations
{
    /// <inheritdoc />
    public partial class AddOldCodeConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OldCode",
                table: "Line",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Line_OldCode",
                table: "Line",
                column: "OldCode",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Line_OldCode",
                table: "Line");

            migrationBuilder.AlterColumn<string>(
                name: "OldCode",
                table: "Line",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
