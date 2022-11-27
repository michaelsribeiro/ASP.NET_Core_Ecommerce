using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
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
        private readonly IItemPedidoRepository _itemPedidoRepository;
        private readonly IMapper _mapper;

        public PedidosController(IPedidoRepository pedidoRepository,
                                 IProdutoRepository produtoRepository,
                                 IItemPedidoRepository itemPedidoRepository,
                                 IMapper mapper,
                                 INotificador notificador) : base(notificador)
        {
            _pedidoRepository = pedidoRepository;
            _produtoRepository = produtoRepository;
            _mapper = mapper;
            _itemPedidoRepository = itemPedidoRepository;
        }


        [Route("carrinho")]
        public async Task<IActionResult> Index(Guid id)
        {
            var pedidoViewModel = _mapper.Map<PedidoViewModel>(await _pedidoRepository.ObterPedidoPorId(id));


            if (pedidoViewModel == null)
            {
                var idCliente = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));

                pedidoViewModel = _mapper.Map<PedidoViewModel>(await _pedidoRepository.ObterItemPedido(idCliente));
            }

            return View(pedidoViewModel);
        }

        [Route("carrinho/adicionar")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Adicionar([FromForm] Guid id, int qtd)
        {
            var isInsert = false;

            var idCliente = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var carrinho = await _pedidoRepository.ObterItemPedido(idCliente);

            if (carrinho == null)
            {
                isInsert = true;
                carrinho = new Pedido();
                carrinho.ClienteId = idCliente;
                carrinho.DataVenda = DateTime.Now;
                carrinho.DefinirFrete(carrinho.ValorTotal);
                carrinho.StatusPedido = StatusPedido.Aberto;
            }

            var itemPedido = carrinho.ItensPedido.FirstOrDefault(c => c.ProdutoId == id);

            if (itemPedido == null)
            {
                var produto = await _produtoRepository.ObterPorId(id);

                itemPedido = new ItemPedido();
                itemPedido.PedidoId = carrinho.Id;
                itemPedido.Produto = produto;
                itemPedido.Quantidade = qtd;
                itemPedido.ProdutoId = produto.Id;
                itemPedido.ValorUnitario = produto.ValorUnitario;

                carrinho.ItensPedido.Add(itemPedido);
            }
            else
            {
                itemPedido.Quantidade += qtd;
            }

            carrinho.ValorTotal = carrinho.ItensPedido.Select(i => i.Produto.ValorUnitario * i.Quantidade).Sum();

            if (isInsert)
                await _pedidoRepository.Adicionar(carrinho);
            else
                await _pedidoRepository.Atualizar(carrinho);

            return RedirectToAction("Index", "Pedidos", new { id = carrinho.Id });
        }

        [Route("carrinho/removerQtd")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> RemoverQtd([FromForm] Guid id)
        {
            var idCliente = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var carrinho = await _pedidoRepository.ObterItemPedido(idCliente);

            var itemPedido = carrinho.ItensPedido.FirstOrDefault(c => c.ProdutoId == id);

            if (carrinho.ItensPedido != null)
            {
                if (itemPedido.Quantidade > 1)
                {
                    itemPedido.Quantidade -= 1;
                    carrinho.ValorTotal = carrinho.ItensPedido.Select(i => i.Produto.ValorUnitario * i.Quantidade).Sum();
                    await _pedidoRepository.Atualizar(carrinho);
                }
                else
                {
                    carrinho.ValorTotal = carrinho.ItensPedido.Select(i => i.Produto.ValorUnitario * i.Quantidade).Sum();
                    await _pedidoRepository.Remover(carrinho.Id);
                }
            }

            return RedirectToAction("Index", "Pedidos", new { id = carrinho.Id });
        }

        [Route("carrinho/removerProduto")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> RemoverProduto([FromForm] Guid id)
        {
            var idCliente = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var carrinho = await _pedidoRepository.ObterItemPedido(idCliente);

            var itemPedido = carrinho.ItensPedido.FirstOrDefault(c => c.ProdutoId == id);

            if (carrinho.ItensPedido.Count() > 1)
            {
                carrinho.ItensPedido.Remove(itemPedido);
                carrinho.ValorTotal = carrinho.ItensPedido.Select(i => i.Produto.ValorUnitario * i.Quantidade).Sum();
                await _pedidoRepository.Atualizar(carrinho);
            }
            else
            {
                await _pedidoRepository.Remover(carrinho.Id);
            }

            return RedirectToAction("Index", "Pedidos", new { id = carrinho.Id });
        }
    }
}