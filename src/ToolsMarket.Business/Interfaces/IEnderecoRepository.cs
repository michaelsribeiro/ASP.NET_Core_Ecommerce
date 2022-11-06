using ToolsMarket.Business.Models;

namespace ToolsMarket.Business.Interfaces
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        Task<Endereco> ObterEnderecoPorUsuario(Guid usuarioId);
    }
}
