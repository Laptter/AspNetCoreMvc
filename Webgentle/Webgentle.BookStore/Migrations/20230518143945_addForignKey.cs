using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webgentle.BookStore.Migrations
{
    public partial class addForignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Books_LanguageID",
                table: "Books",
                column: "LanguageID");

            migrationBuilder.CreateIndex(
                name: "IX_BookGalleries_BookId",
                table: "BookGalleries",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookGalleries_Books_BookId",
                table: "BookGalleries",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Languagess_LanguageID",
                table: "Books",
                column: "LanguageID",
                principalTable: "Languagess",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookGalleries_Books_BookId",
                table: "BookGalleries");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Languagess_LanguageID",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_LanguageID",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_BookGalleries_BookId",
                table: "BookGalleries");
        }
    }
}