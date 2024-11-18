using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Clients.CreateCliente
{
    public class CreateClienteRequestValidator : AbstractValidator<CreateClienteRequest>
    {
        public CreateClienteRequestValidator()
        {
            // Valida que o Nome não pode ser vazio
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Nome do cliente é obrigatório.");

            // Valida que, se o Email for fornecido, deve ser um email válido
            RuleFor(x => x.Email)
                .EmailAddress().When(x => !string.IsNullOrEmpty(x.Email)).WithMessage("Email inválido.");

            // Valida que, se o Telefone for fornecido, deve ter um formato válido
            RuleFor(x => x.Telefone)
                .Matches(@"^\(\d{2}\) \d{5}-\d{4}$").When(x => !string.IsNullOrEmpty(x.Telefone))
                .WithMessage("Telefone deve estar no formato (XX) XXXXX-XXXX.");
        }
    }
}
