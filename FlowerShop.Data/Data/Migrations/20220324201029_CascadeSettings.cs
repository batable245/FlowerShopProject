using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowerShop.Data.Data.Migrations
{
    public partial class CascadeSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlowerSales_Users_UserId",
                table: "FlowerSales");

            migrationBuilder.AddForeignKey(
                name: "FK_FlowerSales_Users_UserId",
                table: "FlowerSales",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlowerSales_Users_UserId",
                table: "FlowerSales");

            migrationBuilder.AddForeignKey(
                name: "FK_FlowerSales_Users_UserId",
                table: "FlowerSales",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
