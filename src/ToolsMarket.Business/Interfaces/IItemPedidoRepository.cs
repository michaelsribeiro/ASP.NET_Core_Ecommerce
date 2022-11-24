using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolsMarket.Business.Models;

namespace ToolsMarket.Business.Interfaces
{
    public interface IItemPedidoRepository : IDisposable
    {
        Task<IEnumerable<ItemPedido>> ObterItemPedidoProduto();
    }
}
