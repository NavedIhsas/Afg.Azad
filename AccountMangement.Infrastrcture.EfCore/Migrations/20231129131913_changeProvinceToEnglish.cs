using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountManagement.Infrastructure.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class changeProvinceToEnglish : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Name",
                value: "Kabul");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Name",
                value: "Herat");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Name",
                value: "Balkh");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Name",
                value: "Ghazni");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Name",
                value: "Bamyan");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Name",
                value: "Badghis");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Name",
                value: "Daykundi");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 9L,
                column: "Name",
                value: "Urozgan");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 10L,
                column: "Name",
                value: "Farah");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 11L,
                column: "Name",
                value: "Faryab");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 12L,
                column: "Name",
                value: "Paktia");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 13L,
                column: "Name",
                value: "Paktika");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 14L,
                column: "Name",
                value: "Samangan");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 15L,
                column: "Name",
                value: "Nuristan");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 16L,
                column: "Name",
                value: "Badakhshan");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 17L,
                column: "Name",
                value: "Nimroz");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 19L,
                column: "Name",
                value: "Ghor");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 20L,
                column: "Name",
                value: "Helmand");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 21L,
                column: "Name",
                value: "Logar");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 22L,
                column: "Name",
                value: "Parwan");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 23L,
                column: "Name",
                value: "Maidan Wardak");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 24L,
                column: "Name",
                value: "Baghlan");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 25L,
                column: "Name",
                value: "Panjshir");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 26L,
                column: "Name",
                value: "Khost");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 27L,
                column: "Name",
                value: "Zabul");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 28L,
                column: "Name",
                value: "Sar-e Pol");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 29L,
                column: "Name",
                value: "Kapisa");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 30L,
                column: "Name",
                value: "Laghman");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 32L,
                column: "Name",
                value: "Nangarhar");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 33L,
                column: "Name",
                value: "Konar");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 34L,
                column: "Name",
                value: "Kunduz");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 35L,
                column: "Name",
                value: "Kandahar");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Name",
                value: "کابل");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Name",
                value: "هرات");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Name",
                value: "بلخ");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Name",
                value: "غزنی");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Name",
                value: "بامیان");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Name",
                value: "بادغیس");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Name",
                value: "دایکندی");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 9L,
                column: "Name",
                value: "ارزگان");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 10L,
                column: "Name",
                value: "فاریاب");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 11L,
                column: "Name",
                value: "فراه");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 12L,
                column: "Name",
                value: "پکتیا");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 13L,
                column: "Name",
                value: "پکتیکا");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 14L,
                column: "Name",
                value: "سمنگان");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 15L,
                column: "Name",
                value: "نورسان");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 16L,
                column: "Name",
                value: "بدخشان");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 17L,
                column: "Name",
                value: "نمیروز");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 19L,
                column: "Name",
                value: "غور");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 20L,
                column: "Name",
                value: "هلمند");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 21L,
                column: "Name",
                value: "لوگر");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 22L,
                column: "Name",
                value: "پروان");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 23L,
                column: "Name",
                value: "میدان وردک");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 24L,
                column: "Name",
                value: "بغلان");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 25L,
                column: "Name",
                value: "پنجشیر");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 26L,
                column: "Name",
                value: "خوست");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 27L,
                column: "Name",
                value: "زابل");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 28L,
                column: "Name",
                value: "سرپل");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 29L,
                column: "Name",
                value: "کاپیسا");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 30L,
                column: "Name",
                value: "لغمان");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 32L,
                column: "Name",
                value: "ننگرهار");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 33L,
                column: "Name",
                value: "کنر");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 34L,
                column: "Name",
                value: "کندز");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 35L,
                column: "Name",
                value: "قندهار");

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
    }
}
