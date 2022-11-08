using ToolsMarket.Business.Models;

namespace ToolsMarket.Business.Interfaces
{
    public interface IFornecedorRepository : IRepository<Fornecedor>
    {
        Task<IEnumerable<Fornecedor>> ObterFornecedores();
        Task<Fornecedor> ObterFornecedorProduto(Guid id);
    }
}
