﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToolsMarket.App.ViewModels;
using ToolsMarket.Business.Interfaces;
using ToolsMarket.Business.Models;

namespace ToolsMarket.App.Controllers
{
    public class FornecedoresController : BaseController
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IFornecedorService _fornecedorService;
        private readonly IMapper _mapper;

        public FornecedoresController(IFornecedorRepository fornecedorRepository,
                                      IMapper mapper,
                                      IFornecedorService fornecedorService,
                                      INotificador notificador) : base(notificador)
        {
            _fornecedorRepository = fornecedorRepository;
            _mapper = mapper;
            _fornecedorService = fornecedorService; 
        }

        [Route("fornecedores")]
        public async Task<IActionResult> Index()
        {
              return View(_mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.ObterFornecedores()));
        }

        [Route("fornecedor/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var fornecedorViewModel = await ObterFornecedorProduto(id);

            if (fornecedorViewModel == null) return NotFound();

            return View(fornecedorViewModel);
        }

        [Route("cadastrar-fornecedor")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("cadastrar-fornecedor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FornecedorViewModel fornecedorViewModel)
        {
            if (!ModelState.IsValid) return View(fornecedorViewModel);

            await _fornecedorService.Adicionar(_mapper.Map<Fornecedor>(fornecedorViewModel));

            if (!OperacaoValida()) return View(fornecedorViewModel);

            return RedirectToAction(nameof(Index));
        }

        [Route("editar-fornecedor/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)        {

            var fornecedorViewModel = await ObterFornecedorProduto(id);

            if (fornecedorViewModel == null) return NotFound();

            return View(fornecedorViewModel);
        }

        [Route("editar-fornecedor/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, FornecedorViewModel fornecedorViewModel)
        {
            if (id != fornecedorViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(fornecedorViewModel);

            await _fornecedorService.Atualizar(_mapper.Map<Fornecedor>(fornecedorViewModel));

            if (!OperacaoValida()) return View(fornecedorViewModel);

            return RedirectToAction(nameof(Index));
        }

        [Route("deletar-fornecedor/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var fornecedorViewModel = await ObterFornecedorProduto(id);

            if (fornecedorViewModel == null) return NotFound();

            return View(fornecedorViewModel);
        }

        [Route("deletar-fornecedor/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var fornecedorViewModel = await ObterFornecedorProduto(id);

            if (fornecedorViewModel != null) await _fornecedorService.Remover(id);

            if (!OperacaoValida()) return View(fornecedorViewModel);

            return RedirectToAction(nameof(Index));
        }

        private async Task<FornecedorViewModel> ObterFornecedorProduto(Guid id)
        {
            return _mapper.Map<FornecedorViewModel>(await _fornecedorRepository.ObterFornecedorProduto(id));
        }
    }
}
