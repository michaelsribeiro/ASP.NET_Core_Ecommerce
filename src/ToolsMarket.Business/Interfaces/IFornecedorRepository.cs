using ToolsMarket.Business.Models;

namespace ToolsMarket.Business.Interfaces
{
    public interface IFornecedorRepository : IRepository<Fornecedor>
    {
        Task<Fornecedor> ObterFornecedorProdutos(Guid id);
    }
}
