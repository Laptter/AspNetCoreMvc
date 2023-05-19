using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webgentle.BookStore.Migrations
{
    public partial class AddLanguaegIDWithBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Language",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "LanguageID",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LanguageID",
                table: "Books");

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}