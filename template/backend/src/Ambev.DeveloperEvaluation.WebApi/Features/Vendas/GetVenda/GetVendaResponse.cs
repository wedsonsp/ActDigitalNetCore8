using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Vendas.GetVenda
{
    /// <summary>
    /// API response model for GetVenda operation
    /// </summary>
    public class GetVendaResponse
    {
        /// <summary>
        /// The unique identifier of the sale
        /// </summary>
        public Guid Id { get; set; }

        public string NomeCliente { get; set; } = string.Empty;

        /// <summary>
        /// The total value of the sale
        /// </summary>
        public decimal ValorTotalVenda { get; set; }

        /// <summary>
        /// The date and time when the sale was created
        /// </summary>
        public DateTime DataCadastro { get; set; }

        /// <summary>
        /// The status of the sale (e.g., completed, pending, canceled)
        /// </summary>
        public string Status { get; set; } = string.Empty;

        public decimal DescontoVenda { get; set; }

        public decimal ValorTotalVendaDesconto { get; set; }

        /// <summary>
        /// The list of sale items in the sale
        /// </summary>
        public List<GetVendaItemResponse> ItensVenda { get; set; } = new List<GetVendaItemResponse>();
    }

    /// <summary>
    /// Model for each item in the sale
    /// </summary>
    public class GetVendaItemResponse
    {
        /// <summary>
        /// The unique identifier of the product in the sale
        /// </summary>
        public Guid IdProduto { get; set; }

        /// <summary>
        /// The name of the product
        /// </summary>
        public string NomeProduto { get; set; } = string.Empty;

        /// <summary>
        /// The quantity of the product in the sale
        /// </summary>
        public int Quantidade { get; set; }

        /// <summary>
        /// The unit price of the product
        /// </summary>
        public decimal PrecoUnitario { get; set; }

        /// <summary>
        /// The discount applied to the product
        /// </summary>
        public decimal DescontoVenda { get; set; }

        /// <summary>
        /// The total value of this item (Quantidade * PrecoUnitario - Desconto)
        /// </summary>
        public decimal ValorTotal { get; set; }
    }
}
