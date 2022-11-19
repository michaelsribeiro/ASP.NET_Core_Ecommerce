using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToolsMarket.App.ViewModels;
using ToolsMarket.Business.Models;
using ToolsMarket.Data.Context;

namespace ToolsMarket.App.ViewComponents
{
    [ViewComponent]
    public class FerramentasEletricasViewComponent : ViewComponent
    {
        private readonly CustomDbContext _context;
        private readonly IMapper _mapper;

        public FerramentasEletricasViewComponent(CustomDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var produtos = await ObterFerramentasEletricas();
            return View(produtos);
        }

        private async Task<IEnumerable<ProdutoViewModel>> ObterFerramentasEletricas()
        {
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(await _context.Produtos
                                                                            .Include(c => c.Categoria)
                                                                            .Where(c => c.Categoria.NomeCategoria.Equals("Ferramentas Elétricas"))
                                                                            .OrderByDescending(p => p.Id)
                                                                            .ToListAsync());
        }
    }
}