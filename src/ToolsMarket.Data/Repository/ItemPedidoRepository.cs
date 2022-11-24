using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolsMarket.Business.Interfaces;
using ToolsMarket.Business.Models;
using ToolsMarket.Data.Context;

namespace ToolsMarket.Data.Repository
{
    public class ItemPedidoRepository : Repository<ItemPedido>, IItemPedidoRepository
    {

        public ItemPedidoRepository(CustomDbContext db) : base(db) { }

        public async Task<IEnumerable<ItemPedido>> ObterItemPedidoProduto()
        {
            return await Db.ItensPedido.AsNoTracking()
                                       .Include(p => p.Produto)
                                       .ToListAsync();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
