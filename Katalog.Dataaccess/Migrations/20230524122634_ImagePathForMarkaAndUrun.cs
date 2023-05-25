using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Katalog.Dataaccess.Migrations
{
    public partial class ImagePathForMarkaAndUrun : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Resim",
                table: "Urunler",
                newName: "ImagePath");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Markalar",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Markalar");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Urunler",
                newName: "Resim");
        }
    }
}
