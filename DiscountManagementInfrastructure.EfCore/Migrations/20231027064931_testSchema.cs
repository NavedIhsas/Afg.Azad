using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiscountManagementInfrastructure.EfCore.Migrations
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
                name: "UserDiscounts",
                newName: "UserDiscounts",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "DiscountCodes",
                newName: "DiscountCodes",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "CustomerDiscounts",
                newName: "CustomerDiscounts",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "ColleagueDiscounts",
                newName: "ColleagueDiscounts",
                newSchema: "dbo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "UserDiscounts",
                schema: "dbo",
                newName: "UserDiscounts");

            migrationBuilder.RenameTable(
                name: "DiscountCodes",
                schema: "dbo",
                newName: "DiscountCodes");

            migrationBuilder.RenameTable(
                name: "CustomerDiscounts",
                schema: "dbo",
                newName: "CustomerDiscounts");

            migrationBuilder.RenameTable(
                name: "ColleagueDiscounts",
                schema: "dbo",
                newName: "ColleagueDiscounts");
        }
    }
}
