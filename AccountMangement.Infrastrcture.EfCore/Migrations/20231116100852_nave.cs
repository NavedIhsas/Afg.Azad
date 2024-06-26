using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountManagement.Infrastructure.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class nave : Migration
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
                value: new DateTime(2023, 11, 16, 13, 38, 52, 148, DateTimeKind.Local).AddTicks(3081));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2023, 11, 16, 13, 38, 52, 148, DateTimeKind.Local).AddTicks(3124));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationDate",
                value: new DateTime(2023, 11, 16, 13, 38, 52, 148, DateTimeKind.Local).AddTicks(3127));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationDate",
                value: new DateTime(2023, 11, 16, 13, 38, 52, 148, DateTimeKind.Local).AddTicks(3130));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationDate",
                value: new DateTime(2023, 11, 16, 13, 38, 52, 148, DateTimeKind.Local).AddTicks(3132));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreationDate",
                value: new DateTime(2023, 11, 16, 13, 38, 52, 148, DateTimeKind.Local).AddTicks(3135));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreationDate", "Password" },
                values: new object[] { new DateTime(2023, 11, 16, 13, 38, 52, 146, DateTimeKind.Local).AddTicks(3057), "10000.0F4bDmE0wO9bVVK2dsyFNA==.cH2aJXBo2FP0LLJsVM81DC7yTX175SVqHGdeOSJfhoM=" });
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
                value: new DateTime(2023, 11, 16, 12, 7, 29, 921, DateTimeKind.Local).AddTicks(7734));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationDate",
                value: new DateTime(2023, 11, 16, 12, 7, 29, 921, DateTimeKind.Local).AddTicks(7859));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationDate",
                value: new DateTime(2023, 11, 16, 12, 7, 29, 921, DateTimeKind.Local).AddTicks(7863));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationDate",
                value: new DateTime(2023, 11, 16, 12, 7, 29, 921, DateTimeKind.Local).AddTicks(7866));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationDate",
                value: new DateTime(2023, 11, 16, 12, 7, 29, 921, DateTimeKind.Local).AddTicks(7868));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreationDate",
                value: new DateTime(2023, 11, 16, 12, 7, 29, 921, DateTimeKind.Local).AddTicks(7870));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreationDate", "Password" },
                values: new object[] { new DateTime(2023, 11, 16, 12, 7, 29, 919, DateTimeKind.Local).AddTicks(1569), "10000.Pu72WlGJfxm4DtUFgPs3jg==.xC1HshLh+dcDIXRlgzVO3dPJ3Ymn/h+Oq13Nn7mVBig=" });
        }
    }
}
