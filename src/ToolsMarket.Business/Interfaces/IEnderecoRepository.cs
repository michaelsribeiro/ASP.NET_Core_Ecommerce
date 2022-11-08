using ToolsMarket.Business.Models;

namespace ToolsMarket.Business.Interfaces
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        Task<Endereco> ObterEnderecoPorUsuario(Guid usuarioId);
        Task<IEnumerable<Endereco>> ObterEnderecos();
        Task<Endereco> ObterEnderecoUsuario(Guid id);
    }
}
