using FluentValidation;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Vendas.UpdateVenda
{
    public class UpdateVendaRequestValidator : AbstractValidator<UpdateVendaRequest>
    {
        public UpdateVendaRequestValidator()
        {
            // Valida que o Id da venda é obrigatório para identificação da venda a ser atualizada
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id da venda é obrigatório.");

            // Valida que o NumeroVenda pode ser vazio, pois pode não ser alterado durante a atualização
            //RuleFor(x => x.NumeroVenda)
            //    .NotEmpty().WithMessage("Número da venda não pode ser vazio se fornecido.")
            //    .When(x => !string.IsNullOrEmpty(x.NumeroVenda));

            // Valida que o IdFilial não pode ser nulo ou vazio, mas é opcional
            RuleFor(x => x.IdFilial)
                .NotEmpty().WithMessage("Id da filial é obrigatório.")
                .When(x => x.IdFilial.HasValue);

            // Valida que o NomeFilial não pode ser vazio, mas é opcional
            RuleFor(x => x.NomeFilial)
                .NotEmpty().WithMessage("Nome da filial é obrigatório.")
                .When(x => !string.IsNullOrEmpty(x.NomeFilial));

            // Valida que o IdProduto é opcional, mas se fornecido, deve ser válido
            RuleFor(x => x.IdProduto)
                .NotEmpty().WithMessage("Id do produto é obrigatório.")
                .When(x => x.IdProduto.HasValue);

            // Valida que o NomeProduto não pode ser vazio, mas é opcional
            //RuleFor(x => x.NomeProduto)
            //    .NotEmpty().WithMessage("Nome do produto é obrigatório.")
            //    .When(x => !string.IsNullOrEmpty(x.NomeProduto));

            // Valida que o IdCliente não pode ser nulo ou vazio
            //RuleFor(x => x.IdCliente)
            //    .NotEmpty().WithMessage("Id do cliente é obrigatório.")
            //    .When(x => x.IdCliente.HasValue);

            // Valida que o NomeCliente não pode ser vazio
            //RuleFor(x => x.NomeCliente)
            //    .NotEmpty().WithMessage("Nome do cliente é obrigatório.")
            //    .When(x => !string.IsNullOrEmpty(x.NomeCliente));

            // Valida que o Status da venda seja válido
            RuleFor(x => x.Status)
                .Must(status => status == "Não cancelada" || status == "Cancelada")
                .WithMessage("Status deve ser 'Não cancelada' ou 'Cancelada'.");

            // Valida que os ItensVenda não sejam vazios ou nulos
            //RuleFor(x => x.ItensVenda)
            //    .NotEmpty().WithMessage("Itens de venda não podem ser vazios.")
            //    .When(x => x.ItensVenda != null && x.ItensVenda.Count > 0);

            //// Validar cada item da lista de ItensVenda, se fornecidos
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
