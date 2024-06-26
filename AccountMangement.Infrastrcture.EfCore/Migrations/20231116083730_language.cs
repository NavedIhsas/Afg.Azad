using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountManagement.Infrastructure.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class language : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "LanguageId",
                schema: "dbo",
                table: "Users",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LanguageId",
                schema: "dbo",
                table: "UserInfo",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LanguageId",
                schema: "dbo",
                table: "Roles",
                type: "bigint",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreationDate", "LanguageId" },
                values: new object[] { new DateTime(2023, 11, 16, 12, 7, 29, 921, DateTimeKind.Local).AddTicks(7734), null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreationDate", "LanguageId" },
                values: new object[] { new DateTime(2023, 11, 16, 12, 7, 29, 921, DateTimeKind.Local).AddTicks(7859), null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreationDate", "LanguageId" },
                values: new object[] { new DateTime(2023, 11, 16, 12, 7, 29, 921, DateTimeKind.Local).AddTicks(7863), null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreationDate", "LanguageId" },
                values: new object[] { new DateTime(2023, 11, 16, 12, 7, 29, 921, DateTimeKind.Local).AddTicks(7866), null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreationDate", "LanguageId" },
                values: new object[] { new DateTime(2023, 11, 16, 12, 7, 29, 921, DateTimeKind.Local).AddTicks(7868), null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreationDate", "LanguageId" },
                values: new object[] { new DateTime(2023, 11, 16, 12, 7, 29, 921, DateTimeKind.Local).AddTicks(7870), null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreationDate", "Email", "LanguageId", "Password" },
                values: new object[] { new DateTime(2023, 11, 16, 12, 7, 29, 919, DateTimeKind.Local).AddTicks(1569), "qodratullahahsas@gmail.com", null, "10000.Pu72WlGJfxm4DtUFgPs3jg==.xC1HshLh+dcDIXRlgzVO3dPJ3Ymn/h+Oq13Nn7mVBig=" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LanguageId",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                schema: "dbo",
                table: "UserInfo");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                schema: "dbo",
                table: "Roles");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2023, 11, 10, 12, 15, 30, 567, DateTimeKind.Local).AddTicks(4943));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2023, 11, 10, 12, 15, 30, 567, DateTimeKind.Local).AddTicks(4963));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationDate",
                value: new DateTime(2023, 11, 10, 12, 15, 30, 567, DateTimeKind.Local).AddTicks(4966));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationDate",
                value: new DateTime(2023, 11, 10, 12, 15, 30, 567, DateTimeKind.Local).AddTicks(4967));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationDate",
                value: new DateTime(2023, 11, 10, 12, 15, 30, 567, DateTimeKind.Local).AddTicks(4969));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreationDate",
                value: new DateTime(2023, 11, 10, 12, 15, 30, 567, DateTimeKind.Local).AddTicks(5000));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreationDate", "Email", "Password" },
                values: new object[] { new DateTime(2023, 11, 10, 12, 15, 30, 566, DateTimeKind.Local).AddTicks(4381), "navedahsas77@gmail.com", "10000.ApVvliODuOhK4qeQx5wSRQ==.ajmQFz17z6nDVFVwcDj/b4IY5Hly8L7BQa6YAfNO85s=" });
        }
    }
}
