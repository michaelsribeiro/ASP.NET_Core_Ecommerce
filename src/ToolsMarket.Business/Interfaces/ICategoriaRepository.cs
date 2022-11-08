using ToolsMarket.Business.Models;

namespace ToolsMarket.Business.Interfaces
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        Task<IEnumerable<Categoria>> ObterCategoriaProdutos(Guid id);

        Task<IEnumerable<Categoria>> ObterCategorias();

        Task<Categoria> ObterCategoriaProduto(Guid id);
    }
}
