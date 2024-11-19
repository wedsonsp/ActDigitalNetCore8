namespace Ambev.DeveloperEvaluation.WebApi.Features.Produtos.CreateProduto
{
    /// <summary>
    /// API response model for CreateProduto operation
    /// </summary>
    public class CreateProdutoResponse
    {
        /// <summary>
        /// The unique identifier of the created product
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The name of the product
        /// </summary>
        public string Nome { get; set; } = string.Empty;

        /// <summary>
        /// The description of the product
        /// </summary>
        public string? Descricao { get; set; }

        /// <summary>
        /// The unit price of the product
        /// </summary>
        public decimal PrecoUnitario { get; set; }

    }
}
