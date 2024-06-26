using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopManagement.Infrastructure.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class AddQuiz2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                schema: "dbo",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Courses_CourseId",
                schema: "dbo",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Answers_QuestionId",
                schema: "dbo",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "AccountId",
                schema: "dbo",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Body",
                schema: "dbo",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "IsTrue",
                schema: "dbo",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                schema: "dbo",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "dbo",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Slug",
                schema: "dbo",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Title",
                schema: "dbo",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                schema: "dbo",
                table: "Questions",
                newName: "QuizId");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_CourseId",
                schema: "dbo",
                table: "Questions",
                newName: "IX_Questions_QuizId");

            migrationBuilder.AddColumn<string>(
                name: "CorrectAnswer",
                schema: "dbo",
                table: "Questions",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CorrectAnswerPoints",
                schema: "dbo",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FirstOption",
                schema: "dbo",
                table: "Questions",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FourthOption",
                schema: "dbo",
                table: "Questions",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QuestionName",
                schema: "dbo",
                table: "Questions",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "QuizStatus",
                schema: "dbo",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SecondOption",
                schema: "dbo",
                table: "Questions",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThirdOption",
                schema: "dbo",
                table: "Questions",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Quizzes",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KeyWord = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    MetaDes = table.Column<string>(type: "nvarchar(170)", maxLength: 170, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    OnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PeriodTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizzes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quizzes_Courses_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "dbo",
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserResults",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuizId = table.Column<long>(type: "bigint", nullable: false),
                    UsersCorrectAnswers = table.Column<int>(type: "int", nullable: false),
                    UsersWrongAnswers = table.Column<int>(type: "int", nullable: false),
                    PointsEarned = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserResults_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalSchema: "dbo",
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_CourseId",
                schema: "dbo",
                table: "Quizzes",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserResults_QuizId",
                schema: "dbo",
                table: "UserResults",
                column: "QuizId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Quizzes_QuizId",
                schema: "dbo",
                table: "Questions",
                column: "QuizId",
                principalSchema: "dbo",
                principalTable: "Quizzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Quizzes_QuizId",
                schema: "dbo",
                table: "Questions");

            migrationBuilder.DropTable(
                name: "UserResults",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Quizzes",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "CorrectAnswer",
                schema: "dbo",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "CorrectAnswerPoints",
                schema: "dbo",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "FirstOption",
                schema: "dbo",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "FourthOption",
                schema: "dbo",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "QuestionName",
                schema: "dbo",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "QuizStatus",
                schema: "dbo",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "SecondOption",
                schema: "dbo",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "ThirdOption",
                schema: "dbo",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "QuizId",
                schema: "dbo",
                table: "Questions",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_QuizId",
                schema: "dbo",
                table: "Questions",
                newName: "IX_Questions_CourseId");

            migrationBuilder.AddColumn<long>(
                name: "AccountId",
                schema: "dbo",
                table: "Questions",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Body",
                schema: "dbo",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsTrue",
                schema: "dbo",
                table: "Questions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                schema: "dbo",
                table: "Questions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "Questions",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                schema: "dbo",
                table: "Questions",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                schema: "dbo",
                table: "Questions",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                schema: "dbo",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                schema: "dbo",
                table: "Answers",
                column: "QuestionId",
                principalSchema: "dbo",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Courses_CourseId",
                schema: "dbo",
                table: "Questions",
                column: "CourseId",
                principalSchema: "dbo",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
