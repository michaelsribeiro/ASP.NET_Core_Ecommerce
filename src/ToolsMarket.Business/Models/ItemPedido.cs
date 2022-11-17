namespace ToolsMarket.Business.Models
{
    public class ItemPedido : Entity
    {
        public ItemPedido(Guid pedidoId, int quantidade, Guid produtoId, double valorUnitario)
        {
            PedidoId = pedidoId;
            ProdutoId = produtoId;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
        }

        public Guid PedidoId { get; set; }
        public Guid ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public double ValorUnitario { get; set; }

        // Relations
        public Pedido Pedido { get; set; }
        public Produto Produto { get; set; }
    }
}
