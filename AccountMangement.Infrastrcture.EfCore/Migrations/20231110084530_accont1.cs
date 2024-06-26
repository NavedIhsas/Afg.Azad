using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AccountManagement.Infrastructure.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class accont1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Provinces",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProvinceId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalSchema: "dbo",
                        principalTable: "Provinces",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    EmailConfirm = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    Gander = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CityId = table.Column<long>(type: "bigint", nullable: true),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutMe = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ActiveCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "dbo",
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserInfo",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NationalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NationalPhoto = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    PersonalPhoto = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    FatherName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccountId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserInfo_Users_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTeachers",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Skills = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Resumes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    AccountId = table.Column<long>(type: "bigint", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTeachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTeachers_Users_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Provinces",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 2L, "کابل" },
                    { 3L, "هرات" },
                    { 4L, "بلخ" },
                    { 5L, "غزنی" },
                    { 6L, "بامیان" },
                    { 7L, "بادغیس" },
                    { 8L, "دایکندی" },
                    { 9L, "ارزگان" },
                    { 10L, "فاریاب" },
                    { 11L, "فراه" },
                    { 12L, "پکتیا" },
                    { 13L, "پکتیکا" },
                    { 14L, "سمنگان" },
                    { 15L, "نورسان" },
                    { 16L, "بدخشان" },
                    { 17L, "نمیروز" },
                    { 19L, "غور" },
                    { 20L, "هلمند" },
                    { 21L, "لوگر" },
                    { 22L, "پروان" },
                    { 23L, "میدان وردک" },
                    { 24L, "بغلان" },
                    { 25L, "پنجشیر" },
                    { 26L, "خوست" },
                    { 27L, "زابل" },
                    { 28L, "سرپل" },
                    { 29L, "کاپیسا" },
                    { 30L, "لغمان" },
                    { 32L, "ننگرهار" },
                    { 33L, "کنر" },
                    { 34L, "کندز" },
                    { 35L, "قندهار" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "CreationDate", "Name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 11, 10, 12, 15, 30, 567, DateTimeKind.Local).AddTicks(4943), "مدیر سایت" },
                    { 2L, new DateTime(2023, 11, 10, 12, 15, 30, 567, DateTimeKind.Local).AddTicks(4963), "استاد" },
                    { 3L, new DateTime(2023, 11, 10, 12, 15, 30, 567, DateTimeKind.Local).AddTicks(4966), "ادمین" },
                    { 4L, new DateTime(2023, 11, 10, 12, 15, 30, 567, DateTimeKind.Local).AddTicks(4967), "کاربر عادی" },
                    { 5L, new DateTime(2023, 11, 10, 12, 15, 30, 567, DateTimeKind.Local).AddTicks(4969), "بلاگر" },
                    { 6L, new DateTime(2023, 11, 10, 12, 15, 30, 567, DateTimeKind.Local).AddTicks(5000), "بدون احراز" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Users",
                columns: new[] { "Id", "AboutMe", "ActiveCode", "Area", "Avatar", "BirthDate", "CityId", "CreationDate", "Email", "EmailConfirm", "FirstName", "Gander", "IsActive", "IsDelete", "LastName", "Password", "Phone", "RoleId" },
                values: new object[] { 1L, "", "", "", "", new DateTime(1997, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 11, 10, 12, 15, 30, 566, DateTimeKind.Local).AddTicks(4381), "navedahsas77@gmail.com", true, "نوید", "مرد", true, false, "احساس", "10000.ApVvliODuOhK4qeQx5wSRQ==.ajmQFz17z6nDVFVwcDj/b4IY5Hly8L7BQa6YAfNO85s=", "077***", 6L });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_ProvinceId",
                schema: "dbo",
                table: "Cities",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_RoleId",
                schema: "dbo",
                table: "RolePermissions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInfo_AccountId",
                schema: "dbo",
                table: "UserInfo",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_CityId",
                schema: "dbo",
                table: "Users",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                schema: "dbo",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTeachers_AccountId",
                schema: "dbo",
                table: "UserTeachers",
                column: "AccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolePermissions",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserInfo",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserTeachers",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Cities",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Provinces",
                schema: "dbo");
        }
    }
}
