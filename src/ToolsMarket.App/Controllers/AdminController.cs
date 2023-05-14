using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToolsMarket.App.Extensions;
using ToolsMarket.App.ViewModels;
using ToolsMarket.Business.Interfaces;

namespace ToolsMarket.App.Controllers
{
    [Authorize]
    public class AdminController : BaseController
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IPedidoRepository _pedidoRepository;
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        public AdminController(IProdutoRepository produtoRepository,
                               IPedidoRepository pedidoRepository,
                               ICategoriaRepository categoriaRepository,
                               IFornecedorRepository fornecedorRepository,
                               IMapper mapper,
                               IProdutoService produtoService,
                               INotificador notificador) : base(notificador)
        {
            _pedidoRepository = pedidoRepository;
            _produtoRepository = produtoRepository;
            _categoriaRepository = categoriaRepository;
            _fornecedorRepository = fornecedorRepository;
            _mapper = mapper;
            _produtoService = produtoService;
        }

        [ClaimsAuthorize("Admin", "Visualizar")]
        [Route("admin")]
        public async Task<IActionResult> Index()
        {
            var result = await _pedidoRepository.ObterTodos();

            var totalVendas = result.Sum(x => x.ValorTotal);

            var adminViewModel = new AdminViewModel();

            var viewModel = _mapper.Map<IEnumerable<PedidoViewModel>>(result);

            return View(viewModel);
        }        
    }
}
