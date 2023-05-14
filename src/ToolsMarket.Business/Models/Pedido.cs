using System.ComponentModel.DataAnnotations.Schema;
using ToolsMarket.App.Data;
using ToolsMarket.Business.Models.Enum;

namespace ToolsMarket.Business.Models
{
    public class Pedido : Entity
    {
        public DateTime DataVenda { get; set; }
        public decimal? Frete { get; set; }
        public decimal ValorTotal { get; set; }
        public StatusPedido StatusPedido { get; set; }
        public ApplicationUser Cliente { get; set; }
        public Guid ClienteId { get; set; }
        public virtual ICollection<ItemPedido> ItensPedido { get; set; } = new List<ItemPedido>();

        public Pedido() { }

        public Pedido(Guid clienteId, DateTime dataVenda, decimal valorTotal, StatusPedido status)
        {
            ClienteId = clienteId;
            DataVenda = dataVenda;
            DefinirFrete(valorTotal);
            StatusPedido = status;
            ItensPedido = new List<ItemPedido>();
        }

        public void DefinirFrete(decimal ValorTotal)
        {
            if(ValorTotal >= 200)
            {
                Frete = 0;
            }
        }

        public void DefinirCliente(ApplicationUser cliente)
        {
            Cliente = cliente;
        }

        public void DefinirEndereco(Endereco endereco)
        {
            Cliente.Endereco = endereco;
        }

        public void AtualizarStatus(StatusPedido status)
        {
            StatusPedido = status;
        }
    }
}
