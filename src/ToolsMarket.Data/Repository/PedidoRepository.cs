using Microsoft.EntityFrameworkCore;
using ToolsMarket.Business.Interfaces;
using ToolsMarket.Business.Models;
using ToolsMarket.Data.Context;

namespace ToolsMarket.Data.Repository
{
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(CustomDbContext db) : base(db) {}

        public async Task<Pedido> ObterItemPedido()
        {
            return await Db.Pedidos.AsNoTracking()
                                   .Include(u => u.ItensPedido)
                                   .FirstOrDefaultAsync();
        }

        public Task<IEnumerable<Pedido>> ObterPedidos()
        {
            throw new NotImplementedException();
        }

        public async Task<Pedido> ObterPedidoPorId(Guid id)
        {
            return await Db.Pedidos.AsNoTracking()
                                   .Include(c => c.ItensPedido)
                                   .Where(c => c.Id == id)
                                   .FirstOrDefaultAsync();
        }
    }
}
