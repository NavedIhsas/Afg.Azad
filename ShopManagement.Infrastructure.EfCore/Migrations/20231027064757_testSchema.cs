using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopManagement.Infrastructure.EfCore.Migrations
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
                name: "VisitorVersions",
                newName: "VisitorVersions",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Visitors",
                newName: "Visitors",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "UserCourses",
                newName: "UserCourses",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "ToBeLearn",
                newName: "ToBeLearn",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Questions",
                newName: "Questions",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Orders",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "OrderDetails",
                newName: "OrderDetails",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "OnlineVisitors",
                newName: "OnlineVisitors",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "NeedToLearn",
                newName: "NeedToLearn",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Devices",
                newName: "Devices",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "CourseStatus",
                newName: "CourseStatus",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "Courses",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "CourseLevels",
                newName: "CourseLevels",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "CourseGroups",
                newName: "CourseGroups",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "CourseEpisodes",
                newName: "CourseEpisodes",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Answers",
                newName: "Answers",
                newSchema: "dbo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "VisitorVersions",
                schema: "dbo",
                newName: "VisitorVersions");

            migrationBuilder.RenameTable(
                name: "Visitors",
                schema: "dbo",
                newName: "Visitors");

            migrationBuilder.RenameTable(
                name: "UserCourses",
                schema: "dbo",
                newName: "UserCourses");

            migrationBuilder.RenameTable(
                name: "ToBeLearn",
                schema: "dbo",
                newName: "ToBeLearn");

            migrationBuilder.RenameTable(
                name: "Questions",
                schema: "dbo",
                newName: "Questions");

            migrationBuilder.RenameTable(
                name: "Orders",
                schema: "dbo",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "OrderDetails",
                schema: "dbo",
                newName: "OrderDetails");

            migrationBuilder.RenameTable(
                name: "OnlineVisitors",
                schema: "dbo",
                newName: "OnlineVisitors");

            migrationBuilder.RenameTable(
                name: "NeedToLearn",
                schema: "dbo",
                newName: "NeedToLearn");

            migrationBuilder.RenameTable(
                name: "Devices",
                schema: "dbo",
                newName: "Devices");

            migrationBuilder.RenameTable(
                name: "CourseStatus",
                schema: "dbo",
                newName: "CourseStatus");

            migrationBuilder.RenameTable(
                name: "Courses",
                schema: "dbo",
                newName: "Courses");

            migrationBuilder.RenameTable(
                name: "CourseLevels",
                schema: "dbo",
                newName: "CourseLevels");

            migrationBuilder.RenameTable(
                name: "CourseGroups",
                schema: "dbo",
                newName: "CourseGroups");

            migrationBuilder.RenameTable(
                name: "CourseEpisodes",
                schema: "dbo",
                newName: "CourseEpisodes");

            migrationBuilder.RenameTable(
                name: "Answers",
                schema: "dbo",
                newName: "Answers");
        }
    }
}
