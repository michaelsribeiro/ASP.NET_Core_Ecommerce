using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToolsMarket.App.ViewModels;
using ToolsMarket.Business.Interfaces;
using ToolsMarket.Business.Models;
using ToolsMarket.Business.Services;

namespace ToolsMarket.App.Controllers
{
    [Authorize]
    public class PedidosController : BaseController
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IMapper _mapper;

        public PedidosController(IPedidoRepository pedidoRepository, IMapper mapper, INotificador notificador) : base(notificador)
        {
            _pedidoRepository = pedidoRepository;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [Route("carrinho")]
        public async Task<IActionResult> Index(Guid id)
        {
            return View(_mapper.Map<IEnumerable<PedidoViewModel>>(await _pedidoRepository.ObterPedidos()));
        }

        [Route("carrinho/adicionar")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Adicionar(Guid id, PedidoViewModel pedidoViewModel)
        {
            try
            {
                pedidoViewModel = await ObterPedidoUsuario(id);

                if (pedidoViewModel != null)
                {
                    var domain = new Pedido(
                        pedidoViewModel.UsuarioId,
                        pedidoViewModel.DataVenda = new DateTime(),
                        pedidoViewModel.Quantidade = 1,
                        pedidoViewModel.ValorTotal
                    );
                    await _pedidoRepository.Adicionar(domain);
                }
                else
                {
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                ModelState.AddModelError("erro", err.Message);
                return View(pedidoViewModel);
            }
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
