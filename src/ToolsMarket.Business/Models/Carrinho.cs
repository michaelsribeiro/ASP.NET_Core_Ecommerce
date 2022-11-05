using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsMarket.Business.Models
{
    public class Carrinho : Entity
    {
        public int Quantidade { get; set; }

        // Relations
        public Pedido? Pedido { get; set; }
        public IEnumerable<Produto> ItensPedido { get; set; } = new List<Produto>();
    }
}
