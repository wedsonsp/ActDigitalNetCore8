using FluentValidation;
using Ambev.DeveloperEvaluation.Application.Vendas.UpdateVenda;
using Ambev.DeveloperEvaluation.Application.ItemVendas.UpdateItemVenda;

namespace Ambev.DeveloperEvaluation.Application.Vendas.UpdateVenda
{
    public class UpdateVendaCommandValidator : AbstractValidator<UpdateVendaCommand>
    {
        public UpdateVendaCommandValidator()
        {
            // Validação do ID da venda
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("O ID da venda é obrigatório.");

            // Validação do número da venda
            RuleFor(x => x.NumeroVenda)
                .NotEmpty().WithMessage("O número da venda é obrigatório.")
                .Length(3, 20).WithMessage("O número da venda deve ter entre 3 e 20 caracteres.");

            // Validação do ID do cliente
            RuleFor(x => x.IdCliente)
                .NotEmpty().WithMessage("O ID do cliente é obrigatório.");

            // Validação do nome do cliente
            RuleFor(x => x.NomeCliente)
                .NotEmpty().WithMessage("O nome do cliente é obrigatório.")
                .Length(3, 100).WithMessage("O nome do cliente deve ter entre 3 e 100 caracteres.");

            // Validação do ID da filial
            RuleFor(x => x.IdFilial)
                .NotEmpty().WithMessage("O ID da filial é obrigatório.");

            // Validação do nome da filial
            RuleFor(x => x.NomeFilial)
                .NotEmpty().WithMessage("O nome da filial é obrigatório.")
                .Length(3, 100).WithMessage("O nome da filial deve ter entre 3 e 100 caracteres.");

            // Validação do valor total da venda
            RuleFor(x => x.ValorTotalVenda)
                .GreaterThan(0).WithMessage("O valor total da venda deve ser maior que zero.");

            // Validação do valor total com desconto
            RuleFor(x => x.ValorTotalVendaDesconto)
                .GreaterThan(0).WithMessage("O valor total da venda com desconto deve ser maior que zero.");

            // Validação do status da venda
            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("O status da venda é obrigatório.");

            // Validação dos itens de venda
            RuleForEach(x => x.ItensVenda)
                .SetValidator(new UpdateItemVendaCommandValidator())
                .WithMessage("Os itens da venda são inválidos.");
        }
    }
}
