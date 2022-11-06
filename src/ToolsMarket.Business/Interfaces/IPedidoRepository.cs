using ToolsMarket.Business.Models;

namespace ToolsMarket.Business.Interfaces
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        Task<IEnumerable<Pedido>> ObterCarrinhosUsuario();
    }
}
