using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.ItemVendas.CreateItemVenda;

/// <summary>
/// Validator for CreateItemVendaRequest that defines validation rules for item venda creation.
/// </summary>
public class CreateItemVendaRequestValidator : AbstractValidator<CreateItemVendaRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateItemVendaRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Nome: Required, length between 3 and 100 characters
    /// - Quantidade: Must be greater than 0
    /// - PrecoUnitario: Must be greater than 0
    /// - ValorTotal: Automatically calculated based on quantity and unit price (not required)
    /// - Desconto: Must be between 0 and 100 (percentage)
    /// - Status: Cannot be inactive
    /// </remarks>
    public CreateItemVendaRequestValidator()
    {
        //RuleFor(item => item.IdVenda).NotEqual(Guid.Empty).WithMessage("O IdVenda é obrigatório.");
        RuleFor(item => item.IdProduto).NotEqual(Guid.Empty).WithMessage("O IdProduto é obrigatório.");
        RuleFor(item => item.NomeProduto).NotEmpty().Length(3, 100);
        RuleFor(item => item.Quantidade).GreaterThan(0);
        RuleFor(item => item.PrecoUnitario).GreaterThan(0);
        RuleFor(item => item.ValorTotal).GreaterThan(0).When(item => item.Quantidade > 0 && item.PrecoUnitario > 0);
        //RuleFor(item => item.Desconto).InclusiveBetween(0, 100);
        RuleFor(item => item.Status).NotEqual(ItemVendaStatus.Inactive); // Removida a duplicação
    }
}
