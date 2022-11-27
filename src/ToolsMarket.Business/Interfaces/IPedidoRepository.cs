using ToolsMarket.Business.Models;

namespace ToolsMarket.Business.Interfaces
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        Task<Pedido> ObterItemPedido(Guid id);
        Task<Pedido> ObterItemPedidoProduto(Guid id);
        Task<Pedido> ObterPedidoPorId(Guid id);
    }
}
