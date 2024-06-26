using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopManagement.Infrastructure.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class onDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_onlineCourses_Courses_CourseId",
                schema: "Tbl",
                table: "onlineCourses");

            migrationBuilder.AddForeignKey(
                name: "FK_onlineCourses_Courses_CourseId",
                schema: "Tbl",
                table: "onlineCourses",
                column: "CourseId",
                principalSchema: "dbo",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_onlineCourses_Courses_CourseId",
                schema: "Tbl",
                table: "onlineCourses");

            migrationBuilder.AddForeignKey(
                name: "FK_onlineCourses_Courses_CourseId",
                schema: "Tbl",
                table: "onlineCourses",
                column: "CourseId",
                principalSchema: "dbo",
                principalTable: "Courses",
                principalColumn: "Id");
        }
    }
}
