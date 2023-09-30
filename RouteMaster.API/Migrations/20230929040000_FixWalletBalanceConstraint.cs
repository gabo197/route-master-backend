using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RouteMaster.API.Migrations
{
    /// <inheritdoc />
    public partial class FixWalletBalanceConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Wallet_Balance",
                table: "Wallet");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Wallet_Balance",
                table: "Wallet",
                sql: "Balance <= 500.00");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Wallet_Balance",
                table: "Wallet");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Wallet_Balance",
                table: "Wallet",
                sql: "Balance < 500.00");
        }
    }
}
