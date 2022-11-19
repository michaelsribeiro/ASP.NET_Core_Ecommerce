using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ToolsMarket.App.Data;

namespace ToolsMarket.App.ViewModels
{
    public class EnderecoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(8, ErrorMessage = "O campo {0} precisa ter {1} caracteres.")]
        [DisplayName("CEP")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres.", MinimumLength = 3)]
        [DisplayName("Logradouro")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres.", MinimumLength = 3)]
        [DisplayName("Bairro")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres.", MinimumLength = 3)]
        [DisplayName("Cidade")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DisplayName("UF")]
        public string Uf { get; set; }

        // Relations

        [HiddenInput]
        public Guid? UsuarioId { get; set; }
        public IEnumerable<ApplicationUser> Usuarios { get; set; }
    }
}
