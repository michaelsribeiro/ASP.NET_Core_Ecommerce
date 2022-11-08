using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToolsMarket.App.ViewModels;
using ToolsMarket.Business.Interfaces;
using ToolsMarket.Business.Models;

namespace ToolsMarket.App.Controllers
{
    public class PedidosController : BaseController
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IMapper _mapper;

        public PedidosController(IPedidoRepository pedidoRepository, IMapper mapper)
        {
            _pedidoRepository = pedidoRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<PedidoViewModel>>(await _pedidoRepository.ObterPedidos()));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var pedidoViewModel = await ObterPedidoUsuario(id);

            if (pedidoViewModel == null) return NotFound();

            return View(pedidoViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PedidoViewModel pedidoViewModel)
        {
            if (!ModelState.IsValid) return View(pedidoViewModel);

            await _pedidoRepository.Adicionar(_mapper.Map<Pedido>(pedidoViewModel));

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var pedidoViewModel = await ObterPedidoUsuario(id);

            if (pedidoViewModel == null) return NotFound();

            return View(pedidoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, PedidoViewModel pedidoViewModel)
        {
            if (id != pedidoViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(pedidoViewModel);

            await _pedidoRepository.Atualizar(_mapper.Map<Pedido>(pedidoViewModel));

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var pedidoViewModel = await ObterPedidoUsuario(id);
             
            if (pedidoViewModel == null) return NotFound();

            return View(pedidoViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var pedidoViewModel = await ObterPedidoUsuario(id);

            if (pedidoViewModel != null)
            {
                await _pedidoRepository.Remover(id);
            }
            
            return RedirectToAction(nameof(Index));
        }

        private async Task<PedidoViewModel> ObterPedidoUsuario(Guid id)
        {
            return _mapper.Map<PedidoViewModel>(await _pedidoRepository.ObterPedidoUsuario(id));
        }
    }
}
