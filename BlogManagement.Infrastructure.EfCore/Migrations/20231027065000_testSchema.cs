using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogManagement.Infrastructure.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class testSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "NewsPictures",
                newName: "NewsPictures",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Newses",
                newName: "Newses",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Articles",
                newName: "Articles",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "ArticlePictures",
                newName: "ArticlePictures",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "ArticleCategories",
                newName: "ArticleCategories",
                newSchema: "dbo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "NewsPictures",
                schema: "dbo",
                newName: "NewsPictures");

            migrationBuilder.RenameTable(
                name: "Newses",
                schema: "dbo",
                newName: "Newses");

            migrationBuilder.RenameTable(
                name: "Articles",
                schema: "dbo",
                newName: "Articles");

            migrationBuilder.RenameTable(
                name: "ArticlePictures",
                schema: "dbo",
                newName: "ArticlePictures");

            migrationBuilder.RenameTable(
                name: "ArticleCategories",
                schema: "dbo",
                newName: "ArticleCategories");
        }
    }
}
