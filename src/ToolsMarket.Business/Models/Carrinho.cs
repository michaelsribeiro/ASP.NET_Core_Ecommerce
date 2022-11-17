namespace ToolsMarket.Business.Models
{
    public class Carrinho : Entity
    {
        public Carrinho(Guid pedidoId, int quantidade, Guid produtoId)
        {
            PedidoId = pedidoId;
            Quantidade = quantidade;
            ProdutoId = produtoId;
        }

        public Guid PedidoId { get; set; }
        public Guid ProdutoId { get; set; }
        public int Quantidade { get; set; }

        // Relations
        public Pedido Pedido { get; set; }
        public Produto Produto { get; set; }
    }
}
