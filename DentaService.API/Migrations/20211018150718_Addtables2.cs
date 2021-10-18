using Microsoft.EntityFrameworkCore.Migrations;

namespace DentaService.API.Migrations
{
    public partial class Addtables2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DetailServices_Value",
                table: "DetailServices");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "DetailServices");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "DetailServices");

            migrationBuilder.AddColumn<string>(
                name: "PaymentMethod",
                table: "DetailServices",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_DetailServices_PaymentMethod",
                table: "DetailServices",
                column: "PaymentMethod",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DetailServices_PaymentMethod",
                table: "DetailServices");

            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "DetailServices");

            migrationBuilder.AddColumn<int>(
                name: "Discount",
                table: "DetailServices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Value",
                table: "DetailServices",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_DetailServices_Value",
                table: "DetailServices",
                column: "Value",
                unique: true);
        }
    }
}
