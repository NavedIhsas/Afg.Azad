using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopManagement.Infrastructure.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class languageId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "LanguageId",
                schema: "dbo",
                table: "UserResults",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LanguageId",
                schema: "dbo",
                table: "UserCourses",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LanguageId",
                schema: "dbo",
                table: "Quizzes",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LanguageId",
                schema: "dbo",
                table: "Questions",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LanguageId",
                schema: "dbo",
                table: "Orders",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LanguageId",
                schema: "Tbl",
                table: "onlineCourses",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LanguageId",
                schema: "dbo",
                table: "Courses",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LanguageId",
                schema: "dbo",
                table: "CourseGroups",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LanguageId",
                schema: "dbo",
                table: "CourseEpisodes",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LanguageId",
                schema: "dbo",
                table: "Answers",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Language",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Culture = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserResults_LanguageId",
                schema: "dbo",
                table: "UserResults",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCourses_LanguageId",
                schema: "dbo",
                table: "UserCourses",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_LanguageId",
                schema: "dbo",
                table: "Quizzes",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_LanguageId",
                schema: "dbo",
                table: "Questions",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_LanguageId",
                schema: "dbo",
                table: "Orders",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_onlineCourses_LanguageId",
                schema: "Tbl",
                table: "onlineCourses",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_LanguageId",
                schema: "dbo",
                table: "Courses",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseGroups_LanguageId",
                schema: "dbo",
                table: "CourseGroups",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseEpisodes_LanguageId",
                schema: "dbo",
                table: "CourseEpisodes",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_LanguageId",
                schema: "dbo",
                table: "Answers",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Language_LanguageId",
                schema: "dbo",
                table: "Answers",
                column: "LanguageId",
                principalSchema: "dbo",
                principalTable: "Language",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseEpisodes_Language_LanguageId",
                schema: "dbo",
                table: "CourseEpisodes",
                column: "LanguageId",
                principalSchema: "dbo",
                principalTable: "Language",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseGroups_Language_LanguageId",
                schema: "dbo",
                table: "CourseGroups",
                column: "LanguageId",
                principalSchema: "dbo",
                principalTable: "Language",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Language_LanguageId",
                schema: "dbo",
                table: "Courses",
                column: "LanguageId",
                principalSchema: "dbo",
                principalTable: "Language",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_onlineCourses_Language_LanguageId",
                schema: "Tbl",
                table: "onlineCourses",
                column: "LanguageId",
                principalSchema: "dbo",
                principalTable: "Language",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Language_LanguageId",
                schema: "dbo",
                table: "Orders",
                column: "LanguageId",
                principalSchema: "dbo",
                principalTable: "Language",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Language_LanguageId",
                schema: "dbo",
                table: "Questions",
                column: "LanguageId",
                principalSchema: "dbo",
                principalTable: "Language",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Quizzes_Language_LanguageId",
                schema: "dbo",
                table: "Quizzes",
                column: "LanguageId",
                principalSchema: "dbo",
                principalTable: "Language",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourses_Language_LanguageId",
                schema: "dbo",
                table: "UserCourses",
                column: "LanguageId",
                principalSchema: "dbo",
                principalTable: "Language",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserResults_Language_LanguageId",
                schema: "dbo",
                table: "UserResults",
                column: "LanguageId",
                principalSchema: "dbo",
                principalTable: "Language",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Language_LanguageId",
                schema: "dbo",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseEpisodes_Language_LanguageId",
                schema: "dbo",
                table: "CourseEpisodes");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseGroups_Language_LanguageId",
                schema: "dbo",
                table: "CourseGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Language_LanguageId",
                schema: "dbo",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_onlineCourses_Language_LanguageId",
                schema: "Tbl",
                table: "onlineCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Language_LanguageId",
                schema: "dbo",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Language_LanguageId",
                schema: "dbo",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Quizzes_Language_LanguageId",
                schema: "dbo",
                table: "Quizzes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCourses_Language_LanguageId",
                schema: "dbo",
                table: "UserCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserResults_Language_LanguageId",
                schema: "dbo",
                table: "UserResults");

            migrationBuilder.DropTable(
                name: "Language",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_UserResults_LanguageId",
                schema: "dbo",
                table: "UserResults");

            migrationBuilder.DropIndex(
                name: "IX_UserCourses_LanguageId",
                schema: "dbo",
                table: "UserCourses");

            migrationBuilder.DropIndex(
                name: "IX_Quizzes_LanguageId",
                schema: "dbo",
                table: "Quizzes");

            migrationBuilder.DropIndex(
                name: "IX_Questions_LanguageId",
                schema: "dbo",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Orders_LanguageId",
                schema: "dbo",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_onlineCourses_LanguageId",
                schema: "Tbl",
                table: "onlineCourses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_LanguageId",
                schema: "dbo",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_CourseGroups_LanguageId",
                schema: "dbo",
                table: "CourseGroups");

            migrationBuilder.DropIndex(
                name: "IX_CourseEpisodes_LanguageId",
                schema: "dbo",
                table: "CourseEpisodes");

            migrationBuilder.DropIndex(
                name: "IX_Answers_LanguageId",
                schema: "dbo",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                schema: "dbo",
                table: "UserResults");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                schema: "dbo",
                table: "UserCourses");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                schema: "dbo",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                schema: "dbo",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                schema: "dbo",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                schema: "Tbl",
                table: "onlineCourses");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                schema: "dbo",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                schema: "dbo",
                table: "CourseGroups");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                schema: "dbo",
                table: "CourseEpisodes");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                schema: "dbo",
                table: "Answers");
        }
    }
}
