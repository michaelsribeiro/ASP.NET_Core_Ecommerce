using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ToolsMarket.App.Extensions;
using ToolsMarket.App.ViewModels;

namespace ToolsMarket.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("erro/{id:length(3,3)}")]
        public IActionResult Errors(int id)
        {
            var modelErro = new ErrorViewModel();

            if(id == 500)
            {
                modelErro.Mensagem = "Ocorreu um erro, Tente novamente mais tarde ou contate o nosso suporte.";
                modelErro.Titulo = "Ocorreu um erro!";
                modelErro.ErroCode = id;
            }
            else if(id == 404)
            {
                modelErro.Mensagem = "A página que você tentou acessar não foi encontrada. Por favor verifique o endereço acessado e tente novamente.";
                modelErro.Titulo = "Página não encontrada.";
                modelErro.ErroCode = id;
            }
            else if (id == 403)
            {
                modelErro.Mensagem = "Você não tem permissão para acessar esta seção!";
                modelErro.Titulo = "Acesso negado!";
                modelErro.ErroCode = id;
            }
            else
            {
                return StatusCode(404);
            }

            return View("Error", modelErro);
        }
    }
}