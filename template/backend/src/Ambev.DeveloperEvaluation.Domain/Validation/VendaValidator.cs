using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    /// <summary>
    /// Validator for the Venda entity.
    /// </summary>
    public class VendaValidator : AbstractValidator<Venda>
    {
        public VendaValidator()
        {
            // Validando o NumeroVenda (não pode ser vazio e deve ter pelo menos 5 caracteres)
            RuleFor(venda => venda.NumeroVenda)
                .NotEmpty()
                .WithMessage("O número da venda não pode ser vazio.")
                .MinimumLength(5)
                .WithMessage("O número da venda deve ter no mínimo 5 caracteres.")
                .MaximumLength(50)
                .WithMessage("O número da venda não pode exceder 50 caracteres.");

            // Validando o TotalVenda (não pode ser negativo ou zero)
            RuleFor(venda => venda.TotalVenda)
                .GreaterThan(0)
                .WithMessage("O valor total da venda deve ser maior que zero.");

            // Validando o Status da venda (não pode ser "cancelado")
            RuleFor(venda => venda.Status)
                .NotEmpty()
                .WithMessage("O status da venda não pode ser vazio.")
                .Must(status => status != "cancelado")
                .WithMessage("O status da venda não pode ser 'cancelado'.");

            // Validando o relacionamento com o Cliente (IdCliente não pode ser vazio)
            RuleFor(venda => venda.IdCliente)
                .NotEmpty()
                .WithMessage("O ID do cliente não pode ser vazio.");

            // Validando o relacionamento com a Filial (IdFilial não pode ser vazio)
            RuleFor(venda => venda.IdFilial)
                .NotEmpty()
                .WithMessage("O ID da filial não pode ser vazio.");
        }
    }
}
