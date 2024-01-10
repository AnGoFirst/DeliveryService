using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Delivery.Migrations
{
    public partial class purchaseStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductStatus",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ProductStatus",
                table: "Purchases",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductStatus",
                table: "Purchases");

            migrationBuilder.AddColumn<int>(
                name: "ProductStatus",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
