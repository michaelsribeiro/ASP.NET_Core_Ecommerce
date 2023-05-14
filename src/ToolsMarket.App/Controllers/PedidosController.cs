using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ToolsMarket.App.Data;
using ToolsMarket.App.Extensions;
using ToolsMarket.App.ViewModels;
using ToolsMarket.Business.Interfaces;
using ToolsMarket.Business.Models;
using ToolsMarket.Business.Models.Enum;

namespace ToolsMarket.App.Controllers
{
    [Authorize]
    public class PedidosController : BaseController
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IItemPedidoRepository _itemPedidoRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly UserManager<ApplicationUserModel> _userManager;
        private readonly IPedidoService _pedidoService;
        private readonly IMapper _mapper;

        public PedidosController(IPedidoRepository pedidoRepository,
                                 IProdutoRepository produtoRepository,
                                 IItemPedidoRepository itemPedidoRepository,
                                 IEnderecoRepository enderecoRepository,
                                 UserManager<ApplicationUserModel> userManager,
                                 IPedidoService pedidoService,
                                 IMapper mapper,
                                 INotificador notificador) : base(notificador)
        {
            _pedidoRepository = pedidoRepository;
            _produtoRepository = produtoRepository;
            _userManager = userManager;
            _mapper = mapper;
            _itemPedidoRepository = itemPedidoRepository;
            _enderecoRepository = enderecoRepository;
            _pedidoService = pedidoService;
        }

        [ClaimsAuthorize("Pedido", "Visualizar")]
        [Route("pedidos")]
        public async Task<IActionResult> PedidoIndex()
        {
            var result = await _pedidoRepository.ObterTodos();

            foreach (var item in result)
            {
                var clienteBanco = _userManager.Users.FirstOrDefault(m => m.Id == item.ClienteId.ToString());

                var cliente = new ApplicationUser(clienteBanco.Nome, clienteBanco.Cpf, clienteBanco.Genero.ToString(), clienteBanco.Telefone, clienteBanco.Email);

                item.DefinirCliente(cliente);
            }

            var viewModel = _mapper.Map<IEnumerable<PedidoViewModel>>(result);

            return View(viewModel);
        }

        [ClaimsAuthorize("Pedido", "Editar")]
        [Route("editar-pedido/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var pedido = await _pedidoRepository.ObterPedidoPorId(id);

            var cliente = _userManager.Users.FirstOrDefault(m => m.Id == pedido.ClienteId.ToString());

            var domain = new ApplicationUser(cliente.Nome, cliente.Cpf, cliente.Genero.ToString(), cliente.Telefone, cliente.Email);

            var endereco = await _enderecoRepository.ObterEnderecoUsuario(cliente.EnderecoId);

            var itensPedido = await _itemPedidoRepository.ObterItemPedidoProduto(pedido.ItensPedido.Select(x => x.Id).First());

            pedido.DefinirCliente(domain);

            pedido.DefinirEndereco(endereco);

            var pedidoViewModel = _mapper.Map<PedidoViewModel>(pedido);

            if (pedidoViewModel == null) return NotFound();

            return View(pedidoViewModel);
        }

        [ClaimsAuthorize("Pedido", "Editar")]
        [Route("editar-pedido/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, PedidoViewModel pedidoViewModel)
        {
            var statusPedido = (StatusPedido)pedidoViewModel.Status;

            await _pedidoService.AtualizarStatus(id, statusPedido);

            if (!OperacaoValida()) return RedirectToAction(nameof(PedidoIndex));

            TempData["Sucesso"] = "Pedido atualizado com sucesso.";

            return RedirectToAction(nameof(PedidoIndex));
        }

        [Route("carrinho")]
        public async Task<IActionResult> Index(Guid id)
        {
            var pedidoViewModel = _mapper.Map<PedidoViewModel>(await _pedidoRepository.ObterPedidoPorId(id));


            if (pedidoViewModel != null)
            {
                ViewBag.QtdParcelas = pedidoViewModel.QuantidadeParcelas;
                ViewBag.ValorParcela = pedidoViewModel.ValorParcela;
            }
            else
            {
                var idCliente = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));

                pedidoViewModel = _mapper.Map<PedidoViewModel>(await _pedidoRepository.ObterItemPedido(idCliente));

                if(pedidoViewModel != null)
                {
                    ViewBag.QtdParcelas = pedidoViewModel.QuantidadeParcelas;
                    ViewBag.ValorParcela = pedidoViewModel.ValorParcela;
                }
                else
                {
                    ViewBag.QtdParcelas = "";
                    ViewBag.ValorParcela = "";
                }
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
                itemPedido.Quantidade = itemPedido.Produto.Quantidade >= qtd ? qtd : itemPedido.Produto.Quantidade ;
                itemPedido.ProdutoId = produto.Id;
                itemPedido.ValorUnitario = produto.ValorUnitario;
                itemPedido.SubTotal = itemPedido.ValorUnitario * itemPedido.Quantidade;

                carrinho.ItensPedido.Add(itemPedido);
            }
            else
            {
                itemPedido.Quantidade += qtd;
            }

            carrinho.ValorTotal = carrinho.ItensPedido.Select(i => i.SubTotal).Sum();

            if (isInsert)
                await _pedidoRepository.Adicionar(carrinho);
            else
                await _itemPedidoRepository.Adicionar(itemPedido);
                await _pedidoRepository.Atualizar(carrinho);

            return RedirectToAction("Index", "Pedidos", new { id = carrinho.Id });
        }

        [Route("carrinho/adicionarQtd")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> AdicionarQtd([FromForm] Guid id)
        {
            var idCliente = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var carrinho = await _pedidoRepository.ObterItemPedido(idCliente);

            var itemPedido = carrinho.ItensPedido.FirstOrDefault(c => c.ProdutoId == id);

            if (carrinho.ItensPedido != null)
            {
                if (itemPedido.Quantidade >= 1 && itemPedido.Produto.Quantidade > itemPedido.Quantidade)
                {
                    itemPedido.Quantidade += 1;
                    itemPedido.SubTotal = itemPedido.ValorUnitario * itemPedido.Quantidade;
                    carrinho.ValorTotal = carrinho.ItensPedido.Select(i => i.SubTotal).Sum();
                    await _pedidoRepository.Atualizar(carrinho);
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

            if (carrinho != null)
            {
                if (carrinho.ItensPedido.Count() > 1)
                {
                    await _itemPedidoRepository.Remover(itemPedido.Id);
                    carrinho = await _pedidoRepository.ObterItemPedido(idCliente);
                    carrinho.ValorTotal = carrinho.ItensPedido.Select(i => i.SubTotal).Sum();
                    await _pedidoRepository.Atualizar(carrinho);
                }
                else
                {
                    await _itemPedidoRepository.Remover(itemPedido.Id);
                    await _pedidoRepository.Remover(carrinho.Id);
                }
            }

            carrinho.ValorTotal = carrinho.ItensPedido.Select(i => i.SubTotal).Sum();

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

            if (itemPedido.Quantidade > 1)
            {
                itemPedido.Quantidade -= 1;
                itemPedido.SubTotal = itemPedido.ValorUnitario * itemPedido.Quantidade;
                carrinho.ValorTotal = carrinho.ItensPedido.Select(i => i.SubTotal).Sum();
                await _pedidoRepository.Atualizar(carrinho);
            }

            return RedirectToAction("Index", "Pedidos", new { id = carrinho.Id });
        }
    }
}