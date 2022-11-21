using System.ComponentModel.DataAnnotations.Schema;
using ToolsMarket.App.Data;
using ToolsMarket.Business.Models.Enum;

namespace ToolsMarket.Business.Models
{
    public class Pedido : Entity
    {
        public Pedido(Guid usuarioId, DateTime dataVenda, decimal valorTotal, StatusPedido status)
        {
            UsuarioId = usuarioId;
            DataVenda = dataVenda;
            DefinirFrete(valorTotal);
            StatusPedido = status;
        }

        public Pedido() { }

        public void DefinirFrete(decimal ValorTotal)
        {
            if(ValorTotal >= 200)
            {
                Frete = 0;
            }
        }

        public Guid UsuarioId { get; set; }
        public DateTime DataVenda { get; set; }
        public decimal? Frete { get; set; }
        public decimal ValorTotal { get; set; }
        public StatusPedido StatusPedido { get; set; }

        [NotMapped]
        public Produto produto { get; set; }

        // Relations
        public ApplicationUser Usuario { get; set; }
        public virtual ICollection<ItemPedido> ItensPedido { get; set; } = new List<ItemPedido>();
    }
}
