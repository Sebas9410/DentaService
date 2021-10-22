using Microsoft.EntityFrameworkCore.Migrations;

namespace DentaService.API.Migrations
{
    public partial class ChangesTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Shedules_SheduleID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SheduleID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SheduleID",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SheduleID",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SheduleID",
                table: "AspNetUsers",
                column: "SheduleID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Shedules_SheduleID",
                table: "AspNetUsers",
                column: "SheduleID",
                principalTable: "Shedules",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
