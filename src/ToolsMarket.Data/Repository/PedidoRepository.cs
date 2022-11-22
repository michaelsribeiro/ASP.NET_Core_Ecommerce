using Microsoft.EntityFrameworkCore;
using ToolsMarket.Business.Interfaces;
using ToolsMarket.Business.Models;
using ToolsMarket.Data.Context;

namespace ToolsMarket.Data.Repository
{
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(CustomDbContext db) : base(db) {}

        public async Task<IEnumerable<Pedido>> ObterCarrinhosUsuario()
        {
            return await Db.Pedidos.AsNoTracking()
                                   .Include(u => u.ItensPedido)
                                   .ToListAsync();
            }

        public async Task<IEnumerable<Pedido>> ObterPedidos()
        {
            return await Db.Pedidos.AsNoTracking()
                                   .ToListAsync();
        }

        public async Task<Pedido> ObterPedidoUsuario(Guid id)
        {
            return await Db.Pedidos.AsNoTracking()
                                   .Include(u => u.ItensPedido)
                                        .ThenInclude(c=>c.Produto)                                            
                                   .FirstOrDefaultAsync(p => p.Id == id);
        }

    }
}
