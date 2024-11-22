using Ambev.DeveloperEvaluation.WebApi.Features.ItemVendas.CreateItemVenda;
using System;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Vendas.UpdateVenda
{
    /// <summary>
    /// Represents the response after updating an existing sale.
    /// </summary>
    public class UpdateVendaResponse
    {
        /// <summary>
        /// Gets or sets the unique identifier of the sale.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the sale number (unique identifier for the sale).
        /// </summary>
        public string NumeroVenda { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the unique identifier of the client related to the sale.
        /// </summary>
        public Guid IdCliente { get; set; }

        /// <summary>
        /// Gets or sets the name of the client.
        /// </summary>
        public string NomeCliente { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the unique identifier of the branch (Filial) related to the sale.
        /// </summary>
        public Guid IdFilial { get; set; }

        /// <summary>
        /// Gets or sets the name of the branch (Filial) related to the sale.
        /// </summary>
        public string NomeFilial { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the unique identifier of the product related to the sale.
        /// </summary>
        public Guid IdProduto { get; set; }

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        public string NomeProduto { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the total value of the sale.
        /// </summary>
        public decimal ValorTotalVenda { get; set; }

        /// <summary>
        /// Gets or sets the total value of the products in the sale, excluding discounts.
        /// </summary>
        public decimal ValorTotalVendaDesconto { get; set; }

        /// <summary>
        /// Gets or sets the status of the sale (e.g., 'Não cancelada', 'Cancelada').
        /// </summary>
        public string Status { get; set; } = "Não cancelada";

        /// <summary>
        /// Gets or sets the date when the sale was last updated.
        /// </summary>
        public DateTime? DataAlteracao { get; set; }

        /// <summary>
        /// Gets or sets the list of items in the sale (ItensVenda).
        /// </summary>
        public List<CreateItemVendaResponse> ItensVenda { get; set; } = new List<CreateItemVendaResponse>();
    }
}
