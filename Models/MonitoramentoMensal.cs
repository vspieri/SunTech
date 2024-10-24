using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SunTech.Models
{
    [Table("MonitoramentoMensal")]
    public class MonitoramentoMensal
    {
        [Column("MonitoramentoMensalId")]
        [Display(Name = "Código do Monitoramento Mensal")]
        public int Id { get; set; }

        [Column("Mes")]
        [Display(Name = "Mês")]
        public DateTime Mes { get; set; }

        [Column("MediaMensal")]
        [Display(Name = "Produção do Mês")]
        public int MediaMensal { get; set; }

        [ForeignKey("MonitoramentoId")]
        public int MonitoramentoId { get; set; }
        public Monitoramento? Monitoramento { get; set; }
    }
}

