using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Filiais.CreateFilial
{
    /// <summary>
    /// Validator for CreateFilialCommand that defines validation rules for creating a filial.
    /// </summary>
    public class CreateFilialCommandValidator : AbstractValidator<CreateFilialCommand>
    {
        /// <summary>
        /// Initializes a new instance of the CreateFilialCommandValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - Nome: Required, must be between 3 and 255 characters
        /// - Endereco: Required, cannot be empty
        /// - Cidade: Required, cannot be empty
        /// - Estado: Required, cannot be empty
        /// </remarks>
        public CreateFilialCommandValidator()
        {
            // Nome da filial: obrigatório e entre 3 e 255 caracteres
            RuleFor(filial => filial.Nome)
                .NotEmpty().WithMessage("O nome da filial é obrigatório.")
                .Length(3, 255).WithMessage("O nome da filial deve ter entre 3 e 255 caracteres.");

            // Endereço da filial: obrigatório
            RuleFor(filial => filial.Endereco)
                .NotEmpty().WithMessage("O endereço é obrigatório.");

            // Cidade da filial: obrigatório
            RuleFor(filial => filial.Cidade)
                .NotEmpty().WithMessage("A cidade é obrigatória.");

            // Estado da filial: obrigatório
            RuleFor(filial => filial.Estado)
                .NotEmpty().WithMessage("O estado é obrigatório.");
        }
    }
}
