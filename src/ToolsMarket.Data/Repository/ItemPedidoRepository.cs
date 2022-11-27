using Microsoft.EntityFrameworkCore;
using ToolsMarket.Business.Interfaces;
using ToolsMarket.Business.Models;
using ToolsMarket.Data.Context;

namespace ToolsMarket.Data.Repository
{
    public class ItemPedidoRepository : Repository<ItemPedido>, IItemPedidoRepository
    {

        public ItemPedidoRepository(CustomDbContext db) : base(db) { }

        public async Task<ItemPedido> ObterItemPedidoProduto(Guid id)
        {
            return await Db.ItensPedido.AsNoTracking()
                                       .Include(p => p.Produto)
                                       .Where(p => p.ProdutoId == id)
                                       .FirstOrDefaultAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
