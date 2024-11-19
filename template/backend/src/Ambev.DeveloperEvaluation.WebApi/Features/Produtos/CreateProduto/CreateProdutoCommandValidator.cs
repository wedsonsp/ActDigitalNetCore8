using Ambev.DeveloperEvaluation.WebApi.Features.Produtos.CreateProduto;
using FluentValidation;

public class CreateProdutoCommandValidator : AbstractValidator<CreateProdutoRequest>
{
    public CreateProdutoCommandValidator()
    {
        RuleFor(p => p.Nome)
            .NotEmpty().WithMessage("O nome do produto é obrigatório.")
            .Length(3, 255).WithMessage("O nome do produto deve ter entre 3 e 255 caracteres.");

        RuleFor(p => p.PrecoUnitario)
            .GreaterThan(0).WithMessage("O preço unitário deve ser maior que zero.");
    }
}
