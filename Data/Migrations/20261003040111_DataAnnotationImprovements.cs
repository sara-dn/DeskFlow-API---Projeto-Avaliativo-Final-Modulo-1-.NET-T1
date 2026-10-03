using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeskFlow.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class DataAnnotationImprovements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interactions_Tickets_TicketId",
                table: "Interactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Categories_CategoryId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Tickets",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Tickets",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Solution",
                table: "Tickets",
                newName: "solution");

            migrationBuilder.RenameColumn(
                name: "Priority",
                table: "Tickets",
                newName: "priority");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Tickets",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "RequesterName",
                table: "Tickets",
                newName: "requester_name");

            migrationBuilder.RenameColumn(
                name: "OpenedDate",
                table: "Tickets",
                newName: "opened_date");

            migrationBuilder.RenameColumn(
                name: "ClosedDate",
                table: "Tickets",
                newName: "closed_date");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Tickets",
                newName: "category_id");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_CategoryId",
                table: "Tickets",
                newName: "IX_Tickets_category_id");

            migrationBuilder.RenameColumn(
                name: "Message",
                table: "Interactions",
                newName: "message");

            migrationBuilder.RenameColumn(
                name: "Author",
                table: "Interactions",
                newName: "author");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Interactions",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "TicketId",
                table: "Interactions",
                newName: "ticket_id");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Interactions",
                newName: "created_date");

            migrationBuilder.RenameIndex(
                name: "IX_Interactions_TicketId",
                table: "Interactions",
                newName: "IX_Interactions_ticket_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categories",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categories",
                newName: "id");

            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "Tickets",
                type: "varchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "Tickets",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "solution",
                table: "Tickets",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "priority",
                table: "Tickets",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Tickets",
                type: "varchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "requester_name",
                table: "Tickets",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "opened_date",
                table: "Tickets",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "closed_date",
                table: "Tickets",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "message",
                table: "Interactions",
                type: "varchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "author",
                table: "Interactions",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "Interactions",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Categories",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Interactions_Tickets_ticket_id",
                table: "Interactions",
                column: "ticket_id",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Categories_category_id",
                table: "Tickets",
                column: "category_id",
                principalTable: "Categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interactions_Tickets_ticket_id",
                table: "Interactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Categories_category_id",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Tickets",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Tickets",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "solution",
                table: "Tickets",
                newName: "Solution");

            migrationBuilder.RenameColumn(
                name: "priority",
                table: "Tickets",
                newName: "Priority");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Tickets",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "requester_name",
                table: "Tickets",
                newName: "RequesterName");

            migrationBuilder.RenameColumn(
                name: "opened_date",
                table: "Tickets",
                newName: "OpenedDate");

            migrationBuilder.RenameColumn(
                name: "closed_date",
                table: "Tickets",
                newName: "ClosedDate");

            migrationBuilder.RenameColumn(
                name: "category_id",
                table: "Tickets",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_category_id",
                table: "Tickets",
                newName: "IX_Tickets_CategoryId");

            migrationBuilder.RenameColumn(
                name: "message",
                table: "Interactions",
                newName: "Message");

            migrationBuilder.RenameColumn(
                name: "author",
                table: "Interactions",
                newName: "Author");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Interactions",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ticket_id",
                table: "Interactions",
                newName: "TicketId");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "Interactions",
                newName: "CreatedDate");

            migrationBuilder.RenameIndex(
                name: "IX_Interactions_ticket_id",
                table: "Interactions",
                newName: "IX_Interactions_TicketId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Categories",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Categories",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Solution",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Priority",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "RequesterName",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "OpenedDate",
                table: "Tickets",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ClosedDate",
                table: "Tickets",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Interactions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Author",
                table: "Interactions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Interactions",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddForeignKey(
                name: "FK_Interactions_Tickets_TicketId",
                table: "Interactions",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Categories_CategoryId",
                table: "Tickets",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
