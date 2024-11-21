using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.ItemVendas.CreateItemVenda;

/// <summary>
/// API response model for CreateItemVenda operation
/// </summary>
public class CreateItemVendaResponse
{
    /// <summary>
    /// The unique identifier of the created sale item
    /// </summary>
    public Guid IdVenda { get; set; }

    public Guid IdProduto { get; set; }

    /// <summary>
    /// The name of the item being sold
    /// </summary>
    public string NomeProduto { get; set; } = string.Empty;

    /// <summary>
    /// The quantity of the item in the sale
    /// </summary>
    public int Quantidade { get; set; }

    /// <summary>
    /// The unit price of the item
    /// </summary>
    public decimal PrecoUnitario { get; set; }

    /// <summary>
    /// The total value of the item (calculated as quantity * unit price)
    /// </summary>
    public decimal ValorTotal { get; set; }

    /// <summary>
    /// The category of the item (e.g., beverage, food, etc.)
    /// </summary>
    public string Categoria { get; set; } = string.Empty;

    /// <summary>
    /// The description of the item
    /// </summary>
    public string Descricao { get; set; } = string.Empty;

    /// <summary>
    /// The discount applied to the item
    /// </summary>
    public decimal Desconto { get; set; }

    /// <summary>
    /// The status of the item in the sale
    /// </summary>
    public ItemVendaStatus Status { get; set; }
}
