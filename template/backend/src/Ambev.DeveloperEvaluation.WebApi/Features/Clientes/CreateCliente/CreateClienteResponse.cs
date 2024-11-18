using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Clients.CreateCliente
{
    /// <summary>
    /// Represents the response after creating a new client.
    /// </summary>
    public class CreateClienteResponse
    {
        /// <summary>
        /// Gets or sets the unique identifier of the client.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the client.
        /// </summary>
        public string Nome { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the email address of the client.
        /// This field is optional, so it could be null if not provided.
        /// </summary>
        public string? Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the phone number of the client.
        /// This field is optional, so it could be null if not provided.
        /// </summary>
        public string? Telefone { get; set; } = string.Empty;

        /// <summary>
        /// The current status of the cliente
        /// </summary>
        public ClienteStatus Status { get; set; }
    }
}
