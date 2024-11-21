using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.WebApi.Features.ItemVendas.CreateItemVenda;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Clients.CreateCliente;

/// <summary>
/// Represents a request to create a new client in the system.
/// </summary>
/// <summary>
/// Represents a request to create a new client in the system.
/// </summary>
public class CreateClienteRequest
{
    public Guid IdCliente { get; set; }

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
    /// Gets or sets the initial status of the client account.
    /// </summary>
    public ClienteStatus Status { get; set; }

    /// <summary>
    /// Gets or sets the list of items for the client sale (optional, if you want to associate items directly with the client).
    /// </summary>
    public List<CreateItemVendaRequest> ItensVenda { get; set; } = new List<CreateItemVendaRequest>();
}
