namespace Ambev.DeveloperEvaluation.Application.ItemVendas.UpdateItemVenda
{
    /// <summary>
    /// Represents the response returned after successfully updating an item in the sale.
    /// </summary>
    /// <remarks>
    /// This response contains the unique identifier of the updated item,
    /// which can be used for subsequent operations or reference.
    /// </remarks>
    public class UpdateItemVendaResult
    {
        /// <summary>
        /// Gets or sets the unique identifier of the updated item in the sale.
        /// </summary>
        /// <value>A GUID that uniquely identifies the updated item in the system.</value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the sale the item is associated with.
        /// </summary>
        /// <value>A GUID that identifies the sale to which the item belongs.</value>
        public Guid IdVenda { get; set; }

        /// <summary>
        /// Gets or sets the updated quantity of the item in the sale.
        /// </summary>
        /// <value>The quantity of the item in the sale.</value>
        public int Quantidade { get; set; }

        /// <summary>
        /// Gets or sets the updated price per unit of the item.
        /// </summary>
        /// <value>The price per unit of the item in the sale.</value>
        public decimal PrecoUnitario { get; set; }

        /// <summary>
        /// Gets or sets the updated total value of the item (Quantity * Unit Price).
        /// </summary>
        /// <value>The total value of the item in the sale.</value>
        public decimal ValorTotal { get; set; }

        /// <summary>
        /// Gets or sets the updated discount for the item, if any.
        /// </summary>
        /// <value>The discount applied to the item.</value>
        public decimal Desconto { get; set; }
    }
}
