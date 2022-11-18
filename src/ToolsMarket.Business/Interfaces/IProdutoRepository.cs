using ToolsMarket.Business.Models;

namespace ToolsMarket.Business.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId);
        Task<IEnumerable<Produto>> ObterProdutosFornecedores();
        Task<Produto> ObterProdutoPorId(Guid id);
        Task<Produto> ObterProdutoFornecedor(Guid id);
        Task<IEnumerable<Produto>> ObterProdutos();
        Task<IEnumerable<Produto>> ObterProdutosManuais();
        Task<IEnumerable<Produto>> ObterProdutosEletricos();
        Task<IEnumerable<Produto>> ObterProdutosPneumaticos();
        Task<IEnumerable<Produto>> ObterProdutosAutomotivos();
        Task<IEnumerable<Produto>> ObterProdutosAcessorios();
        Task<IEnumerable<Produto>> ObterProdutosUtilidades();
    }
}
