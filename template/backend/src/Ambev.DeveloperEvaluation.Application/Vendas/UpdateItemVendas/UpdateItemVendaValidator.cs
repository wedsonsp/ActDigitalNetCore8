using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.ItemVendas.UpdateItemVenda
{
    public class UpdateItemVendaCommandValidator : AbstractValidator<UpdateItemVendaCommand>
    {
        public UpdateItemVendaCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("O ID do item é obrigatório.");

            RuleFor(x => x.IdProduto)
                .NotEmpty().WithMessage("O ID do produto é obrigatório.");         

            RuleFor(x => x.ValorTotal)
                .GreaterThan(0).WithMessage("O valor total do item deve ser maior que zero.");

            RuleFor(x => x.Desconto)
                .GreaterThanOrEqualTo(0).WithMessage("O desconto não pode ser negativo.");
        }
    }
}
