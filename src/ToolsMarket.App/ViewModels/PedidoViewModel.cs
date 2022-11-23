using ToolsMarket.Business.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ToolsMarket.App.ViewModels
{
    public class PedidoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Data da Compra")]
        public DateTime DataVenda { get; set; }

        [DisplayName("Frete")]
        public decimal? Frete { get; set; }

        [DisplayName("Status do Pedido")]
        public StatusPedido StatusPedido { get; set; }
        public decimal ValorTotal { get; set; }

        // Relations
        public ApplicationUserModel Cliente { get; set; }
        [DisplayName("Cliente")]
        public string ClienteId { get; set; }

        public virtual ICollection<ItemPedidoViewModel>? ItensPedido { get; set; }
    }
}
