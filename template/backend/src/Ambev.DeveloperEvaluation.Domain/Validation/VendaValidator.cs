using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;
using System;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class VendaValidator : AbstractValidator<Venda>
    {
        public VendaValidator()
        {
            // Validação do Número da Venda
            RuleFor(venda => venda.NumeroVenda)
                .NotEmpty().WithMessage("Número da venda é obrigatório.")
                .MinimumLength(3).WithMessage("Número da venda deve ter pelo menos 3 caracteres.")
                .MaximumLength(50).WithMessage("Número da venda não pode ter mais de 50 caracteres.");

            // Validação do Cliente (IdCliente)
            RuleFor(venda => venda.IdCliente)
                .NotEmpty().WithMessage("Id do cliente é obrigatório.");

            // Validação do Cliente (IdCliente)
            RuleFor(venda => venda.IdProduto)
                .NotEmpty().WithMessage("Id do Produto é obrigatório.");

            // Validação do Nome do Cliente
            RuleFor(venda => venda.NomeCliente)
                .NotEmpty().WithMessage("Nome do cliente é obrigatório.")
                .MaximumLength(255).WithMessage("Nome do cliente não pode ter mais de 255 caracteres.");

            // Validação da Filial (IdFilial)
            RuleFor(venda => venda.IdFilial)
                .NotEmpty().WithMessage("Id da filial é obrigatório.");


            // Validação do Valor Total da Venda
            RuleFor(venda => venda.ValorTotalVenda)
                .GreaterThan(0).WithMessage("Valor total da venda deve ser maior que zero.");

            // Validação do Valor Total dos Produtos
            RuleFor(venda => venda.ValorTotalProdutos)
                .GreaterThan(0).WithMessage("Valor total dos produtos deve ser maior que zero.");

            // Validação do Status da Venda
            RuleFor(venda => venda.Status)
                .NotEmpty().WithMessage("Status da venda é obrigatório.")
                .Must(status => status == "Não cancelada" || status == "Cancelada")
                .WithMessage("Status da venda deve ser 'Não cancelada' ou 'Cancelada'.");

            // Validação da Data de Cadastro
            RuleFor(venda => venda.DataCadastro)
                .NotEmpty().WithMessage("Data de cadastro da venda é obrigatória.")
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Data de cadastro não pode ser no futuro.");

            // Validação da Data de Alteração (caso exista)
            RuleFor(venda => venda.DataAlteracao)
                .LessThanOrEqualTo(DateTime.UtcNow).When(venda => venda.DataAlteracao.HasValue)
                .WithMessage("Data de alteração não pode ser no futuro.");
        }
    }
}
