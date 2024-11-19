using FluentValidation;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Vendas.CreateVenda
{
    public class CreateVendaRequestValidator : AbstractValidator<CreateVendaRequest>
    {
        public CreateVendaRequestValidator()
        {
            // Valida que o NumeroVenda não pode ser vazio
            RuleFor(x => x.NumeroVenda)
                .NotEmpty().WithMessage("Número da venda é obrigatório.");

            // Valida que o IdCliente não pode ser nulo ou vazio
            RuleFor(x => x.IdCliente)
                .NotEmpty().WithMessage("Id do cliente é obrigatório.");

            // Valida que o IdFilial não pode ser nulo ou vazio
            RuleFor(x => x.IdFilial)
                .NotEmpty().WithMessage("Id da filial é obrigatório.");

            // Valida que o NomeCliente não pode ser vazio
            RuleFor(x => x.NomeCliente)
                .NotEmpty().WithMessage("Nome do cliente é obrigatório.");

            // Valida que o NomeFilial não pode ser vazio
            RuleFor(x => x.NomeFilial)
                .NotEmpty().WithMessage("Nome da filial é obrigatório.");

            // Valida que o ValorTotalVenda deve ser maior que zero
            RuleFor(x => x.ValorTotalVenda)
                .GreaterThan(0).WithMessage("Valor total da venda deve ser maior que zero.");

            // Valida que o ValorTotalProdutos deve ser maior que zero
            RuleFor(x => x.ValorTotalProdutos)
                .GreaterThan(0).WithMessage("Valor total dos produtos deve ser maior que zero.");

            // Valida que o Status da venda seja válido
            RuleFor(x => x.Status)
                .Must(status => status == "Não cancelada" || status == "Cancelada")
                .WithMessage("Status deve ser 'Não cancelada' ou 'Cancelada'.");

            // Valida que os ItensVenda não sejam vazios
            //RuleFor(x => x.ItensVenda)
            //    .NotEmpty().WithMessage("Itens de venda não podem ser vazios.")
            //    .Must(x => x.Count > 0).WithMessage("A lista de itens de venda deve ter ao menos um item.");

            //// Validar cada item da lista de ItensVenda
            //RuleForEach(x => x.ItensVenda)
            //    .ChildRules(item =>
            //    {
            //        item.RuleFor(i => i.IdProduto).NotEmpty().WithMessage("Id do produto é obrigatório.");
            //        item.RuleFor(i => i.Quantidade).GreaterThan(0).WithMessage("Quantidade deve ser maior que zero.");
            //        item.RuleFor(i => i.PrecoUnitario).GreaterThan(0).WithMessage("Preço unitário deve ser maior que zero.");
            //    });
        }
    }
}
