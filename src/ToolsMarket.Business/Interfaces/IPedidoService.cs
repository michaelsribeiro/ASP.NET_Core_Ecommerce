using ToolsMarket.Business.Models;
using ToolsMarket.Business.Models.Enum;

namespace ToolsMarket.Business.Interfaces
{
    public interface IPedidoService : IDisposable
    {
        Task AtualizarStatus(Guid id, StatusPedido status);
    }
}
