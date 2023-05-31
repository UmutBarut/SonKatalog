using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Katalog.Dataaccess.Migrations
{
    public partial class price : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Urunler",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AdSoyad",
                table: "AspNetUsers",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Urunler");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "AdSoyad",
                keyValue: null,
                column: "AdSoyad",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "AdSoyad",
                table: "AspNetUsers",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
