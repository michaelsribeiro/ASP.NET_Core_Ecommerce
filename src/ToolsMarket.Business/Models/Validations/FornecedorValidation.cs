using FluentValidation;
using ToolsMarket.Business.Models.Validations.Documents;

namespace ToolsMarket.Business.Models.Validations
{
    public class FornecedorValidation : AbstractValidator<Fornecedor>
    {
        public FornecedorValidation()
        {
            RuleFor(f => f.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(3, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLenght} e {MaxLenght} caracteres.");

            RuleFor(f => f.Cnpj.Length).Equal(ValidaCNPJ.TamanhoCnpj)
                .WithMessage("O campo documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");

            RuleFor(f => ValidaCPF.Validar(f.Cnpj)).Equal(true).WithMessage("CNPJ inválido.");
        }
    }
}
