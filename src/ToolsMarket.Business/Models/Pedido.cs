using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolsMarket.Business.Models.Enum;

namespace ToolsMarket.Business.Models
{
    public class Pedido : Entity
    {
        public DateTime DataVenda { get; set; }
        public string NomeCliente { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal? Frete { get; set; }
        public StatusPedido StatusPedido { get; set; }

        // Relations
        public Usuario Usuario { get; set; }
        public IEnumerable<Carrinho> Carrinhos { get; set; } = new List<Carrinho>();
    }
}
