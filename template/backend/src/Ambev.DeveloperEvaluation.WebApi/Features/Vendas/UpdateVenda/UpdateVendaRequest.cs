using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.WebApi.Features.ItemVendas.CreateItemVenda;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Vendas.UpdateVenda
{
    /// <summary>
    /// Represents a request to update an existing sale in the system.
    /// </summary>
    public class UpdateVendaRequest
    {
        /// <summary>
        /// Gets or sets the unique identifier of the sale to be updated.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the sale number. This field is optional for update.
        /// </summary>
        //public string? NumeroVenda { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the unique identifier of the branch (Filial) for the sale.
        /// </summary>
        //public Guid? IdFilial { get; set; }

        /// <summary>
        /// Gets or sets the name of the branch (Filial). This is an optional field for easier querying.
        /// </summary>
        //public string? NomeFilial { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the unique identifier of the product for the sale.
        /// </summary>
        //public Guid? IdProduto { get; set; }

        /// <summary>
        /// Gets or sets the name of the product. This is an optional field for easier querying.
        /// </summary>
        //public string? NomeProduto { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the unique identifier of the client for the sale.
        /// </summary>
        //public Guid? IdCliente { get; set; }

        /// <summary>
        /// Gets or sets the name of the client. This is an optional field for easier querying.
        /// </summary>
        //public string? NomeCliente { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the total value of the sale. This field is optional for update.
        /// </summary>
        //public decimal? ValorTotalVenda { get; set; }

        /// <summary>
        /// Gets or sets the total value of the products (without discounts). This field is optional for update.
        /// </summary>
        //public decimal? ValorTotalVendaDesconto { get; set; }

        /// <summary>
        /// Gets or sets the status of the sale (e.g., "Not Cancelled" or "Cancelled").
        /// </summary>
        public string? Status { get; set; } = "Não cancelada";

        /// <summary>
        /// Gets or sets the list of sale items for the update.
        /// </summary>
        //public List<CreateItemVendaRequest> ItensVenda { get; set; } = new List<CreateItemVendaRequest>();

        /// <summary>
        /// Gets or sets the sale update date (optional).
        /// </summary>
        public DateTime? DataAlteracao { get; set; }

        /// <summary>
        /// Gets or sets the date when the sale was created (optional).
        /// </summary>
        public DateTime? DataCadastro { get; set; }
    }

    // Define the structure for sale items used in the update request
    public class ItemVendaRequest
    {
        public Guid IdVenda { get; set; }
        public Guid IdProduto { get; set; }
        public string NomeProduto { get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal Desconto { get; set; }
        public int Status { get; set; }
    }
}
