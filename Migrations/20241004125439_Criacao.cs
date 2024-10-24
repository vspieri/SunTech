using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SunTech.Migrations
{
    /// <inheritdoc />
    public partial class Criacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MonitoramentoId",
                table: "MonitoramentoMensal",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MonitoramentoId",
                table: "MonitoramentoDiario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MonitoramentoMensal_MonitoramentoId",
                table: "MonitoramentoMensal",
                column: "MonitoramentoId");

            migrationBuilder.CreateIndex(
                name: "IX_MonitoramentoDiario_MonitoramentoId",
                table: "MonitoramentoDiario",
                column: "MonitoramentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_MonitoramentoDiario_Monitoramento_MonitoramentoId",
                table: "MonitoramentoDiario",
                column: "MonitoramentoId",
                principalTable: "Monitoramento",
                principalColumn: "MonitoramentoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MonitoramentoMensal_Monitoramento_MonitoramentoId",
                table: "MonitoramentoMensal",
                column: "MonitoramentoId",
                principalTable: "Monitoramento",
                principalColumn: "MonitoramentoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MonitoramentoDiario_Monitoramento_MonitoramentoId",
                table: "MonitoramentoDiario");

            migrationBuilder.DropForeignKey(
                name: "FK_MonitoramentoMensal_Monitoramento_MonitoramentoId",
                table: "MonitoramentoMensal");

            migrationBuilder.DropIndex(
                name: "IX_MonitoramentoMensal_MonitoramentoId",
                table: "MonitoramentoMensal");

            migrationBuilder.DropIndex(
                name: "IX_MonitoramentoDiario_MonitoramentoId",
                table: "MonitoramentoDiario");

            migrationBuilder.DropColumn(
                name: "MonitoramentoId",
                table: "MonitoramentoMensal");

            migrationBuilder.DropColumn(
                name: "MonitoramentoId",
                table: "MonitoramentoDiario");
        }
    }
}
