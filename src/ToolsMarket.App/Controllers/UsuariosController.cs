using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToolsMarket.App.ViewModels;
using ToolsMarket.Business.Interfaces;
using ToolsMarket.Business.Models;

namespace ToolsMarket.App.Controllers
{
    public class UsuariosController : BaseController
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuariosController(IUsuarioRepository usuarioRepository, IMapper mapper, INotificador notificador) : base(notificador)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
              return View(_mapper.Map<IEnumerable<UsuarioViewModel>>(await _usuarioRepository.ObterTodos()));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var usuarioViewModel = await ObterUsuarioEndereco(id);

            if (usuarioViewModel == null) return NotFound();

            return View(usuarioViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UsuarioViewModel usuarioViewModel)
        {
            if (!ModelState.IsValid) return View(usuarioViewModel);

            var usuario = _mapper.Map<Usuario>(usuarioViewModel);
            await _usuarioRepository.Adicionar(usuario);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var usuarioViewModel = await ObterUsuarioEndereco(id);

            if (usuarioViewModel == null) return NotFound();

            return View(usuarioViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, UsuarioViewModel usuarioViewModel)
        {
            if (id != usuarioViewModel.Id) return NotFound();

            if (ModelState.IsValid) return View(usuarioViewModel);

            var usuario = _mapper.Map<Usuario>(usuarioViewModel);
            await _usuarioRepository.Atualizar(usuario);

            return RedirectToAction(nameof(Index));            
        }

        public async Task<IActionResult> Delete(Guid id)
        {          
            var usuarioViewModel = await ObterUsuarioEndereco(id);

            if (usuarioViewModel == null) return NotFound();

            return View(usuarioViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var usuarioViewModel = await ObterUsuarioEndereco(id);

            if (usuarioViewModel != null) await _usuarioRepository.Remover(id);
            
            return RedirectToAction(nameof(Index));
        }

        private async Task<UsuarioViewModel> ObterUsuarioEndereco(Guid id)
        {
            return _mapper.Map<UsuarioViewModel>(await _usuarioRepository.ObterUsuarioEndereco(id));
        }

    }
}
