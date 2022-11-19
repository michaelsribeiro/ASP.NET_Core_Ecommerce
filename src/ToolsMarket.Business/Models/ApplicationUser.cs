using ToolsMarket.Business.Models.Enum;
using ToolsMarket.Business.Models;

namespace ToolsMarket.App.Data
{
    public class ApplicationUser : Entity
    {
        public Guid PedidoId { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Genero { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string? Imagem { get; set; }
        public TipoUsuario TipoUsuario { get; set; }

        // Relations
        public Endereco Endereco { get; set; }
        public IEnumerable<Pedido>? Pedido { get; set; }
    }
}
