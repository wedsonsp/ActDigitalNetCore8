using FluentValidation;
using System;

namespace Ambev.DeveloperEvaluation.Application.Vendas.DeleteVenda
{
    /// <summary>
    /// Validator for DeleteVendaCommand.
    /// </summary>
    public class DeleteVendaCommandValidator : AbstractValidator<DeleteVendaCommand>
    {
        public DeleteVendaCommandValidator()
        {
            // Validação do campo Id: não pode ser vazio
            RuleFor(command => command.Id)
                .NotEmpty().WithMessage("O ID da venda é obrigatório e não pode ser vazio.");
        }
    }
}
