using System;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Vendas.DeleteVenda
{
    /// <summary>
    /// Represents the response after deleting a sale.
    /// </summary>
    public class DeleteVendaResponse
    {
        /// <summary>
        /// Gets or sets the unique identifier of the sale that was deleted.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the sale number (unique identifier for the sale).
        /// </summary>
        public string NumeroVenda { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a message indicating the result of the deletion.
        /// </summary>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a flag indicating whether the deletion was successful.
        /// </summary>
        public bool Success { get; set; }
    }
}
