using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeskFlow.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixDateTimeError : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "closed_date",
                table: "Tickets",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "closed_date",
                table: "Tickets",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
