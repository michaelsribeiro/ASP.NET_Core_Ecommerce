using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToolsMarket.App.ViewModels;
using ToolsMarket.Business.Interfaces;
using ToolsMarket.Business.Models;

namespace ToolsMarket.App.Controllers
{
    public class EnderecosController : BaseController
    {
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IEnderecoService _enderecoService;
        private readonly IMapper _mapper;

        public EnderecosController(IEnderecoRepository enderecoRepository, IMapper mapper, IEnderecoService enderecoService, INotificador notificador) : base(notificador)
        {
            _enderecoRepository = enderecoRepository;
            _mapper = mapper;
            _enderecoService = enderecoService;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<EnderecoViewModel>>(await _enderecoRepository.ObterEnderecos()));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var enderecoViewModel = await ObterEnderecoUsuario(id);

            if (enderecoViewModel == null) return NotFound();

            return View(enderecoViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EnderecoViewModel enderecoViewModel)
        {
            if (!ModelState.IsValid) return View(enderecoViewModel);

            await _enderecoService.Adicionar(_mapper.Map<Endereco>(enderecoViewModel));

            if (!OperacaoValida()) return View(enderecoViewModel);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var enderecoViewModel = await ObterEnderecoUsuario(id);

            if (enderecoViewModel == null) return NotFound();

            return View(enderecoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, EnderecoViewModel enderecoViewModel)
        {
            if (id != enderecoViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(enderecoViewModel);

            await _enderecoService.Atualizar(_mapper.Map<Endereco>(enderecoViewModel));

            if (!OperacaoValida()) return View(enderecoViewModel);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(Guid id)        {

            var enderecoViewModel = await ObterEnderecoUsuario(id);

            if (enderecoViewModel == null) return NotFound();

            return View(enderecoViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var enderecoViewModel = await ObterEnderecoUsuario(id);

            if (enderecoViewModel != null) await _enderecoService.Remover(id);

            if (!OperacaoValida()) return View(enderecoViewModel);

            return RedirectToAction(nameof(Index));
        }

        private async Task<EnderecoViewModel> ObterEnderecoUsuario(Guid id)
        {
            return _mapper.Map<EnderecoViewModel>(await _enderecoRepository.ObterEnderecoUsuario(id));
        }
    }
}
