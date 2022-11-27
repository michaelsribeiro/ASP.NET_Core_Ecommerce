using Microsoft.EntityFrameworkCore;
using ToolsMarket.Business.Interfaces;
using ToolsMarket.Business.Models;
using ToolsMarket.Data.Context;

namespace ToolsMarket.Data.Repository
{
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(CustomDbContext db) : base(db) {}

        public async Task<Pedido> ObterItemPedido(Guid id)
        {
            return await Db.Pedidos.AsNoTracking()
                                   .Include(u => u.ItensPedido)
                                        .ThenInclude(u => u.Produto)
                                   .Where(c => c.ClienteId == id)
                                   .FirstOrDefaultAsync();
        }

        public async Task<Pedido> ObterItemPedidoProduto(Guid id)
        {
            return await Db.Pedidos.AsNoTracking()
                                   .Include(c => c.ItensPedido)
                                        .ThenInclude(u => u.Produto)
                                   .Where(u => u.Id == id)
                                   .FirstOrDefaultAsync();
        }

        public async Task<Pedido> ObterPedidoPorId(Guid id)
        {
            return await Db.Pedidos.AsNoTracking()
                                   .Include(c => c.ItensPedido)
                                        .ThenInclude(u => u.Produto)
                                   .Where(c => c.Id == id)
                                   .FirstOrDefaultAsync();
        }
    }
}
