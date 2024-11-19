using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator()
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("O nome do produto não pode ser vazio.")
                .MaximumLength(255).WithMessage("O nome do produto deve ter no máximo 255 caracteres.");

            RuleFor(p => p.PrecoUnitario)
                .GreaterThan(0).WithMessage("O preço unitário deve ser maior que zero.");

            RuleFor(p => p.Descricao)
                .MaximumLength(1000).WithMessage("A descrição do produto deve ter no máximo 1000 caracteres.");
        }
    }
}
