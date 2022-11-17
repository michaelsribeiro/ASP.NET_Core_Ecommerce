using ToolsMarket.Business.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ToolsMarket.App.ViewModels
{
    public class PedidoViewModel
    {
        [Key]
        public Guid Id { get; set; }
        
        [DisplayName("Cliente")] 
        public Guid UsuarioId { get; set; }

        [DisplayName("Data da Compra")]
        public DateTime DataVenda { get; set; }

        [DisplayName("Frete")]
        public decimal? Frete { get; set; }

        [DisplayName("Status do Pedido")]
        public StatusPedido StatusPedido { get; set; }
        public decimal ValorTotal { get; set; }
        public ProdutoViewModel produto { get; set; }

        // Relations
        public UsuarioViewModel Usuario { get; set; }
        public IEnumerable<ItemPedidoViewModel> ItensPedido { get; set; }
    }
}
