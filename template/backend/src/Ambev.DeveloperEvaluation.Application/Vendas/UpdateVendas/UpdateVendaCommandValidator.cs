using FluentValidation;
using Ambev.DeveloperEvaluation.Application.Vendas.UpdateVenda;
using Ambev.DeveloperEvaluation.Application.ItemVendas.UpdateItemVenda;

namespace Ambev.DeveloperEvaluation.Application.Vendas.UpdateVenda
{
    public class UpdateVendaCommandValidator : AbstractValidator<UpdateVendaCommand>
    {
        public UpdateVendaCommandValidator()
        {
            // Validação do ID da venda
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("O ID da venda é obrigatório.");

            // Validação do ID da filial
            //RuleFor(x => x.IdFilial)
            //    .NotEmpty().WithMessage("O ID da filial é obrigatório.");

            // Validação do nome da filial
            //RuleFor(x => x.NomeFilial)
            //    .NotEmpty().WithMessage("O nome da filial é obrigatório.")
            //    .Length(3, 100).WithMessage("O nome da filial deve ter entre 3 e 100 caracteres.");

            // Validação do status da venda
            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("O status da venda é obrigatório.");

            // Validação dos itens de venda
            RuleForEach(x => x.ItensVenda)
                .SetValidator(new UpdateItemVendaCommandValidator())
                .WithMessage("Os itens da venda são inválidos.");
        }
    }
}
