using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbCorFloProyectoEasyTicketsP2.Migrations
{
    /// <inheritdoc />
    public partial class pers1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.RenameColumn(
                name: "Vendido",
                table: "Ticket",
                newName: "ACFVendido");

            migrationBuilder.RenameColumn(
                name: "Telefono",
                table: "Ticket",
                newName: "ACFTelefono");

            migrationBuilder.RenameColumn(
                name: "Precio",
                table: "Ticket",
                newName: "ACFPrecio");

            migrationBuilder.RenameColumn(
                name: "Lugar",
                table: "Ticket",
                newName: "ACFLugar");

            migrationBuilder.RenameColumn(
                name: "Fecha",
                table: "Ticket",
                newName: "ACFFecha");

            migrationBuilder.RenameColumn(
                name: "Evento",
                table: "Ticket",
                newName: "ACFEvento");

            migrationBuilder.RenameColumn(
                name: "Contrasenia",
                table: "Ticket",
                newName: "ACFContrasenia");

            migrationBuilder.RenameColumn(
                name: "ButacaSeccion",
                table: "Ticket",
                newName: "ACFButacaSeccion");

            migrationBuilder.RenameColumn(
                name: "TicketID",
                table: "Ticket",
                newName: "ACFTicketID");

            migrationBuilder.CreateTable(
                name: "ACFReviews",
                columns: table => new
                {
                    ACFReviewID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ACFComentario = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ACFCalificacion = table.Column<int>(type: "int", nullable: false),
                    ACFFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ACFTicketID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACFReviews", x => x.ACFReviewID);
                    table.ForeignKey(
                        name: "FK_ACFReviews_Ticket_ACFTicketID",
                        column: x => x.ACFTicketID,
                        principalTable: "Ticket",
                        principalColumn: "ACFTicketID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ACFReviews_ACFTicketID",
                table: "ACFReviews",
                column: "ACFTicketID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ACFReviews");

            migrationBuilder.RenameColumn(
                name: "ACFVendido",
                table: "Ticket",
                newName: "Vendido");

            migrationBuilder.RenameColumn(
                name: "ACFTelefono",
                table: "Ticket",
                newName: "Telefono");

            migrationBuilder.RenameColumn(
                name: "ACFPrecio",
                table: "Ticket",
                newName: "Precio");

            migrationBuilder.RenameColumn(
                name: "ACFLugar",
                table: "Ticket",
                newName: "Lugar");

            migrationBuilder.RenameColumn(
                name: "ACFFecha",
                table: "Ticket",
                newName: "Fecha");

            migrationBuilder.RenameColumn(
                name: "ACFEvento",
                table: "Ticket",
                newName: "Evento");

            migrationBuilder.RenameColumn(
                name: "ACFContrasenia",
                table: "Ticket",
                newName: "Contrasenia");

            migrationBuilder.RenameColumn(
                name: "ACFButacaSeccion",
                table: "Ticket",
                newName: "ButacaSeccion");

            migrationBuilder.RenameColumn(
                name: "ACFTicketID",
                table: "Ticket",
                newName: "TicketID");

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketID = table.Column<int>(type: "int", nullable: false),
                    Calificacion = table.Column<int>(type: "int", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewID);
                    table.ForeignKey(
                        name: "FK_Reviews_Ticket_TicketID",
                        column: x => x.TicketID,
                        principalTable: "Ticket",
                        principalColumn: "TicketID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_TicketID",
                table: "Reviews",
                column: "TicketID");
        }
    }
}
