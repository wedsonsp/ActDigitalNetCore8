using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Clientes.CreateCliente
{
    /// <summary>
    /// Validator for CreateClienteCommand that defines validation rules for client creation command.
    /// </summary>
    public class CreateClienteCommandValidator : AbstractValidator<CreateClienteCommand>
    {
        /// <summary>
        /// Initializes a new instance of the CreateClienteCommandValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - Email: Must be in valid format (using EmailValidator)
        /// - Nome: Required, must be between 3 and 255 characters
        /// - Telefone: Must match phone format (optional)
        /// - Status: Must not be empty (e.g., "Ativo", "Inativo", etc.)
        /// </remarks>
        public CreateClienteCommandValidator()
        {
            // Validação do Email (formato correto)
            RuleFor(cliente => cliente.Email)
                .EmailAddress().When(cliente => !string.IsNullOrEmpty(cliente.Email))
                .WithMessage("Email deve ser válido.");

            // Validação do Nome
            RuleFor(cliente => cliente.Nome)
                .NotEmpty().WithMessage("Nome é obrigatório.")
                .MinimumLength(3).WithMessage("Nome deve ter pelo menos 3 caracteres.")
                .MaximumLength(255).WithMessage("Nome não pode ter mais de 255 caracteres.");

            // Validação do Telefone (opcional)
            RuleFor(cliente => cliente.Telefone)
                .Matches(@"^\(\d{2}\) \d{5}-\d{4}$").When(cliente => !string.IsNullOrEmpty(cliente.Telefone))
                .WithMessage("Telefone deve estar no formato (XX) XXXXX-XXXX.");

            // Validação do Status (se aplicável)
            RuleFor(cliente => cliente.Status)
                .NotEmpty().WithMessage("Status é obrigatório.")
                .MaximumLength(50).WithMessage("Status não pode ter mais de 50 caracteres.");
        }
    }
}
