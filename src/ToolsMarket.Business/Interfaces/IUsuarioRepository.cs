using ToolsMarket.Business.Models;

namespace ToolsMarket.Business.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Usuario> ObterUsuarioEndereco(Guid id);
        Task<Usuario> ObterUsuarioPedido(Guid id);
        Task<IEnumerable<Usuario>> ObterUsuarioPedidos();
    }
}
