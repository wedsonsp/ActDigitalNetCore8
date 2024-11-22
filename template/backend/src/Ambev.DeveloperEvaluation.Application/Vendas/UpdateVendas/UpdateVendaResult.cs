namespace Ambev.DeveloperEvaluation.Application.Vendas.UpdateVendas
{
    /// <summary>
    /// Represents the response returned after successfully updating a sale (venda).
    /// </summary>
    /// <remarks>
    /// This response contains the unique identifier of the updated sale,
    /// which can be used for subsequent operations or reference.
    /// </remarks>
    public class UpdateVendaResult
    {
        /// <summary>
        /// Gets or sets the unique identifier of the updated sale.
        /// </summary>
        /// <value>A GUID that uniquely identifies the updated sale in the system.</value>
        public Guid Id { get; set; }

        public string NumeroVenda { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets the status of the sale after the update.
        /// </summary>
        /// <value>A string indicating the status of the sale (e.g., "Updated", "Success").</value>
        public string Status { get; set; } = "Updated";

        /// <summary>
        /// Gets or sets the timestamp of when the sale was last updated.
        /// </summary>
        /// <value>A DateTime representing the last update timestamp.</value>
        public DateTime DataAlteracao { get; set; } = DateTime.UtcNow;
    }
}
