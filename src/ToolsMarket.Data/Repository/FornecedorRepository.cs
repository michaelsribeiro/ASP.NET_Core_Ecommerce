using Microsoft.EntityFrameworkCore;
using ToolsMarket.Business.Interfaces;
using ToolsMarket.Business.Models;
using ToolsMarket.Data.Context;

namespace ToolsMarket.Data.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(CustomDbContext db) : base(db) {}

        public async Task<IEnumerable<Fornecedor>> ObterFornecedores()
        {
            return await Db.Fornecedores.AsNoTracking()
                                        .ToListAsync();
        }

        public async Task<Fornecedor> ObterFornecedorProduto(Guid id)
        {
            return await Db.Fornecedores.AsNoTracking()
                                        .Include(p => p.Produtos)
                                        .FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
