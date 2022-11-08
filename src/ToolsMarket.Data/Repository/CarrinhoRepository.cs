using Microsoft.EntityFrameworkCore;
using ToolsMarket.Business.Interfaces;
using ToolsMarket.Business.Models;
using ToolsMarket.Data.Context;

namespace ToolsMarket.Data.Repository
{
    public class CarrinhoRepository : Repository<Carrinho>, ICarrinhoRepository
    {
        public CarrinhoRepository(CustomDbContext db) : base(db) {}

        public async Task<IEnumerable<Carrinho>> ObterCarrinhoProdutos()
        {
            return await Db.Carrinhos.AsNoTracking()
                                     .Include(p => p.Produtos)
                                     .ToListAsync();
        }

        public async Task<Carrinho> ObterCarrinhoProduto(Guid id)
        {
            return await Db.Carrinhos.AsNoTracking()
                                     .Include(p => p.Produtos)
                                     .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
