using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsMarket.Business.Models
{
    public class Carrinho : Entity
    {
        public Carrinho(Guid pedidoId, int quantidade, decimal valorTotal)
        {
            PedidoId = pedidoId;
            Quantidade = quantidade;
            ValorTotal = valorTotal;
        }

        public Guid PedidoId { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorTotal { get; set; }

        // Relations
        public Pedido Pedido { get; set; }
        public IEnumerable<Produto> Produtos { get; set; }
    }
}
