using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopManagement.Infrastructure.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class AddToBeLearn1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CourseId",
                table: "ToBeLearns",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_ToBeLearns_CourseId",
                table: "ToBeLearns",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToBeLearns_Courses_CourseId",
                table: "ToBeLearns",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToBeLearns_Courses_CourseId",
                table: "ToBeLearns");

            migrationBuilder.DropIndex(
                name: "IX_ToBeLearns_CourseId",
                table: "ToBeLearns");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "ToBeLearns");
        }
    }
}
