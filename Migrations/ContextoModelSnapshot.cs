﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SunTech.Models;

#nullable disable

namespace SunTech.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SunTech.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ClienteId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CpfCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CpfCliente");

                    b.Property<string>("EmailCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("EmailCliente");

                    b.Property<string>("EnderecoCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("EnderecoCliente");

                    b.Property<string>("NomeCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NomeCliente");

                    b.Property<string>("SenhaCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("SenhaCliente");

                    b.Property<string>("TelefoneCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TelefoneCliente");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("SunTech.Models.Compra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CompraId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<double>("ValorTotal")
                        .HasColumnType("float")
                        .HasColumnName("TotalCompra");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Compra");
                });

            modelBuilder.Entity("SunTech.Models.Compra_Has_Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Compra_Has_ProdutoId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CompraId")
                        .HasColumnType("int");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<int>("QuantidadeProduto")
                        .HasColumnType("int")
                        .HasColumnName("QuantidadeProduto");

                    b.Property<double>("ValorTotalProduto")
                        .HasColumnType("float")
                        .HasColumnName("ValorTotalProduto");

                    b.Property<double>("ValorUnitario")
                        .HasColumnType("float")
                        .HasColumnName("ValorUnitario");

                    b.HasKey("Id");

                    b.HasIndex("CompraId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Compra_Has_Produto");
                });

            modelBuilder.Entity("SunTech.Models.Monitoramento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MonitoramentoId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataInstalacao")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataInstalacao");

                    b.Property<DateTime>("DataUltimaManutencao")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataUltimaManutencao");

                    b.Property<int>("PlacaId")
                        .HasColumnType("int");

                    b.Property<int>("QuantidadePlaca")
                        .HasColumnType("int")
                        .HasColumnName("QuantidadePlaca");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("PlacaId");

                    b.ToTable("Monitoramento");
                });

            modelBuilder.Entity("SunTech.Models.MonitoramentoDiario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MonitoramentoDiarioId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataDia")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataDia");

                    b.Property<int>("MediaDia")
                        .HasColumnType("int")
                        .HasColumnName("MediaDia");

                    b.Property<int>("MonitoramentoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MonitoramentoId");

                    b.ToTable("MonitoramentoDiario");
                });

            modelBuilder.Entity("SunTech.Models.MonitoramentoMensal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MonitoramentoMensalId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MediaMensal")
                        .HasColumnType("int")
                        .HasColumnName("MediaMensal");

                    b.Property<DateTime>("Mes")
                        .HasColumnType("datetime2")
                        .HasColumnName("Mes");

                    b.Property<int>("MonitoramentoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MonitoramentoId");

                    b.ToTable("MonitoramentoMensal");
                });

            modelBuilder.Entity("SunTech.Models.Placa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PlacaId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NomePlaca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NomePlaca");

                    b.Property<string>("TamanhoPlaca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TamanhoPlaca");

                    b.Property<int>("TipoPlacaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TipoPlacaId");

                    b.ToTable("Placa");
                });

            modelBuilder.Entity("SunTech.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ProdutoId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FotoProduto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("FotoProduto");

                    b.Property<string>("NomeProduto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NomeProduto");

                    b.Property<double>("PrecoProduto")
                        .HasColumnType("float")
                        .HasColumnName("PrecoProduto");

                    b.Property<int>("TipoProdutoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TipoProdutoId");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("SunTech.Models.TipoPlaca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TipoPlacaId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NomeTipoPlaca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NomeTipoPlaca");

                    b.HasKey("Id");

                    b.ToTable("TipoPlaca");
                });

            modelBuilder.Entity("SunTech.Models.TipoProduto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TipoProdutoId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FotoTipoProduto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("FotoTipoProduto");

                    b.Property<string>("NomeTipoProduto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NomeTipoProduto");

                    b.HasKey("Id");

                    b.ToTable("TipoProduto");
                });

            modelBuilder.Entity("SunTech.Models.Compra", b =>
                {
                    b.HasOne("SunTech.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("SunTech.Models.Compra_Has_Produto", b =>
                {
                    b.HasOne("SunTech.Models.Compra", "Compra")
                        .WithMany()
                        .HasForeignKey("CompraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SunTech.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Compra");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("SunTech.Models.Monitoramento", b =>
                {
                    b.HasOne("SunTech.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SunTech.Models.Placa", "Placa")
                        .WithMany()
                        .HasForeignKey("PlacaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Placa");
                });

            modelBuilder.Entity("SunTech.Models.MonitoramentoDiario", b =>
                {
                    b.HasOne("SunTech.Models.Monitoramento", "Monitoramento")
                        .WithMany()
                        .HasForeignKey("MonitoramentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Monitoramento");
                });

            modelBuilder.Entity("SunTech.Models.MonitoramentoMensal", b =>
                {
                    b.HasOne("SunTech.Models.Monitoramento", "Monitoramento")
                        .WithMany()
                        .HasForeignKey("MonitoramentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Monitoramento");
                });

            modelBuilder.Entity("SunTech.Models.Placa", b =>
                {
                    b.HasOne("SunTech.Models.TipoPlaca", "TipoPlaca")
                        .WithMany()
                        .HasForeignKey("TipoPlacaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoPlaca");
                });

            modelBuilder.Entity("SunTech.Models.Produto", b =>
                {
                    b.HasOne("SunTech.Models.TipoProduto", "TipoProduto")
                        .WithMany()
                        .HasForeignKey("TipoProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoProduto");
                });
#pragma warning restore 612, 618
        }
    }
}
