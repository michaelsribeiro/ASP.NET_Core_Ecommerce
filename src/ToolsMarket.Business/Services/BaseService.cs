using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolsMarket.Business.Models;

namespace ToolsMarket.Business.Services
{
    public abstract class BaseService
    {
        protected void Notificar(ValidationResult validationResult)
        {
            foreach(var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem)
        {

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
