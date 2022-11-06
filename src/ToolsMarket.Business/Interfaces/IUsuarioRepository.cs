using ToolsMarket.Business.Models;

namespace ToolsMarket.Business.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<IEnumerable<Usuario>> ObterPedidosUsuario(Guid usuarioId);
        Task<IEnumerable<Usuario>> ObterPedidosUsuarios();
    }
}
