using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SunTech.Migrations
{
    /// <inheritdoc />
    public partial class FotoTipoProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FotoTipoProduto",
                table: "TipoProduto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FotoTipoProduto",
                table: "TipoProduto");
        }
    }
}
