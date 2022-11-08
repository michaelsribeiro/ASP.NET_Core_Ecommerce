﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToolsMarket.App.Data;
using ToolsMarket.App.ViewModels;
using ToolsMarket.Business.Interfaces;
using ToolsMarket.Business.Models;

namespace ToolsMarket.App.Controllers
{
    public class CarrinhosController : BaseController
    {
        private readonly ICarrinhoRepository _carrinhoRepository;
        private readonly IMapper _mapper;

        public CarrinhosController(ICarrinhoRepository carrinhoRepository, IMapper mapper)
        {
            _carrinhoRepository = carrinhoRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {            
            return View(_mapper.Map<IEnumerable<CarrinhoViewModel>>(await _carrinhoRepository.ObterCarrinhoProdutos()));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var carrinhoViewModel = await ObterCarrinhoProduto(id);

            if (carrinhoViewModel == null) return NotFound();

            return View(carrinhoViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CarrinhoViewModel carrinhoViewModel)
        {
            if (!ModelState.IsValid) return View(carrinhoViewModel);

            await _carrinhoRepository.Adicionar(_mapper.Map<Carrinho>(carrinhoViewModel));

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var carrinhoViewModel = await ObterCarrinhoProduto(id);

            if (carrinhoViewModel == null) return NotFound();

            return View(carrinhoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, CarrinhoViewModel carrinhoViewModel)
        {
            if (id != carrinhoViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(carrinhoViewModel);

            await _carrinhoRepository.Atualizar(_mapper.Map<Carrinho>(carrinhoViewModel));

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(Guid id)
        {           
            var carrinhoViewModel = await ObterCarrinhoProduto(id);

            if (carrinhoViewModel == null)
            {
                return NotFound();
            }

            return View(carrinhoViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var carrinhoViewModel = await ObterCarrinhoProduto(id);

            if (carrinhoViewModel != null) await _carrinhoRepository.Remover(id);
            
            return RedirectToAction(nameof(Index));        }

        private async Task<CarrinhoViewModel> ObterCarrinhoProduto(Guid id)
        {
            return _mapper.Map<CarrinhoViewModel>(await _carrinhoRepository.ObterCarrinhoProduto(id));
        }
    }
}
