using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SunTech.Models
{
    [Table("Compra")]
    public class Compra
    {
        [Column("CompraId")]
        [Display(Name = "Código da Compra")]
        public int Id { get; set; }

        [ForeignKey("ClienteId")]
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        [Column("TotalCompra")]
        [Display(Name = "Valor Total")]
        public double ValorTotal { get; set; }

    }
}
