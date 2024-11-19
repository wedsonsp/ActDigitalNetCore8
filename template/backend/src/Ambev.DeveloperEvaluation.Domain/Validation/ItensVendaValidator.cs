using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class ItensVendaValidator : AbstractValidator<ItemVenda>
    {
        public ItensVendaValidator()
        {
            // A quantidade não pode ser negativa ou zero.
            RuleFor(item => item.Quantidade)
                .GreaterThan(0).WithMessage("Quantidade deve ser maior que zero.");

            // O preço unitário não pode ser negativo ou zero.
            RuleFor(item => item.PrecoUnitario)
                .GreaterThan(0).WithMessage("Preço unitário deve ser maior que zero.");

            // O valor total deve ser calculado com base na quantidade e preço unitário, e o desconto
            RuleFor(item => item.ValorTotal)
                .Equal(x => (x.Quantidade * x.PrecoUnitario) - x.Desconto)
                .WithMessage("Valor total está incorreto.");
        }
    }
}
