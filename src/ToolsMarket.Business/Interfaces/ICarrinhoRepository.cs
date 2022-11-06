using ToolsMarket.Business.Models;

namespace ToolsMarket.Business.Interfaces
{
    public interface ICarrinhoRepository : IRepository<Carrinho>
    {
        Task<IEnumerable<Carrinho>> ObterCarrinhoProdutos();
    }
}
 