using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webgentle.BookStore.Migrations
{
    public partial class updateColName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookGalleries_Books_BookId",
                table: "BookGalleries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookGalleries",
                table: "BookGalleries");

            migrationBuilder.RenameTable(
                name: "BookGalleries",
                newName: "BookGallery");

            migrationBuilder.RenameIndex(
                name: "IX_BookGalleries_BookId",
                table: "BookGallery",
                newName: "IX_BookGallery_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookGallery",
                table: "BookGallery",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookGallery_Books_BookId",
                table: "BookGallery",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookGallery_Books_BookId",
                table: "BookGallery");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookGallery",
                table: "BookGallery");

            migrationBuilder.RenameTable(
                name: "BookGallery",
                newName: "BookGalleries");

            migrationBuilder.RenameIndex(
                name: "IX_BookGallery_BookId",
                table: "BookGalleries",
                newName: "IX_BookGalleries_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookGalleries",
                table: "BookGalleries",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookGalleries_Books_BookId",
                table: "BookGalleries",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
