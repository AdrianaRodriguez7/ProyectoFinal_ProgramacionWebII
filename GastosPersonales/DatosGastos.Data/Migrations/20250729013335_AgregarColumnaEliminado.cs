using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatosGastos.Data.Migrations
{
    /// <inheritdoc />
    public partial class AgregarColumnaEliminado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Eliminado",
                table: "Transacciones",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Eliminado",
                table: "Categorias",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Eliminado",
                table: "Transacciones");

            migrationBuilder.DropColumn(
                name: "Eliminado",
                table: "Categorias");
        }
    }
}
