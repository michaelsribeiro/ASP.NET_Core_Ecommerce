namespace ToolsMarket.Business.Models
{
    public class ItemPedido : Entity
    {
        public Guid PedidoId { get; set; }
        public Guid ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal SubTotal { get; set; }

        // Relations
        public Pedido Pedido { get; set; }
        public Produto Produto { get; set; }

    }
}
