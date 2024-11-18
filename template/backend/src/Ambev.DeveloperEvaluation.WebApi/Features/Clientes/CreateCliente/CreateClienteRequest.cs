using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Clients.CreateCliente;

/// <summary>
/// Represents a request to create a new client in the system.
/// </summary>
public class CreateClienteRequest
{
    /// <summary>
    /// Gets or sets the name of the client. This field is required.
    /// </summary>
    public string Nome { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the email address of the client. This field is optional.
    /// </summary>
    public string? Email { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the phone number of the client. This field is optional.
    /// </summary>
    public string? Telefone { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the initial status of the user account.
    /// </summary>
    public ClienteStatus Status { get; set; }
}
