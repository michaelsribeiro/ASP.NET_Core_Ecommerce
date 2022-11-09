using Microsoft.EntityFrameworkCore;
using ToolsMarket.Business.Interfaces;
using ToolsMarket.Business.Models;
using ToolsMarket.Data.Context;

namespace ToolsMarket.Data.Repository
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(CustomDbContext db) : base(db) {}

        public async Task<IEnumerable<Categoria>> ObterCategoriaProdutos(Guid id)
        {
            return await Db.Categorias.AsNoTracking()
                                .Include(p => p.Produtos)
                                .ToListAsync();
        }

        public async Task<IEnumerable<Categoria>> ObterCategorias()
        {
            return await Db.Categorias.AsNoTracking()
                                      .ToListAsync();
        }

        public async Task<Categoria> ObterCategoriaProduto(Guid id)
        {
            return await Db.Categorias.AsNoTracking()
                                      .Include(p => p.Produtos)
                                      .FirstOrDefaultAsync(c => c.Id == id);                                      
        }
    }
}
