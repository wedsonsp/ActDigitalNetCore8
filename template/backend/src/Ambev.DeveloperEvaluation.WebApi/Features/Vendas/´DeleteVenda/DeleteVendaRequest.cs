using System;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Vendas.DeleteVenda
{
    /// <summary>
    /// Represents a request to delete a sale from the system.
    /// </summary>
    public class DeleteVendaRequest
    {
        /// <summary>
        /// Gets or sets the unique identifier of the sale to be deleted.
        /// </summary>
        public Guid IdVenda { get; set; }

        /// <summary>
        /// Gets or sets the sale number. This field is optional for deletion, but can be included for easier reference.
        /// </summary>
        public string NumeroVenda { get; set; } = string.Empty;
    }
}
