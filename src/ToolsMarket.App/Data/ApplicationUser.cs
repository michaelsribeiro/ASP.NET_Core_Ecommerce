using ToolsMarket.Business.Models.Enum;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using ToolsMarket.App.ViewModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToolsMarket.App.Data
{
    public class ApplicationUser : IdentityUser
    {
        [Key]
        public string Id { get; set; }

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

        [NotMapped]
        [DisplayName("Imagem")]
        public IFormFile ImageUsuario { get; set; }
        public TipoUsuario TipoUsuario { get; set; }

        // Relations
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DisplayName("Endereço")]
        public EnderecoViewModel Endereco { get; set; }
        public IEnumerable<PedidoViewModel>? Pedido { get; set; }
    }
}
