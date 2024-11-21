using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;
using System;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class ItemVendaValidator : AbstractValidator<ItemVenda>
    {
        public ItemVendaValidator()
        {
            // Validação do Produto (ProdutoId)
            RuleFor(item => item.IdProduto)
                .NotEmpty().WithMessage("Id do produto é obrigatório.");

            // Validação da Quantidade
            RuleFor(item => item.Quantidade)
                .GreaterThan(0).WithMessage("Quantidade deve ser maior que zero.")
                .LessThanOrEqualTo(10000).WithMessage("Quantidade não pode ser maior que 10.000.");

            // Validação do Preço Unitário
            RuleFor(item => item.PrecoUnitario)
                .GreaterThan(0).WithMessage("Preço unitário deve ser maior que zero.");

            // Validação do Desconto
            RuleFor(item => item.Desconto)
                .GreaterThanOrEqualTo(0).WithMessage("Desconto não pode ser menor que zero.")
                .LessThanOrEqualTo(100).WithMessage("Desconto não pode ser maior que 100.");

            // Validação do Valor Total do Item (Preço Unitário * Quantidade - Desconto)
            RuleFor(item => item.ValorTotal)
                .GreaterThan(0).WithMessage("Valor total do item deve ser maior que zero.")
                .Must((item, valorTotalItem) =>
                    valorTotalItem == (item.Quantidade * item.PrecoUnitario - item.Desconto)).WithMessage("O valor total do item está incorreto.");
        }
    }
}
