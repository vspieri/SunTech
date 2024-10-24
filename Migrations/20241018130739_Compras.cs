using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SunTech.Migrations
{
    /// <inheritdoc />
    public partial class Compras : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantidadeProduto",
                table: "Compra");

            migrationBuilder.AddColumn<int>(
                name: "QuantidadeProduto",
                table: "Compra_Has_Produto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "ValorTotalProduto",
                table: "Compra_Has_Produto",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ValorUnitario",
                table: "Compra_Has_Produto",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantidadeProduto",
                table: "Compra_Has_Produto");

            migrationBuilder.DropColumn(
                name: "ValorTotalProduto",
                table: "Compra_Has_Produto");

            migrationBuilder.DropColumn(
                name: "ValorUnitario",
                table: "Compra_Has_Produto");

            migrationBuilder.AddColumn<int>(
                name: "QuantidadeProduto",
                table: "Compra",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
