using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ToolsMarket.App.ViewModels
{
    public class CategoriaViewModel
    {
        [Key]
        public Guid Id { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DisplayName("Nome")]
        public string NomeCategoria { get; set; }

        // Relations

        public IEnumerable<ProdutoViewModel>? Produtos { get; set; }
    }
}
