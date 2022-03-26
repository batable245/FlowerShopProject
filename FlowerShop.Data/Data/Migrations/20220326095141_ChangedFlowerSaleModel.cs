using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowerShop.Data.Data.Migrations
{
    public partial class ChangedFlowerSaleModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlowerSales_Flowers_FlowerId",
                table: "FlowerSales");

            migrationBuilder.DropForeignKey(
                name: "FK_FlowerSales_Users_UserId",
                table: "FlowerSales");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "FlowerSales",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FlowerId",
                table: "FlowerSales",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FlowerSales_Flowers_FlowerId",
                table: "FlowerSales",
                column: "FlowerId",
                principalTable: "Flowers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_FlowerSales_Flowers_FlowerId",
                table: "FlowerSales");

            migrationBuilder.DropForeignKey(
                name: "FK_FlowerSales_Users_UserId",
                table: "FlowerSales");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "FlowerSales",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FlowerId",
                table: "FlowerSales",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_FlowerSales_Flowers_FlowerId",
                table: "FlowerSales",
                column: "FlowerId",
                principalTable: "Flowers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
