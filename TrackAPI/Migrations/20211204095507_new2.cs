using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackAPI.Migrations
{
    public partial class new2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CountryofOrigin",
                table: "Item",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryLocation",
                table: "Item",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discription",
                table: "Item",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Wieght",
                table: "Item",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryofOrigin",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "DeliveryLocation",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Discription",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Wieght",
                table: "Item");
        }
    }
}
