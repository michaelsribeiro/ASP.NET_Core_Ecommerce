using ToolsMarket.Business.Models.Enum;
using ToolsMarket.Business.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ToolsMarket.App.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DisplayName("Categoria")]
        public Guid CategoriaId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DisplayName("Fornecedor")]
        public Guid FornecedorId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres.", MinimumLength = 3)]
        [DisplayName("Nome")]
        public string Nome { get; set; }
        
        [DisplayName("Descrição")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres.", MinimumLength = 3)]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres.", MinimumLength = 3)]
        [DisplayName("Marca")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DisplayName("Quantidade")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DisplayName("Valor Unitário")]
        public decimal ValorUnitario { get; set; }
        public string Imagem { get; set; }

        //[DisplayName("Imagem")]
        //public IFormFile ImageProduto { get; set; }

        public StatusProduto Status { get; set; }

        // Relations

        [DisplayName("Categoria")]
        public CategoriaViewModel Categoria { get; set; }

        [DisplayName("Fornecedor")]
        public FornecedorViewModel Fornecedor { get; set; }

        public Carrinho Carrinho { get; set; }
    }
}
