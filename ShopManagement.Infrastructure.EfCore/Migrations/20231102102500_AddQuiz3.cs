using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopManagement.Infrastructure.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class AddQuiz3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuizStatus",
                schema: "dbo",
                table: "Questions");

            migrationBuilder.AddColumn<int>(
                name: "QuizStatus",
                schema: "dbo",
                table: "Quizzes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuizStatus",
                schema: "dbo",
                table: "Quizzes");

            migrationBuilder.AddColumn<int>(
                name: "QuizStatus",
                schema: "dbo",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
