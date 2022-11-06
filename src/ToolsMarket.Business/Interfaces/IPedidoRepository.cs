using ToolsMarket.Business.Models;

namespace ToolsMarket.Business.Interfaces
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        Task<IEnumerable<Pedido>> ObterCarrinhosPedido(Guid pedidoId);
        Task<Pedido> ObterCarrinhoUsuario(Guid usuarioId);
    }
}
