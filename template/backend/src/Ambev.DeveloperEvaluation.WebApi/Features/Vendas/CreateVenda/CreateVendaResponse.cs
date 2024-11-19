using System;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Vendas.CreateVenda
{
    /// <summary>
    /// Represents the response after creating a new sale.
    /// </summary>
    public class CreateVendaResponse
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
        /// Gets or sets the total value of the sale.
        /// </summary>
        public decimal ValorTotalVenda { get; set; }

        /// <summary>
        /// Gets or sets the total value of the products in the sale, excluding discounts.
        /// </summary>
        public decimal ValorTotalProdutos { get; set; }

        /// <summary>
        /// Gets or sets the status of the sale (e.g., 'Não cancelada', 'Cancelada').
        /// </summary>
        public string Status { get; set; } = "Não cancelada";

        /// <summary>
        /// Gets or sets the date when the sale was created.
        /// </summary>
        public DateTime DataCadastro { get; set; }

        /// <summary>
        /// Gets or sets the date when the sale was last updated (can be null).
        /// </summary>
        public DateTime? DataAlteracao { get; set; }

        /// <summary>
        /// Gets or sets the items involved in the sale, represented as a JSON string.
        /// </summary>
        public string ItensVenda { get; set; } = string.Empty;
    }
}
