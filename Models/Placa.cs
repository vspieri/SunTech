using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SunTech.Models
{
    [Table("Placa")]
    public class Placa
    {
        [Column("PlacaId")]
        [Display(Name = "Código da Placa")]
        public int Id { get; set; }

        [Column("NomePlaca")]
        [Display(Name = "Nome")]
        public string NomePlaca { get; set; } = string.Empty;

        [ForeignKey("TipoPlacaId")]
        public int TipoPlacaId { get; set; }
        public TipoPlaca? TipoPlaca { get; set; }

        [Column("TamanhoPlaca")]
        [Display(Name = "Tamanho")]
        public string TamanhoPlaca { get; set; } = string.Empty;
    }
}