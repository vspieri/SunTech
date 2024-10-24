using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SunTech.Models
{
    [Table("MonitoramentoDiario")]
    public class MonitoramentoDiario
    {
        [Column("MonitoramentoDiarioId")]
        [Display(Name = "Código do Monitoramento Diário")]
        public int Id { get; set; }

        [Column("DataDia")]
        [Display(Name = "Data de Hoje")]
        public DateTime DataDia { get; set; }

        [Column("MediaDia")]
        [Display(Name = "Produção de Hoje")]
        public int MediaDia { get; set; }

        [ForeignKey("MonitoramentoId")]
        public int MonitoramentoId { get; set; }
        public Monitoramento? Monitoramento { get; set; }
    }
}
