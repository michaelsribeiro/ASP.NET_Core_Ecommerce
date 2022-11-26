using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolsMarket.Business.Models;

namespace ToolsMarket.Business.Interfaces
{
    public interface IItemPedidoRepository : IRepository<ItemPedido>
    {
        Task<ItemPedido> ObterItemPedidoProduto(Guid id);
    }
}
