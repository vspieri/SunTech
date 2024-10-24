using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SunTech.Models
{
    [Table("Compra_Has_Produto")]
    public class Compra_Has_Produto
    {
        [Column("Compra_Has_ProdutoId")]
        [Display(Name = "Código da Compra Has Produto")]
        public int Id { get; set; }

        [ForeignKey("CompraId")]
        public int CompraId { get; set; }
        public Compra? Compra { get; set; }

        [ForeignKey("ProdutoId")]
        public int ProdutoId { get; set; }
        public Produto? Produto { get; set; }

        [Column("QuantidadeProduto")]
        [Display(Name = "Quantidade")]
        public int QuantidadeProduto { get; set; }

        [Column("ValorUnitario")]
        [Display(Name = "Valor Unitário")]
        public double ValorUnitario { get; set; }

        [Column("ValorTotalProduto")]
        [Display(Name = "Total Produto")]
        public double ValorTotalProduto { get; set; }

    }
}
