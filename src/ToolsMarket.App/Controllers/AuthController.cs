using Microsoft.AspNetCore.Mvc;
using ToolsMarket.Business.Interfaces;
using ToolsMarket.App.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace ToolsMarket.App.Controllers
{
    [Route("cadastrar")]
    public class AuthController : BaseController
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(INotificador notificador, 
                              UserManager<IdentityUser> userManager,
                              SignInManager<IdentityUser> signInManager) : base(notificador)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Registrar(RegisterViewModel registerUser)
        {
            if(!ModelState.IsValid) return View(registerUser);

            var user = new IdentityUser
            {
                Email = registerUser.Email,
                UserName = registerUser.Email,
                
                
            };

            return RedirectToAction(nameof(Index));
        }
    }
}
