using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToolsMarket.App.ViewModels
{
    public class ItemPedidoViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid PedidoId { get; set; }
        public Guid ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }

        // Relations

        public PedidoViewModel? Pedido { get; set; }

        public ProdutoViewModel Produto { get; set; }
    }
}
