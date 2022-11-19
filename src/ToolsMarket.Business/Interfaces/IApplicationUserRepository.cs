using ToolsMarket.App.Data;

namespace ToolsMarket.Business.Interfaces
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
        Task<ApplicationUser> ObterUsuarioEndereco(Guid id);
        Task<ApplicationUser> ObterUsuarioPedido(Guid id);
        Task<IEnumerable<ApplicationUser>> ObterUsuarioPedidos();
    }
}
