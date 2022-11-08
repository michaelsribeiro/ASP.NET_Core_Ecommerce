using System.Collections;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToolsMarket.App.ViewModels;
using ToolsMarket.Business.Interfaces;
using ToolsMarket.Business.Models;

namespace ToolsMarket.App.Controllers
{
    public class CategoriasController : BaseController
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public CategoriasController(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
              return View(_mapper.Map<IEnumerable<CategoriaViewModel>>(await _categoriaRepository.ObterCategorias()));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var categoriaViewModel = await ObterCategoriaProduto(id);

            if (categoriaViewModel == null) return NotFound();

            return View(categoriaViewModel);
        }

        private Task<IEnumerable> ObterCategoria(Guid id)
        {
            throw new NotImplementedException();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoriaViewModel categoriaViewModel)
        {
            if (!ModelState.IsValid) return View(categoriaViewModel);

            await _categoriaRepository.Adicionar(_mapper.Map<Categoria>(categoriaViewModel));

            return RedirectToAction(nameof(Index));           
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var categoriaViewModel = await ObterCategoriaProduto(id);

            if (categoriaViewModel == null) return NotFound();

            return View(categoriaViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, CategoriaViewModel categoriaViewModel)
        {
            if (id != categoriaViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(categoriaViewModel);

            await _categoriaRepository.Atualizar(_mapper.Map<Categoria>(categoriaViewModel));

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var categoriaViewModel = await ObterCategoriaProduto(id);

            if (categoriaViewModel == null) return NotFound();

            return View(categoriaViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var categoriaViewModel = await ObterCategoriaProduto(id);

            if (categoriaViewModel != null) await _categoriaRepository.Remover(id);
            
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
