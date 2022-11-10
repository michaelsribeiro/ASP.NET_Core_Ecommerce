using ToolsMarket.Business.Models.Enum;

namespace ToolsMarket.Business.Models
{
    public class Pedido : Entity
    {
        public Pedido(Guid usuarioId, DateTime dataVenda, decimal? frete, StatusPedido statusPedido)
        {
            UsuarioId = usuarioId;
            DataVenda = new DateTime();
            Frete = frete;
            StatusPedido = StatusPedido.Aberto;
        }

        public Guid UsuarioId { get; set; }
        public DateTime DataVenda { get; set; }
        public decimal? Frete { get; set; }
        public StatusPedido StatusPedido { get; set; }

        // Relations
        public Usuario Usuario { get; set; }
        public Carrinho Carrinho { get; set; }
    }
}
