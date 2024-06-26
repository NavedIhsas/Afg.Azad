using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopManagement.Infrastructure.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class addLan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "LanguageId",
                schema: "dbo",
                table: "CourseStatus",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LanguageId",
                schema: "dbo",
                table: "CourseLevels",
                type: "bigint",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "CourseLevels",
                keyColumn: "Id",
                keyValue: 1L,
                column: "LanguageId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "CourseLevels",
                keyColumn: "Id",
                keyValue: 2L,
                column: "LanguageId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "CourseLevels",
                keyColumn: "Id",
                keyValue: 3L,
                column: "LanguageId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "CourseStatus",
                keyColumn: "Id",
                keyValue: 1L,
                column: "LanguageId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "CourseStatus",
                keyColumn: "Id",
                keyValue: 2L,
                column: "LanguageId",
                value: null);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "CourseStatus",
                keyColumn: "Id",
                keyValue: 3L,
                column: "LanguageId",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LanguageId",
                schema: "dbo",
                table: "CourseStatus");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                schema: "dbo",
                table: "CourseLevels");
        }
    }
}
