using Microsoft.EntityFrameworkCore;
using ToolsMarket.Business.Interfaces;
using ToolsMarket.Business.Models;
using ToolsMarket.Data.Context;

namespace ToolsMarket.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(CustomDbContext db) : base(db) {}

        public async Task<Produto> ObterProdutoFornecedor(Guid id)
        {
            return await Db.Produtos.AsNoTracking()
                                    .Include(f => f.Fornecedor)
                                    .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Produto>> ObterProdutos()
        {
            return await Db.Produtos.AsNoTracking()
                                    .ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterProdutosFornecedores()
        {
            return await Db.Produtos.AsNoTracking()
                                    .Include(f => f.Fornecedor)
                                    .OrderBy(p => p.Nome)
                                    .ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId)
        {
            return await Buscar(p => p.FornecedorId == fornecedorId);
        }

        public async Task<IEnumerable<Produto>> ObterProdutosManuais()
        {
            return await Db.Produtos.AsNoTracking()
                                    .Include(c => c.Categorias)
                                    .Where(c => c.Categoria.NomeCategoria.Equals("Ferramentas Manuais"))
                                    .OrderBy(p => p.Id)
                                    .Take(9)
                                    .ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterProdutosEletricos()
        {
            return await Db.Produtos.AsNoTracking()
                                    .Include(c => c.Categorias)
                                    .Where(c => c.Categoria.NomeCategoria.Equals("Ferramentas Elétricas"))
                                    .OrderBy(p => p.Id)
                                    .Take(9)
                                    .ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPneumaticos()
        {
            return await Db.Produtos.AsNoTracking()
                                    .Include(c => c.Categorias)
                                    .Where(c => c.Categoria.NomeCategoria.Equals("Ferramentas Pneumárticas"))
                                    .OrderBy(p => p.Id)
                                    .Take(9)
                                    .ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterProdutosAutomotivos()
        {
            return await Db.Produtos.AsNoTracking()
                                    .Include(c => c.Categorias)
                                    .Where(c => c.Categoria.NomeCategoria.Equals("Automotivas"))
                                    .OrderBy(p => p.Id)
                                    .Take(9)
                                    .ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterProdutosAcessorios()
        {
            return await Db.Produtos.AsNoTracking()
                                    .Include(c => c.Categorias)
                                    .Where(c => c.Categoria.NomeCategoria.Equals("Acessórios"))
                                    .OrderBy(p => p.Id)
                                    .Take(9)
                                    .ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterProdutosUtilidades()
        {
            return await Db.Produtos.AsNoTracking()
                                    .Include(c => c.Categorias)
                                    .Where(c => c.Categoria.NomeCategoria.Equals("Casa e Utilidades"))
                                    .OrderBy(p => p.Id)
                                    .Take(9)
                                    .ToListAsync();
        }
    }
}
