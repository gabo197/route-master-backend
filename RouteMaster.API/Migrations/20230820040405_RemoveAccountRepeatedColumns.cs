using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RouteMaster.API.Migrations
{
    public partial class RemoveAccountRepeatedColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Account");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Account",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Account",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
