using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Filiais.CreateFilial
{
    /// <summary>
    /// Validator for CreateFilialRequest that defines validation rules for filial creation.
    /// </summary>
    public class CreateFilialRequestValidator : AbstractValidator<CreateFilialRequest>
    {
        /// <summary>
        /// Initializes a new instance of the CreateFilialRequestValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - Nome: Must be required, between 3 and 100 characters
        /// - Endereco: Must be required
        /// - Telefone: Must match phone format (+X XXXXXXXXXX)
        /// - Email: Must be valid format (using EmailValidator)
        /// - Status: Cannot be Inativo (or any other status that is not valid)
        /// - Cep: Must match Brazilian postal code format (XXXXX-XXX)
        /// </remarks>
        public CreateFilialRequestValidator()
        {
            RuleFor(filial => filial.Nome).NotEmpty().Length(3, 100);
            RuleFor(filial => filial.Endereco).NotEmpty();
            RuleFor(filial => filial.Telefone).Matches(@"^\+?[1-9]\d{1,14}$");
            RuleFor(filial => filial.Email).SetValidator(new EmailValidator());
            RuleFor(filial => filial.Status).NotEqual(FilialStatus.Inactive);
            RuleFor(filial => filial.Cep).Matches(@"^\d{5}-\d{3}$"); // Brazilian postal code format (XXXXX-XXX)
        }
    }
}
