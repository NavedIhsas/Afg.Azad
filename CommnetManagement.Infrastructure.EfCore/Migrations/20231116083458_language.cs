﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommentManagement.Infrastructure.EfCore.Migrations
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
                table: "Visits",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LanguageId",
                schema: "dbo",
                table: "Sliders",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LanguageId",
                schema: "dbo",
                table: "Notifications",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LanguageId",
                schema: "dbo",
                table: "Comments",
                type: "bigint",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LanguageId",
                schema: "dbo",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                schema: "dbo",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                schema: "dbo",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                schema: "dbo",
                table: "Comments");
        }
    }
}
