using Microsoft.EntityFrameworkCore.Migrations;

namespace Zomato.DomainModel.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "Order",
                newName: "RestauratnId");

            migrationBuilder.AddColumn<string>(
                name: "UserLocation",
                table: "Order",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserLocation",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "RestauratnId",
                table: "Order",
                newName: "LocationId");
        }
    }
}
