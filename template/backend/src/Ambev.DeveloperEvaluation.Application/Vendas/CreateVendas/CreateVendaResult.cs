using Ambev.DeveloperEvaluation.Application.ItemVendas.CreateItemVenda;

namespace Ambev.DeveloperEvaluation.Application.Vendas.CreateVenda
{
    /// <summary>
    /// Represents the response returned after successfully creating a new sale (venda).
    /// </summary>
    /// <remarks>
    /// This response contains the unique identifier of the newly created sale,
    /// as well as other relevant details such as the sale's number and status.
    /// </remarks>
    public class CreateVendaResult
    {
        /// <summary>
        /// Gets or sets the unique identifier of the newly created sale.
        /// </summary>
        /// <value>A GUID that uniquely identifies the created sale (venda) in the system.</value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the sale number.
        /// </summary>
        /// <value>The unique number assigned to the sale (venda).</value>
        public string NumeroVenda { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the total value of the sale (venda).
        /// </summary>
        /// <value>The total value of the sale, calculated from its items.</value>
        public decimal ValorTotalVenda { get; set; }

        /// <summary>
        /// Gets or sets the total value of the products in the sale (venda).
        /// </summary>
        /// <value>The total value of the products, excluding any additional fees or discounts.</value>
        public decimal ValorTotalVendaDesconto { get; set; }

        /// <summary>
        /// Gets or sets the status of the sale (venda).
        /// </summary>
        /// <value>The current status of the sale (e.g., "Completed", "Cancelled").</value>
        public string Status { get; set; } = "Não cancelada";

        /// <summary>
        /// Gets or sets the sale date.
        /// </summary>
        /// <value>The date and time when the sale (venda) was made.</value>
        public DateTime DataVenda { get; set; }

        /// <summary>
        /// Gets or sets the creation date of the sale.
        /// </summary>
        /// <value>The date and time when the sale (venda) was registered in the system.</value>
        public DateTime DataCadastro { get; set; }

        /// <summary>
        /// Gets or sets the last modification date of the sale.
        /// </summary>
        /// <value>The date and time when the sale (venda) was last updated, or null if never modified.</value>
        public DateTime? DataAlteracao { get; set; }

        // Ajustando para ser uma lista de objetos CreateItemVendaResult em vez de string
        public List<CreateItemVendaResult> ItensVenda { get; set; } = new List<CreateItemVendaResult>();
    }
}
