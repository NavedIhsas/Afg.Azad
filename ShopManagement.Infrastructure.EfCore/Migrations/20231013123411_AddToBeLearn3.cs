using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopManagement.Infrastructure.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class AddToBeLearn3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ToBeLearns_Capacity",
                table: "Courses");

            migrationBuilder.CreateTable(
                name: "ToBeLearn",
                columns: table => new
                {
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToBeLearn", x => new { x.CourseId, x.Id });
                    table.ForeignKey(
                        name: "FK_ToBeLearn_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToBeLearn");

            migrationBuilder.AddColumn<int>(
                name: "ToBeLearns_Capacity",
                table: "Courses",
                type: "int",
                nullable: true);
        }
    }
}
