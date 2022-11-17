using ToolsMarket.Business.Models.Enum;

namespace ToolsMarket.Business.Models
{
    public class Pedido : Entity
    {
        public Pedido(Guid usuarioId, DateTime dataVenda, int qtd, decimal valorTotal)
        {
            UsuarioId = usuarioId;
            DataVenda = dataVenda;
            Quantidade = qtd;
            DefinirFrete(valorTotal);
            StatusPedido = StatusPedido.Aberto;
        }

        public Pedido() { }

        private void DefinirFrete(decimal ValorTotal)
        {
            if(ValorTotal >= 200)
            {
                Frete = 0;
            }
        }

        public Guid UsuarioId { get; set; }
        public DateTime DataVenda { get; set; }
        public decimal? Frete { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorTotal { get; set; }
        public StatusPedido StatusPedido { get; set; }

        // Relations
        public Usuario Usuario { get; set; }
        public IEnumerable<Carrinho> ItensCarrinho { get; set; }
    }
}
