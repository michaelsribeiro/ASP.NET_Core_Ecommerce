using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToolsMarket.App.ViewModels;
using ToolsMarket.Data.Context;

namespace ToolsMarket.App.ViewComponents
{
    [ViewComponent]
    public class DestaqueViewComponent : ViewComponent
    {
        private readonly CustomDbContext _context;
        private readonly IMapper _mapper;

        public DestaqueViewComponent(CustomDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var produtos = await ObterProdutos();
            return View(produtos);
        }

        private async Task<IEnumerable<ProdutoViewModel>> ObterProdutos()
        {
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(await _context.Produtos.AsNoTracking()
                                                                                     .OrderBy(p => p.Nome)
                                                                                     .ToListAsync());
        }
    }
}
