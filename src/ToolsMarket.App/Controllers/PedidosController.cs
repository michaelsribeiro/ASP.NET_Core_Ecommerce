using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToolsMarket.App.ViewModels;
using ToolsMarket.Business.Interfaces;
using ToolsMarket.Business.Models;

namespace ToolsMarket.App.Controllers
{
    [Authorize]
    public class PedidosController : BaseController
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IRepository<Produto> _repository;
        private readonly IMapper _mapper;

        public PedidosController(IPedidoRepository pedidoRepository, IMapper mapper, INotificador notificador) : base(notificador)
        {
            _pedidoRepository = pedidoRepository;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [Route("carrinho")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<PedidoViewModel>>(await _pedidoRepository.ObterPedidos()));
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Adicionar(Guid id, int qtd)
        {
            if (id == null) return NotFound();


            var produto = _repository.ObterPorId(id);

            return View();
        }
       

        private async Task<PedidoViewModel> ObterPedidoUsuario(Guid id)
        {
            return _mapper.Map<PedidoViewModel>(await _pedidoRepository.ObterPedidoUsuario(id));
        }

        private async Task<IEnumerable<PedidoViewModel>> ObterCarrinhosUsuario()
        {
            return _mapper.Map<IEnumerable<PedidoViewModel>>(await _pedidoRepository.ObterCarrinhosUsuario());
        }
    }
}
