using ToolsMarket.Business.Models;

namespace ToolsMarket.Business.Interfaces
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        Task<Pedido> ObterItemPedido(Guid id);
        Task<IEnumerable<Pedido>> ObterPedidos();
        Task<Pedido> ObterPedidoPorId(Guid id);
    }
}
