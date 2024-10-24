using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SunTech.Models
{
    [Table("TipoPlaca")]
    public class TipoPlaca
    {
        [Column("TipoPlacaId")]
        [Display(Name = "Código do Tipo da Placa")]
        public int Id { get; set; }

        [Column("NomeTipoPlaca")]
        [Display(Name = "Tipo da Placa")]
        public string NomeTipoPlaca { get; set; } = string.Empty;
    }
}
