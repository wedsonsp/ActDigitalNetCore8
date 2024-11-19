using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Produtos.CreateProduto
{
    /// <summary>
    /// Validator for CreateProdutoRequest that defines validation rules for product creation.
    /// </summary>
    public class CreateProdutoRequestValidator : AbstractValidator<CreateProdutoRequest>
    {
        /// <summary>
        /// Initializes a new instance of CreateProdutoRequestValidator with defined validation rules.
        /// </summary>
        public CreateProdutoRequestValidator()
        {
            // Nome do produto: obrigatório e entre 3 e 255 caracteres
            RuleFor(produto => produto.Nome)
                .NotEmpty().WithMessage("O nome do produto é obrigatório.")
                .Length(3, 255).WithMessage("O nome do produto deve ter entre 3 e 255 caracteres.");

            // Preço do produto: obrigatório e maior que 0
            RuleFor(produto => produto.PrecoUnitario)
                .GreaterThan(0).WithMessage("O preço do produto deve ser maior que zero.");

            //// Categoria do produto: obrigatória
            //RuleFor(produto => produto.Categoria)
            //    .NotEmpty().WithMessage("A categoria do produto é obrigatória.");

            // Descrição do produto: opcional, mas se fornecida, deve ter no máximo 1000 caracteres
            RuleFor(produto => produto.Descricao)
                .MaximumLength(1000).WithMessage("A descrição do produto não pode ter mais de 1000 caracteres.");
        }
    }
}
