using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RouteMaster.API.Migrations
{
    /// <inheritdoc />
    public partial class ChangeBalanceDatatype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Wallet_Balance",
                table: "Wallet");

            migrationBuilder.AlterColumn<string>(
                name: "Balance",
                table: "Wallet",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Balance",
                table: "Wallet",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Wallet_Balance",
                table: "Wallet",
                sql: "Balance <= 500.00");
        }
    }
}
