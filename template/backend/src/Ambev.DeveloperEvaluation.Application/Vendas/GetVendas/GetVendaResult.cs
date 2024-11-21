using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Vendas.GetVenda
{
    /// <summary>
    /// Response model for GetVenda operation
    /// </summary>
    public class GetVendaResult
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
        /// The discount applied to the sale (if any)
        /// </summary>
        public decimal DescontoVenda { get; set; }

        /// <summary>
        /// The sale status (e.g., completed, pending)
        /// </summary>
        public VendaStatus Status { get; set; }

        /// <summary>
        /// The date when the sale was created
        /// </summary>
        public DateTime DataCadastro { get; set; }

        /// <summary>
        /// The user who made the sale (if applicable)
        /// </summary>
        public decimal ValorTotalVendaDesconto { get; set; }
        

        /// <summary>
        /// The list of items in the sale (could be a collection of item IDs, names, etc.)
        /// </summary>
        public List<SaleItem> ItensVenda { get; set; } = new List<SaleItem>();
    }

    /// <summary>
    /// Represents an item in the sale
    /// </summary>
    public class SaleItem
    {
        /// <summary>
        /// The unique identifier of the item in the sale
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

        public decimal ValorTotalVendaDesconto { get; set; }
        

        /// <summary>
        /// The total value of this item in the sale
        /// </summary>
        public decimal ValorTotal { get; set; }
    }
}
