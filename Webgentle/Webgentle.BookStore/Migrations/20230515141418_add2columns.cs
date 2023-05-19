using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webgentle.BookStore.Migrations
{
    public partial class add2columns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "Books",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Books",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Books");
        }
    }
}