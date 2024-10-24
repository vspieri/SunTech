using Microsoft.EntityFrameworkCore;
using SunTech.Models;

namespace SunTech.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Compra> Compra { get; set; }
        public DbSet<Monitoramento> Monitoramento { get; set; }
        public DbSet<Placa> Placa { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<TipoPlaca> TipoPlaca { get; set; }
        public DbSet<Compra_Has_Produto> Compra_Has_Produto { get; set; }
        public DbSet<TipoProduto> TipoProduto { get; set; }
        public DbSet<MonitoramentoDiario> MonitoramentoDiario { get; set; }
        public DbSet<MonitoramentoMensal> MonitoramentoMensal { get; set; }
    }
}