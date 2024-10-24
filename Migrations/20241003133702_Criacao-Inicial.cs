using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SunTech.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CpfCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenhaCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefoneCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnderecoCliente = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "MonitoramentoDiario",
                columns: table => new
                {
                    MonitoramentoDiarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataDia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MediaDia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonitoramentoDiario", x => x.MonitoramentoDiarioId);
                });

            migrationBuilder.CreateTable(
                name: "MonitoramentoMensal",
                columns: table => new
                {
                    MonitoramentoMensalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mes = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MediaMensal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonitoramentoMensal", x => x.MonitoramentoMensalId);
                });

            migrationBuilder.CreateTable(
                name: "TipoPlaca",
                columns: table => new
                {
                    TipoPlacaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTipoPlaca = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPlaca", x => x.TipoPlacaId);
                });

            migrationBuilder.CreateTable(
                name: "TipoProduto",
                columns: table => new
                {
                    TipoProdutoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTipoProduto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoProduto", x => x.TipoProdutoId);
                });

            migrationBuilder.CreateTable(
                name: "Compra",
                columns: table => new
                {
                    CompraId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    QuantidadeProduto = table.Column<int>(type: "int", nullable: false),
                    TotalCompra = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compra", x => x.CompraId);
                    table.ForeignKey(
                        name: "FK_Compra_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Placa",
                columns: table => new
                {
                    PlacaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomePlaca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoPlacaId = table.Column<int>(type: "int", nullable: false),
                    TamanhoPlaca = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Placa", x => x.PlacaId);
                    table.ForeignKey(
                        name: "FK_Placa_TipoPlaca_TipoPlacaId",
                        column: x => x.TipoPlacaId,
                        principalTable: "TipoPlaca",
                        principalColumn: "TipoPlacaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeProduto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoProdutoId = table.Column<int>(type: "int", nullable: false),
                    PrecoProduto = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.ProdutoId);
                    table.ForeignKey(
                        name: "FK_Produto_TipoProduto_TipoProdutoId",
                        column: x => x.TipoProdutoId,
                        principalTable: "TipoProduto",
                        principalColumn: "TipoProdutoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Monitoramento",
                columns: table => new
                {
                    MonitoramentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlacaId = table.Column<int>(type: "int", nullable: false),
                    QuantidadePlaca = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    DataInstalacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataUltimaManutencao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monitoramento", x => x.MonitoramentoId);
                    table.ForeignKey(
                        name: "FK_Monitoramento_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Monitoramento_Placa_PlacaId",
                        column: x => x.PlacaId,
                        principalTable: "Placa",
                        principalColumn: "PlacaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Compra_Has_Produto",
                columns: table => new
                {
                    Compra_Has_ProdutoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompraId = table.Column<int>(type: "int", nullable: false),
                    ProdutoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compra_Has_Produto", x => x.Compra_Has_ProdutoId);
                    table.ForeignKey(
                        name: "FK_Compra_Has_Produto_Compra_CompraId",
                        column: x => x.CompraId,
                        principalTable: "Compra",
                        principalColumn: "CompraId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Compra_Has_Produto_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compra_ClienteId",
                table: "Compra",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_Has_Produto_CompraId",
                table: "Compra_Has_Produto",
                column: "CompraId");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_Has_Produto_ProdutoId",
                table: "Compra_Has_Produto",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Monitoramento_ClienteId",
                table: "Monitoramento",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Monitoramento_PlacaId",
                table: "Monitoramento",
                column: "PlacaId");

            migrationBuilder.CreateIndex(
                name: "IX_Placa_TipoPlacaId",
                table: "Placa",
                column: "TipoPlacaId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_TipoProdutoId",
                table: "Produto",
                column: "TipoProdutoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Compra_Has_Produto");

            migrationBuilder.DropTable(
                name: "Monitoramento");

            migrationBuilder.DropTable(
                name: "MonitoramentoDiario");

            migrationBuilder.DropTable(
                name: "MonitoramentoMensal");

            migrationBuilder.DropTable(
                name: "Compra");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Placa");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "TipoProduto");

            migrationBuilder.DropTable(
                name: "TipoPlaca");
        }
    }
}
