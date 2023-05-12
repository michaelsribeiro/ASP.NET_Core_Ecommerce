using ToolsMarket.Business.Models;
using ToolsMarket.Business.Models.Enum;

namespace ToolsMarket.Business.Interfaces
{
    public interface IProdutoService : IDisposable
    {
        Task Adicionar(Produto produto);
        Task Atualizar(Guid id, Guid fornecedor, Guid categoria, string marca, int qtd, string descricao, string? imagem, string nome, decimal? precoVenda, int qtdParcelas,
                       StatusProduto? status, decimal valorUnitario);
        Task Remover(Guid id);
    }
}
