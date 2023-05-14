using ToolsMarket.Business.Interfaces;
using ToolsMarket.Business.Models;
using ToolsMarket.Business.Models.Enum;
using ToolsMarket.Business.Models.Validations;

namespace ToolsMarket.Business.Services
{
    public class PedidoService : BaseService, IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository, INotificador notificador) : base(notificador)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task AtualizarStatus(Guid id, StatusPedido status)    
        {
            var pedidoBanco = await _pedidoRepository.ObterPorId(id);

            pedidoBanco.AtualizarStatus(status);

            await _pedidoRepository.Atualizar(pedidoBanco);
        }

        public void Dispose()
        {
            _pedidoRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
