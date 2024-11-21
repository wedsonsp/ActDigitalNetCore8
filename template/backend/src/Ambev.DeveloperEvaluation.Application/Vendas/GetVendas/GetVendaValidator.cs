using FluentValidation;
using Ambev.DeveloperEvaluation.Application.Vendas.GetVenda;

namespace Ambev.DeveloperEvaluation.Application.Vendas.GetVenda
{
    /// <summary>
    /// Validator for GetVendaCommand
    /// </summary>
    public class GetVendaValidator : AbstractValidator<GetVendaCommand>
    {
        /// <summary>
        /// Initializes validation rules for GetVendaCommand
        /// </summary>
        public GetVendaValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Venda ID is required");
        }
    }
}
