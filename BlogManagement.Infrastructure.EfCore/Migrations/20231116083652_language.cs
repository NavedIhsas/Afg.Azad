using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogManagement.Infrastructure.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class language : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "LanguageId",
                schema: "dbo",
                table: "Newses",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LanguageId",
                schema: "dbo",
                table: "Articles",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LanguageId",
                schema: "dbo",
                table: "ArticleCategories",
                type: "bigint",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LanguageId",
                schema: "dbo",
                table: "Newses");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                schema: "dbo",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                schema: "dbo",
                table: "ArticleCategories");
        }
    }
}
