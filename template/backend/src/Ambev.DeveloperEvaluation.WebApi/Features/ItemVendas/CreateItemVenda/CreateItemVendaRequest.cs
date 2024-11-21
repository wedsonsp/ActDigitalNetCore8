using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.ItemVendas.CreateItemVenda;

/// <summary>
/// Represents a request to create a new item for a sale in the system.
/// </summary>
public class CreateItemVendaRequest
{
    public Guid IdVenda { get; set; }

    public Guid IdProduto { get; set; }

    /// <summary>
    /// Gets or sets the name of the item being sold.
    /// </summary>
    public string NomeProduto { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the quantity of the item in the sale.
    /// </summary>
    public int Quantidade { get; set; }

    /// <summary>
    /// Gets or sets the price of a single unit of the item.
    /// </summary>
    public decimal PrecoUnitario { get; set; }

    /// <summary>
    /// Gets or sets the total value of the item (quantity * unit price).
    /// </summary>
    public decimal ValorTotal => Quantidade * PrecoUnitario;

    /// <summary>
    /// Gets or sets the discount applied to the item.
    /// </summary>
    public decimal Desconto { get; set; }

    /// <summary>
    /// Gets or sets the status of the item in the sale.
    /// </summary>
    public ItemVendaStatus Status { get; set; }
}
