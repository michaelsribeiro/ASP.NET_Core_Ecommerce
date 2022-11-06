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
        public Guid UsuarioId { get; set; }
        public DateTime DataVenda { get; set; }
        public decimal? Frete { get; set; }
        public StatusPedido StatusPedido { get; set; }

        // Relations
        public Usuario Usuario { get; set; }
        public Carrinho Carrinho { get; set; }
    }
}
