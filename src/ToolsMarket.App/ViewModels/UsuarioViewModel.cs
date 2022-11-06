using ToolsMarket.Business.Models.Enum;
using ToolsMarket.Business.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ToolsMarket.App.ViewModels
{
    public class UsuarioViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DisplayName("Pedido")]
        public Guid PedidoId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DisplayName("Nome Completo")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DisplayName("CPF")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DisplayName("Gênero")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DisplayName("Telefone")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        public string? Imagem { get; set; }
        public TipoUsuario TipoUsuario { get; set; }

        // Relations
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DisplayName("Endereço")]
        public EnderecoViewModel Endereco { get; set; }
        public IEnumerable<PedidoViewModel>? Pedido { get; set; }
    }
}
