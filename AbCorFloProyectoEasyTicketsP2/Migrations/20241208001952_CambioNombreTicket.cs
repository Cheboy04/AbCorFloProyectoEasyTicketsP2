using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbCorFloProyectoEasyTicketsP2.Migrations
{
    /// <inheritdoc />
    public partial class CambioNombreTicket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropForeignKey(
                name: "FK_ACFReviews_Ticket_ACFTicketID",
                table: "ACFReviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket");

            migrationBuilder.RenameTable(
                name: "Ticket",
                newName: "ACFTicket");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ACFTicket",
                table: "ACFTicket",
                column: "ACFTicketID");

            migrationBuilder.AddForeignKey(
                name: "FK_ACFReviews_ACFTicket_ACFTicketID",
                table: "ACFReviews",
                column: "ACFTicketID",
                principalTable: "ACFTicket",
                principalColumn: "ACFTicketID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ACFReviews_ACFTicket_ACFTicketID",
                table: "ACFReviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ACFTicket",
                table: "ACFTicket");

            migrationBuilder.RenameTable(
                name: "ACFTicket",
                newName: "Ticket");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket",
                column: "ACFTicketID");

            migrationBuilder.AddForeignKey(
                name: "FK_ACFReviews_Ticket_ACFTicketID",
                table: "ACFReviews",
                column: "ACFTicketID",
                principalTable: "Ticket",
                principalColumn: "ACFTicketID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
