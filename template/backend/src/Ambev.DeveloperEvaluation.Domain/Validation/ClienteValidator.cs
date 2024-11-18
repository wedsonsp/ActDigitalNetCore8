using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            // Validação do Nome
            RuleFor(cliente => cliente.Nome)
                .NotEmpty().WithMessage("Nome é obrigatório.")
                .MinimumLength(3).WithMessage("Nome deve ter pelo menos 3 caracteres.")
                .MaximumLength(255).WithMessage("Nome não pode ter mais de 255 caracteres.");

            // Validação do Email
            RuleFor(cliente => cliente.Email)
                .EmailAddress().When(cliente => !string.IsNullOrEmpty(cliente.Email))
                .WithMessage("Email deve ser válido.");

            // Validação do Telefone (opcional)
            RuleFor(cliente => cliente.Telefone)
                .Matches(@"^\(\d{2}\) \d{5}-\d{4}$").When(cliente => !string.IsNullOrEmpty(cliente.Telefone))
                .WithMessage("Telefone deve estar no formato (XX) XXXXX-XXXX.");

            // Validação do Status (Se você tiver um status implementado)
            // Caso o status seja parte da lógica de negócios do cliente, por exemplo, se você tiver um enum
            // para representar o status do cliente, adicione essa validação
            // Exemplo:
            // RuleFor(cliente => cliente.Status)
            //     .NotEqual(Status.ClienteDesconhecido)
            //     .WithMessage("Status do cliente não pode ser desconhecido.");

            // Se não houver um Status no modelo, você pode omitir essa validação.

            // Validação do Status (assumindo que Status seja um enum ClienteStatus)
            RuleFor(cliente => cliente.Status)
                .NotEqual(ClienteStatus.Unknown)  // Comparando com o valor do enum
                .WithMessage("Status do cliente não pode ser 'Desconhecido'.");


        }
    }
}
