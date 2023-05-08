using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class ReceiptAndProductNewFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityID",
                table: "ReceiptsAndProducts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DeliveryCompanyID",
                table: "ReceiptsAndProducts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FactoryID",
                table: "ReceiptsAndProducts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CityID",
                table: "ReceiptsAndProducts");

            migrationBuilder.DropColumn(
                name: "DeliveryCompanyID",
                table: "ReceiptsAndProducts");

            migrationBuilder.DropColumn(
                name: "FactoryID",
                table: "ReceiptsAndProducts");
        }
    }
}
