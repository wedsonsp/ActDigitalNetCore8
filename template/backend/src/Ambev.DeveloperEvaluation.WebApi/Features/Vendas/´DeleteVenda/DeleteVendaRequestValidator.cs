using FluentValidation;
using System;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Vendas.DeleteVenda
{
    public class DeleteVendaRequestValidator : AbstractValidator<DeleteVendaRequest>
    {
        public DeleteVendaRequestValidator()
        {
            // Valida que o IdVenda não pode ser vazio ou nulo
            RuleFor(x => x.IdVenda)
                .NotEmpty().WithMessage("Id da venda é obrigatório.");

            // Valida que o NumeroVenda não pode ser vazio, caso esteja sendo usado
            RuleFor(x => x.NumeroVenda)
                .NotEmpty().WithMessage("Número da venda é obrigatório.");
        }
    }
}
