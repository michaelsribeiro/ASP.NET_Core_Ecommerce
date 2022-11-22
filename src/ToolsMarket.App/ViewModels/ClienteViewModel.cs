using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using ToolsMarket.Business.Models.Enum;

namespace ToolsMarket.App.ViewModels
 {
    public class ClienteViewModel
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

        public Guid ApplicationUserId { get; private set; }
    }

    public class RegisterViewModel
    {

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [EmailAddress(ErrorMessage = "O campo {0} etá em formato inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "As senhas não conferem.")]
        public string ConfirmPassword { get; set; }

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

    public class LoginViewModel
    {

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [EmailAddress(ErrorMessage = "O campo {0} etá em formato inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
