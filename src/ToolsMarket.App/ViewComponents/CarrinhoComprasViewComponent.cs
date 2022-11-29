using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ToolsMarket.App.ViewModels;
using ToolsMarket.Business.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace ToolsMarket.App.ViewComponents
{
    [ViewComponent]
    public class CarrinhoComprasViewComponent : ViewComponent
    {
        private readonly UserManager<ApplicationUserModel> _userManager;
        private readonly SignInManager<ApplicationUserModel> _signInManager;
        private readonly IPedidoRepository _pedidoRepository;

        public CarrinhoComprasViewComponent(IPedidoRepository pedidoRepository, UserManager<ApplicationUserModel> userManager, SignInManager<ApplicationUserModel> signInManager)
        {
            _pedidoRepository = pedidoRepository;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var itensPedido = 0;

            if (_signInManager.IsSignedIn((ClaimsPrincipal)User)) {
                var idCliente = new Guid(_userManager.GetUserId(Request.HttpContext.User));

                var carrinho = await _pedidoRepository.ObterItemPedido(idCliente);

                if (carrinho != null)
                {
                    itensPedido = carrinho.ItensPedido.Count();
                }
            }

            return View(itensPedido);
        }        
    }
}
