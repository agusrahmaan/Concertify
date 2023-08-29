using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Purchases");

            migrationBuilder.AddColumn<string>(
                name: "AccountEmail",
                table: "Purchases",
                type: "varchar(255)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_AccountEmail",
                table: "Purchases",
                column: "AccountEmail");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Accounts_AccountEmail",
                table: "Purchases",
                column: "AccountEmail",
                principalTable: "Accounts",
                principalColumn: "Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Accounts_AccountEmail",
                table: "Purchases");

            migrationBuilder.DropIndex(
                name: "IX_Purchases_AccountEmail",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "AccountEmail",
                table: "Purchases");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Purchases",
                type: "longtext",
                nullable: false);
        }
    }
}
