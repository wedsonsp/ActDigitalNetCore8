using FluentValidation;
using Ambev.DeveloperEvaluation.Application.ItemVendas.CreateItemVenda;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class CreateItemVendaCommandValidator : AbstractValidator<CreateItemVendaCommand>
    {
        public CreateItemVendaCommandValidator()
        {
            // Validação do ProdutoId
            RuleFor(x => x.IdProduto)
                .NotEmpty().WithMessage("O ProdutoId é obrigatório.");

            // Validação da Quantidade
            RuleFor(x => x.Quantidade)
                .GreaterThan(0).WithMessage("A quantidade do produto deve ser maior que zero.");

            // Validação do Preço Unitário
            RuleFor(x => x.PrecoUnitario)
                .GreaterThan(0).WithMessage("O preço unitário deve ser maior que zero.");

            // Validação da VendaId
            RuleFor(x => x.IdVenda)
                .NotEmpty().WithMessage("O VendaId é obrigatório.");
        }
    }
}
