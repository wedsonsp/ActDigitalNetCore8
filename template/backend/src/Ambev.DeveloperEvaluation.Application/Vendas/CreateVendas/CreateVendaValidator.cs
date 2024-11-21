using FluentValidation;
using Ambev.DeveloperEvaluation.Application.Vendas.CreateVenda;
using System.Linq;

namespace Ambev.DeveloperEvaluation.Application.Vendas.CreateVenda
{
    public class CreateVendaCommandValidator : AbstractValidator<CreateVendaCommand>
    {
        public CreateVendaCommandValidator()
        {
            // Validação do Número da Venda
            RuleFor(venda => venda.NumeroVenda)
                .NotEmpty().WithMessage("Número da venda é obrigatório.")
                .MinimumLength(3).WithMessage("Número da venda deve ter pelo menos 3 caracteres.")
                .MaximumLength(50).WithMessage("Número da venda não pode ter mais de 50 caracteres.");

            // Validação do Cliente
            RuleFor(venda => venda.IdCliente)
                .NotEmpty().WithMessage("Id do cliente é obrigatório.");

            // Validação do Nome do Cliente
            RuleFor(venda => venda.NomeCliente)
                .NotEmpty().WithMessage("Nome do cliente é obrigatório.")
                .Length(3, 255).WithMessage("Nome do cliente deve ter entre 3 e 255 caracteres.");

            // Validação da Filial
            RuleFor(venda => venda.IdFilial)
                .NotEmpty().WithMessage("Id da filial é obrigatório.");

            // Validação do Nome da Filial
            RuleFor(venda => venda.NomeFilial)
                .NotEmpty().WithMessage("Nome da filial é obrigatório.")
                .Length(3, 255).WithMessage("Nome da filial deve ter entre 3 e 255 caracteres.");

            // Validação do Valor Total da Venda
            RuleFor(venda => venda.ValorTotalVenda)
                .GreaterThan(0).WithMessage("Valor total da venda deve ser maior que zero.");

            // Validação do Valor Total dos Produtos
            //RuleFor(venda => venda.ValorTotalVendaDesconto)
            //    .GreaterThan(0).WithMessage("Valor total dos produtos deve ser maior que zero.");

            // Validação do Status da Venda
            RuleFor(venda => venda.Status)
                .NotEmpty().WithMessage("Status da venda é obrigatório.")
                .Must(status => status == "Não cancelada" || status == "Cancelada")
                .WithMessage("Status da venda deve ser 'Não cancelada' ou 'Cancelada'.");

            //// Validação dos Itens de Venda
            //RuleFor(venda => venda.ItensVenda)
            //    .Must(itensVenda => itensVenda != null && itensVenda.Count > 0 && itensVenda.All(item =>
            //    item.Quantidade > 0 &&
            //    item.PrecoUnitario > 0 &&
            //    item.ValorTotal == (decimal)item.Quantidade * ((decimal)item.PrecoUnitario - (decimal)item.Desconto)  // Convertendo para decimal
            //)).WithMessage("Itens de venda inválidos.");



            // Validação da Data de Cadastro
            RuleFor(venda => venda.DataCadastro)
                .NotEmpty().WithMessage("Data de cadastro da venda é obrigatória.")
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Data de cadastro não pode ser no futuro.");
        }
    }
}
