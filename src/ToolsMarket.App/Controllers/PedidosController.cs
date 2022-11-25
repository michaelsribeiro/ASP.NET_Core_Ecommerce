using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ToolsMarket.App.ViewModels;
using ToolsMarket.Business.Interfaces;
using ToolsMarket.Business.Models;
using ToolsMarket.Business.Models.Enum;
using ToolsMarket.Data.Context;

namespace ToolsMarket.App.Controllers
{
    [Authorize]
    public class PedidosController : BaseController
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly CustomDbContext _context;
        private readonly IItemPedidoRepository _itemPedidoRepository;
        private readonly IMapper _mapper;

        public PedidosController(IPedidoRepository pedidoRepository,
                                 IProdutoRepository produtoRepository,
                                 IItemPedidoRepository itemPedidoRepository,
                                 IMapper mapper,
                                 INotificador notificador,
                                 CustomDbContext context) : base(notificador)
        {
            _pedidoRepository = pedidoRepository;
            _produtoRepository = produtoRepository;
            _mapper = mapper;
            _context = context;
            _itemPedidoRepository = itemPedidoRepository;
        }


        [Route("carrinho")]
        [HttpGet]
        public async Task<IActionResult> Index(Guid id)
        {
            var pedidoViewModel = _mapper.Map<PedidoViewModel>(await _pedidoRepository.ObterPedidoPorId(id));

            return View(pedidoViewModel);
        }

        [Route("carrinho/adicionar")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Adicionar([FromForm] Guid id, int qtd)
        {
            var produto = await _context.Produtos.FindAsync(id);

            var carrinho = await _pedidoRepository.ObterItemPedido();

            if (carrinho == null)
            {
                carrinho = new Pedido();
                carrinho.ClienteId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                carrinho.DataVenda = DateTime.Now;
                carrinho.DefinirFrete(carrinho.ValorTotal);
                carrinho.StatusPedido = StatusPedido.Aberto;

                var itemPedido = new ItemPedido()
                {
                    PedidoId = carrinho.Id,
                    Produto = produto,
                    Quantidade = qtd,
                    ProdutoId = produto.Id,
                    ValorUnitario = produto.ValorUnitario
                };                
                carrinho.ItensPedido.Add(itemPedido);
                TempData["carrinho"] = carrinho;

                await _pedidoRepository.Adicionar(carrinho);
            }
            else
            {
                carrinho.ItensPedido.FirstOrDefault(c => c. == Id).Quantidade += qtd;                
            }
            carrinho.ValorTotal = carrinho.ItensPedido.Select(i => i.Produto.ValorUnitario * i.Quantidade).Sum();

            return RedirectToAction("Index", "Pedidos", new { id = carrinho.Id });
        }

    }
}
