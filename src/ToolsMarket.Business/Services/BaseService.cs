using FluentValidation;
using FluentValidation.Results;
using ToolsMarket.Business.Interfaces;
using ToolsMarket.Business.Models;
using ToolsMarket.Business.Notifications;

namespace ToolsMarket.Business.Services
{
    public abstract class BaseService
    {
        private readonly INotificador _notificador;

        protected BaseService(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach(var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }

        protected bool ExecutaValidacao<TValidation, TEntity>(TValidation validacao, TEntity entidade) where TValidation : AbstractValidator<TEntity> where TEntity : Entity
        {
            var validator = validacao.Validate(entidade);
            
            if(validator.IsValid) return true;

            Notificar(validator);
            return false;
        }
    }
}
