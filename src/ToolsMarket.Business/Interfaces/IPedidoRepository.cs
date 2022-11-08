using ToolsMarket.Business.Models;

namespace ToolsMarket.Business.Interfaces
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        Task<IEnumerable<Pedido>> ObterCarrinhosUsuario();
        Task<IEnumerable<Pedido>> ObterPedidos();
        Task<Pedido> ObterPedidoUsuario(Guid id);
    }
}
