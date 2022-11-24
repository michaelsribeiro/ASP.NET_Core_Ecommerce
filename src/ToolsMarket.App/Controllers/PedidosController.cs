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

        [AllowAnonymous]
        [Route("carrinho")]
        public async Task<IActionResult> Index()
        {
            return View(await _pedidoRepository.ObterCarrinhosUsuario());
        }

        [Route("carrinho/adicionar")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Adicionar([FromForm] Guid id, int qtd)
        {
            Pedido carrinho = new();

            var produto = await _context.Produtos.FindAsync(id);

            if (produto != null)
            {

                if (carrinho.ItensPedido.FirstOrDefault(c => c.Id == produto.Id) != null)
                {
                    carrinho.ItensPedido.FirstOrDefault(c => c.Id == produto.Id).Quantidade += qtd;
                }
                else
                {
                    var itemPedido = new ItemPedido()
                    {
                        Produto = produto,
                        Quantidade = qtd,
                        ProdutoId = produto.Id,
                        ValorUnitario = produto.ValorUnitario
                    };


                    carrinho.ClienteId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                    carrinho.DataVenda = DateTime.Now;
                    carrinho.DefinirFrete(carrinho.ValorTotal);
                    carrinho.StatusPedido = StatusPedido.Aberto;
                    carrinho.ItensPedido.Add(itemPedido);
                    carrinho.Produtos = carrinho.ItensPedido.Select(c => c.Produto);
                }

                carrinho.ValorTotal = carrinho.ItensPedido.Select(i => i.Produto.ValorUnitario * i.Quantidade).Sum();
            }

            await _pedidoRepository.Adicionar(carrinho);

            return RedirectToAction(nameof(Index));
        }


        private async Task<IEnumerable<PedidoViewModel>> ObterCarrinhosUsuario()
        {
            return _mapper.Map<IEnumerable<PedidoViewModel>>(await _pedidoRepository.ObterCarrinhosUsuario());
        }
    }
}
