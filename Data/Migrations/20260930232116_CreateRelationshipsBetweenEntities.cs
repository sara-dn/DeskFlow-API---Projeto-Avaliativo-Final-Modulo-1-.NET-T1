using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeskFlow.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateRelationshipsBetweenEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Tickets_CategoryId",
                table: "Tickets",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Interactions_TicketId",
                table: "Interactions",
                column: "TicketId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interactions_Tickets_TicketId",
                table: "Interactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Categories_CategoryId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_CategoryId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Interactions_TicketId",
                table: "Interactions");
        }
    }
}
