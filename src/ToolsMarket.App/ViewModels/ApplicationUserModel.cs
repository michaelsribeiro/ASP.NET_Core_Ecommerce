using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ToolsMarket.Business.Models;
using ToolsMarket.Business.Models.Enum;

namespace ToolsMarket.App.ViewModels
{
    public class ApplicationUserModel : IdentityUser
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DisplayName("Nome Completo")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DisplayName("CPF")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DisplayName("Gênero")]
        public Genero Genero { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(11, ErrorMessage = "A {0} precisa ter {1} caracteres.", MinimumLength = 2)]
        [DisplayName("Telefone")]
        public string Telefone { get; set; }

        public TipoUsuario TipoUsuario { get; set; }

        // Relations
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DisplayName("Endereço")]
        public EnderecoViewModel Endereco { get; set; }
        public Guid EnderecoId { get; set; }

        public IEnumerable<PedidoViewModel>? Pedido { get; set; }
        public Guid? PedidoId { get; set; }

    }
}
