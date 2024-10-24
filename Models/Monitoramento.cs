using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SunTech.Models
{
    [Table("Monitoramento")]
    public class Monitoramento
    {
        [Column("MonitoramentoId")]
        [Display(Name = "Código do Monitoramento")]
        public int Id { get; set; }

        [ForeignKey("PlacaId")]
        public int PlacaId { get; set; }
        public Placa? Placa { get; set; }

        [Column("QuantidadePlaca")]
        [Display(Name = "Quantidade")]
        public int QuantidadePlaca { get; set; }

        [ForeignKey("ClienteId")]
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        [Column("DataInstalacao")]
        [Display(Name = "Instalação")]
        public DateTime DataInstalacao { get; set; }

        [Column("DataUltimaManutencao")]
        [Display(Name = "Última Manutenção")]
        public DateTime DataUltimaManutencao { get; set; }
    }
}