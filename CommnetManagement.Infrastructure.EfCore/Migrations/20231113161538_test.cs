using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommentManagement.Infrastructure.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "Visits",
                newName: "Visits",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Sliders",
                newName: "Sliders",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Notifications",
                newName: "Notifications",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Comments",
                newSchema: "dbo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Visits",
                schema: "dbo",
                newName: "Visits");

            migrationBuilder.RenameTable(
                name: "Sliders",
                schema: "dbo",
                newName: "Sliders");

            migrationBuilder.RenameTable(
                name: "Notifications",
                schema: "dbo",
                newName: "Notifications");

            migrationBuilder.RenameTable(
                name: "Comments",
                schema: "dbo",
                newName: "Comments");
        }
    }
}
