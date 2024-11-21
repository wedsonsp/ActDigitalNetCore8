using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Vendas.GetVenda
{
    /// <summary>
    /// Validator for GetVendaRequest
    /// </summary>
    public class GetVendaRequestValidator : AbstractValidator<GetVendaRequest>
    {
        /// <summary>
        /// Initializes validation rules for GetVendaRequest
        /// </summary>
        public GetVendaRequestValidator()
        {
            // Regra de validação para garantir que o Id não seja vazio
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Sale ID is required");
        }
    }
}
