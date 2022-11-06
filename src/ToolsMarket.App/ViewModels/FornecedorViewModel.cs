using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ToolsMarket.Business.Models;

namespace ToolsMarket.App.ViewModels
{
    public class FornecedorViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres.", MinimumLength = 3)]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(11, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres.", MinimumLength = 10)]
        [DisplayName("Telefone")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DisplayName("CNPJ")]
        public string Cnpj { get; set; }

        // Relations

        public IEnumerable<ProdutoViewModel>? Produtos { get; set; }
    }
}
