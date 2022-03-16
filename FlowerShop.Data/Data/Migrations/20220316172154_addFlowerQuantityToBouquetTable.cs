using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowerShop.Data.Data.Migrations
{
    public partial class addFlowerQuantityToBouquetTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FlowerQuantity",
                table: "Bouquets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlowerQuantity",
                table: "Bouquets");
        }
    }
}
