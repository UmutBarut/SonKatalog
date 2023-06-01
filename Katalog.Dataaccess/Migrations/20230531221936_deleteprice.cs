using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Katalog.Dataaccess.Migrations
{
    public partial class deleteprice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Urunler");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Urunler",
                type: "int",
                nullable: true);
        }
    }
}
