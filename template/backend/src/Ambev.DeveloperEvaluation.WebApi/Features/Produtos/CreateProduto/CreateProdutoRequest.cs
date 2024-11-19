namespace Ambev.DeveloperEvaluation.WebApi.Features.Produtos.CreateProduto
{
    /// <summary>
    /// Represents a request to create a new product in the system.
    /// </summary>
    public class CreateProdutoRequest
    {
        /// <summary>
        /// Gets or sets the name of the product. Must be unique and between 3 and 255 characters long.
        /// </summary>
        public string Nome { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the description of the product. This is optional.
        /// </summary>
        public string? Descricao { get; set; }

        /// <summary>
        /// Gets or sets the unit price of the product. Must be a positive value.
        /// </summary>
        public decimal PrecoUnitario { get; set; }

    }
}
