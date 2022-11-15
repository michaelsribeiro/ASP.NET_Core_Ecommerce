using ToolsMarket.Business.Models;

namespace ToolsMarket.Business.Interfaces
{
    public interface IEnderecoService : IDisposable
    {
        Task Adicionar(Endereco endereco);
        Task Atualizar(Endereco endereco);
        Task Remover(Guid id);
    }
}
