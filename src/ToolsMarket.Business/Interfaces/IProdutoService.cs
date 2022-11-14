using ToolsMarket.Business.Models;

namespace ToolsMarket.Business.Interfaces
{
    public interface IProdutoService
    {
        Task Adicionar(Produto produto);
        Task Atualizar(Produto produto);
        Task Remover(Produto produto);
    }
}
