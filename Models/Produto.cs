using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SunTech.Models
{
    [Table("Produto")]
    public class Produto
    {
        [Column("ProdutoId")]
        [Display(Name = "Código do Produto")]
        public int Id { get; set; }

        [Column("NomeProduto")]
        [Display(Name = "Produto")]
        public string NomeProduto { get; set; } = string.Empty;

        [Column("FotoProduto")]
        [Display(Name = "Foto")]
        public string FotoProduto { get; set; } = string.Empty;

        [ForeignKey("TipoProdutoId")]
        public int TipoProdutoId { get; set; }
        public TipoProduto? TipoProduto { get; set; }

        [Column("PrecoProduto")]
        [Display(Name = "Preço")]
        public double PrecoProduto { get; set; }
    }
}
