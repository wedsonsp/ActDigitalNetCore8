using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Clientes.CreateCliente
{
    /// <summary>
    /// Command for creating a new client.
    /// </summary>
    /// <remarks>
    /// This command is used to capture the required data for creating a client, 
    /// including name, phone number, email, and status. It implements 
    /// <see cref="IRequest{TResponse}"/> to initiate the request 
    /// that returns a <see cref="CreateClienteResult"/>.
    /// </remarks>
    public class CreateClienteCommand : IRequest<CreateClienteResult>
    {
        /// <summary>
        /// Gets or sets the name of the client to be created.
        /// </summary>
        public string Nome { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the email address for the client.
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the phone number for the client.
        /// </summary>
        public string Telefone { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the status of the client.
        /// </summary>
        public string Status { get; set; } = string.Empty; // Caso o status do cliente seja um campo string

        /// <summary>
        /// Validates the command data using the associated validator.
        /// </summary>
        public ValidationResultDetail Validate()
        {
            var validator = new CreateClienteCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
