using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;
using System.Security.Claims;
using ToolsMarket.App.ViewModels;
using ToolsMarket.Business.Interfaces;
using ToolsMarket.Data.Context;

namespace ToolsMarket.App.ViewComponents
{
    [ViewComponent]
    public class CarrinhoComprasViewComponent : ViewComponent
    {
        private readonly CustomDbContext _context;
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IMapper _mapper;

        public CarrinhoComprasViewComponent(CustomDbContext context, IPedidoRepository pedidoRepository, IMapper mapper)
        {
            _context = context;
            _pedidoRepository= pedidoRepository;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var itensPedido = await ObterCarrinho();
            return View(itensPedido);
        }

        private async Task<IEnumerable<PedidoViewModel>> ObterCarrinho()
        {
            var idCliente = new Guid(User. Claims.Where(c => c.Type == "sub").FirstOrDefault().Value);

            var carrinho = await _pedidoRepository.ObterItemPedido(idCliente);

            return _mapper.Map<IEnumerable<PedidoViewModel>>(await _context.Pedidos
                                                                           .Include(i => i.ItensPedido)
                                                                           .
                                                                           .ToListAsync());
        }
    }
}
