using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToolsMarket.App.Extensions;
using ToolsMarket.App.ViewModels;
using ToolsMarket.Business.Interfaces;
using ToolsMarket.Business.Models;

namespace ToolsMarket.App.Controllers
{
    [Authorize]
    public class CategoriasController : BaseController
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly ICategoriaService _categoriaService;
        private readonly IMapper _mapper;

        public CategoriasController(ICategoriaRepository categoriaRepository, IMapper mapper, ICategoriaService categoriaService, INotificador notificador) : base(notificador)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
            _categoriaService = categoriaService;
        }

        [ClaimsAuthorize("Categoria", "Visualizar")]
        [Route("todas-as-categorias")]
        public async Task<IActionResult> Index()
        {
              return View(_mapper.Map<IEnumerable<CategoriaViewModel>>(await _categoriaRepository.ObterCategorias()));
        }

        [ClaimsAuthorize("Categoria", "Visualizar")]
        [Route("categoria/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var categoriaViewModel = await ObterCategoriaProduto(id);

            if (categoriaViewModel == null) return NotFound();

            return View(categoriaViewModel);
        }

        [ClaimsAuthorize("Categoria", "Adicionar")]
        [Route("criar-categoria")]
        public IActionResult Create()
        {
            return View();
        }

        [ClaimsAuthorize("Categoria", "Adicionar")]
        [Route("criar-categoria")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoriaViewModel categoriaViewModel)
        {
            if (!ModelState.IsValid) return View(categoriaViewModel);

            await _categoriaService.Adicionar(_mapper.Map<Categoria>(categoriaViewModel));

            if (!OperacaoValida()) return View(categoriaViewModel);

            return RedirectToAction(nameof(Index));           
        }


        [ClaimsAuthorize("Categoria", "Editar")]
        [Route("editar-categoria/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var categoriaViewModel = await ObterCategoriaProduto(id);

            if (categoriaViewModel == null) return NotFound();

            return View(categoriaViewModel);
        }

        [ClaimsAuthorize("Categoria", "Editar")]
        [Route("editar-categoria/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, CategoriaViewModel categoriaViewModel)
        {
            if (id != categoriaViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(categoriaViewModel);

            await _categoriaService.Atualizar(_mapper.Map<Categoria>(categoriaViewModel));

            if (!OperacaoValida()) return View(categoriaViewModel);

            return RedirectToAction(nameof(Index));
        }

        [ClaimsAuthorize("Categoria", "Excluir")]
        [Route("deletar-categoria/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var categoriaViewModel = await ObterCategoriaProduto(id);

            if (categoriaViewModel == null) return NotFound();

            return View(categoriaViewModel);
        }

        [ClaimsAuthorize("Categoria", "Excluir")]
        [Route("deletar-categoria/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var categoriaViewModel = await ObterCategoriaProduto(id);

            if (categoriaViewModel != null) await _categoriaService.Remover(id);

            if (!OperacaoValida()) return View(categoriaViewModel);
            
            return RedirectToAction(nameof(Index));
        }

        private async Task<CategoriaViewModel> ObterCategoriaProduto(Guid id)
        {
            return _mapper.Map<CategoriaViewModel>(await _categoriaRepository.ObterCategoriaProduto(id));
        }

        private async Task<IEnumerable<CategoriaViewModel>> ObterCategorias()
        {
            return _mapper.Map<IEnumerable<CategoriaViewModel>>(await _categoriaRepository.ObterCategorias());
        }
    }
}
