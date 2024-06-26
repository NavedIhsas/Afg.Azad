using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountManagement.Infrastructure.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2023, 12, 2, 11, 58, 47, 144, DateTimeKind.Local).AddTicks(9319));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2023, 12, 2, 11, 58, 47, 144, DateTimeKind.Local).AddTicks(9348));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationDate",
                value: new DateTime(2023, 12, 2, 11, 58, 47, 144, DateTimeKind.Local).AddTicks(9354));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationDate",
                value: new DateTime(2023, 12, 2, 11, 58, 47, 144, DateTimeKind.Local).AddTicks(9357));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationDate",
                value: new DateTime(2023, 12, 2, 11, 58, 47, 144, DateTimeKind.Local).AddTicks(9361));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreationDate",
                value: new DateTime(2023, 12, 2, 11, 58, 47, 144, DateTimeKind.Local).AddTicks(9368));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreationDate", "Password" },
                values: new object[] { new DateTime(2023, 12, 2, 11, 58, 47, 143, DateTimeKind.Local).AddTicks(165), "10000.LrTzJb8TzEOEJmD6AlmZeQ==.QAl12DN9QMFNfpXnmCxRki7BTpXvzuga4GLb95ciK9w=" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationDate",
                value: new DateTime(2023, 11, 29, 16, 49, 13, 399, DateTimeKind.Local).AddTicks(4932));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2023, 11, 29, 16, 49, 13, 399, DateTimeKind.Local).AddTicks(4956));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationDate",
                value: new DateTime(2023, 11, 29, 16, 49, 13, 399, DateTimeKind.Local).AddTicks(4960));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationDate",
                value: new DateTime(2023, 11, 29, 16, 49, 13, 399, DateTimeKind.Local).AddTicks(4963));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationDate",
                value: new DateTime(2023, 11, 29, 16, 49, 13, 399, DateTimeKind.Local).AddTicks(4966));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreationDate",
                value: new DateTime(2023, 11, 29, 16, 49, 13, 399, DateTimeKind.Local).AddTicks(4969));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreationDate", "Password" },
                values: new object[] { new DateTime(2023, 11, 29, 16, 49, 13, 397, DateTimeKind.Local).AddTicks(3580), "10000.ttj/mhR+ofPOWq8c0+BWQg==.3Pd1A6lnuUYXT80E8mxcaqhksaXkpNqWnkeNIpOwQHM=" });
        }
    }
}
