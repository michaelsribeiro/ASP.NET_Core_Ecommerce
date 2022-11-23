using System.ComponentModel.DataAnnotations;
using ToolsMarket.Business.Models;
using ToolsMarket.Business.Models.Enum;

namespace ToolsMarket.App.Data
{
    public class ApplicationUser : Entity
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Genero { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string? Imagem { get; set; }
        public TipoUsuario TipoUsuario { get; set; }

        public Endereco Endereco { get; set; }
        public Guid EnderecoId { get; set; }

        public IEnumerable<Pedido>? Pedido { get; set; }
        public Guid? PedidoId { get; set; }
    }
}
