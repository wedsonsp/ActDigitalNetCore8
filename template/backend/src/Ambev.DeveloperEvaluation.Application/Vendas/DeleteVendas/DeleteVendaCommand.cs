using MediatR;
using System;

namespace Ambev.DeveloperEvaluation.Application.Vendas.DeleteVenda
{
    /// <summary>
    /// Command for deleting a sale.
    /// </summary>
    public class DeleteVendaCommand : IRequest<DeleteVendaResult>
    {
        /// <summary>
        /// Gets or sets the unique identifier for the sale to be deleted.
        /// </summary>
        public Guid Id { get; set; }
    }
}
