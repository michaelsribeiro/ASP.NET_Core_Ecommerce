using Microsoft.AspNetCore.Mvc;
using ToolsMarket.Business.Interfaces;

namespace ToolsMarket.App.ViewComponents
{
    public class NotificacoesViewComponent : ViewComponent
    {
        private readonly INotificador _notificador;

        public NotificacoesViewComponent(INotificador notificador)
        {
            _notificador = notificador;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notificacoes = await Task.FromResult(_notificador.ObterNotificacoes());

            notificacoes.ForEach(c => ViewData.ModelState.AddModelError(string.Empty, c.Mensagem));

            return View();
        }
    }
}
