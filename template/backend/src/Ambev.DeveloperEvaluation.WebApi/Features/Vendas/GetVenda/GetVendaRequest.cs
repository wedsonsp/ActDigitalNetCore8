namespace Ambev.DeveloperEvaluation.WebApi.Features.Vendas.GetVenda
{
    /// <summary>
    /// Request model for getting a sale by ID
    /// </summary>
    public class GetVendaRequest
    {
        /// <summary>
        /// The unique identifier of the sale to retrieve
        /// </summary>
        public Guid Id { get; set; }
    }
}
