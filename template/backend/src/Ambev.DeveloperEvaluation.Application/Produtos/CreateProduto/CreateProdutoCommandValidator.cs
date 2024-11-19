using Ambev.DeveloperEvaluation.Application.Produtos.CreateProduto;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    /// <summary>
    /// Validador para o comando de criação de produto.
    /// </summary>
    public class CreateProdutoCommandValidator : AbstractValidator<CreateProdutoCommand>
    {
        public CreateProdutoCommandValidator()
        {
            // Nome do produto: não pode ser vazio e deve ter comprimento máximo de 255 caracteres
            RuleFor(command => command.Nome)
                .NotEmpty().WithMessage("O nome do produto não pode ser vazio.")
                .MaximumLength(255).WithMessage("O nome do produto não pode ter mais de 255 caracteres.");

            // Preço unitário: deve ser maior que zero
            RuleFor(command => command.PrecoUnitario)
                .GreaterThan(0).WithMessage("O preço unitário deve ser maior que zero.");

            // Descrição do produto: opcional, mas se fornecida, não pode exceder 1000 caracteres
            RuleFor(command => command.Descricao)
                .MaximumLength(1000).WithMessage("A descrição do produto não pode ter mais de 1000 caracteres.");

            // Data de criação do produto: deve ser no presente ou no passado
            RuleFor(command => command.CreatedAt)
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("A data de criação não pode ser no futuro.");
        }
    }
}
