namespace ToolsMarket.Business.Models
{
    public class ItemPedido : Entity
    {
        public ItemPedido()
        {
        }

        public ItemPedido(Guid pedidoId, int quantidade, Guid produtoId, decimal valorUnitario)
        {
            PedidoId = pedidoId;
            ProdutoId = produtoId;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
        }

        public Guid PedidoId { get; set; }
        public Guid ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }

        // Relations
        public Pedido Pedido { get; set; }
        public Produto Produto { get; set; }

    }
}
