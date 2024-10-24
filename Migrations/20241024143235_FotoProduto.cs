using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SunTech.Migrations
{
    /// <inheritdoc />
    public partial class FotoProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FotoProduto",
                table: "Produto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FotoProduto",
                table: "Produto");
        }
    }
}
