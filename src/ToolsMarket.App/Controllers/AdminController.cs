using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Exchange.WebServices.Data;
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
        private readonly UserManager<ApplicationUserModel> _userManager;
        private readonly IMapper _mapper;

        public AdminController(IProdutoRepository produtoRepository,
                               IPedidoRepository pedidoRepository,
                               ICategoriaRepository categoriaRepository,
                               IFornecedorRepository fornecedorRepository,
                               IMapper mapper,
                               IProdutoService produtoService,
                               UserManager<ApplicationUserModel> userManager,
                               INotificador notificador) : base(notificador)
        {
            _pedidoRepository = pedidoRepository;
            _produtoRepository = produtoRepository;
            _categoriaRepository = categoriaRepository;
            _fornecedorRepository = fornecedorRepository;
            _mapper = mapper;
            _produtoService = produtoService;
            _userManager = userManager;
        }

        [ClaimsAuthorize("Admin", "Visualizar")]
        [Route("admin")]
        public async Task<IActionResult> Index()
        {
            var result = await _pedidoRepository.ObterTodos();

            var totalClientes = _userManager.Users.Count();

            var totalVendas = result.Sum(x => x.ValorTotal);

            var totalPedidos = result.Count();

            var adminViewModel = new AdminViewModel(totalVendas, totalClientes, totalPedidos);

            return View(adminViewModel);
        }        
    }
}
