using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbCorFloProyectoEasyTicketsP2.Migrations
{
    /// <inheritdoc />
    public partial class PruebaTicket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("EXEC sp_rename 'Ticket', 'ACFTicket'");
            migrationBuilder.AddColumn<string>(
            name: "ACFEvento",
            table: "ACFTicket",
            nullable: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ACFFecha",
                table: "ACFTicket",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ACFLugar",
                table: "ACFTicket",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ACFButacaSeccion",
                table: "ACFTicket",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ACFPrecio",
                table: "ACFTicket",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ACFTelefono",
                table: "ACFTicket",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ACFVendido",
                table: "ACFTicket",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "ACFContrasenia",
                table: "ACFTicket",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                        name: "ACFEvento",
                        table: "ACFTicket");

            migrationBuilder.DropColumn(
                name: "ACFFecha",
                table: "ACFTicket");

            migrationBuilder.DropColumn(
                name: "ACFLugar",
                table: "ACFTicket");

            migrationBuilder.DropColumn(
                name: "ACFButacaSeccion",
                table: "ACFTicket");

            migrationBuilder.DropColumn(
                name: "ACFPrecio",
                table: "ACFTicket");

            migrationBuilder.DropColumn(
                name: "ACFTelefono",
                table: "ACFTicket");

            migrationBuilder.DropColumn(
                name: "ACFVendido",
                table: "ACFTicket");

            migrationBuilder.DropColumn(
                name: "ACFContrasenia",
                table: "ACFTicket");
        }
    }
}
