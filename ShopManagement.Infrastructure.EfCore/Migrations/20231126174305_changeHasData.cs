using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopManagement.Infrastructure.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class changeHasData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "CourseLevels",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "LanguageId", "Title" },
                values: new object[] { 2L, "Introductory" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "CourseLevels",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "LanguageId", "Title" },
                values: new object[] { 2L, "Intermediate" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "CourseLevels",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "LanguageId", "Title" },
                values: new object[] { 2L, "Advanced" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "CourseStatus",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "LanguageId", "Title" },
                values: new object[] { 2L, "In Progress" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "CourseStatus",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "LanguageId", "Title" },
                values: new object[] { 2L, "Formed" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "CourseStatus",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "LanguageId", "Title" },
                values: new object[] { 2L, "Completed" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "CourseLevels",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "LanguageId", "Title" },
                values: new object[] { null, "مقدماتی" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "CourseLevels",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "LanguageId", "Title" },
                values: new object[] { null, "متوسط" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "CourseLevels",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "LanguageId", "Title" },
                values: new object[] { null, "پیشرفته" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "CourseStatus",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "LanguageId", "Title" },
                values: new object[] { null, "در حال برگذاری" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "CourseStatus",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "LanguageId", "Title" },
                values: new object[] { null, "تشکیل شده" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "CourseStatus",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "LanguageId", "Title" },
                values: new object[] { null, "اتمام" });
        }
    }
}
