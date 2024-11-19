namespace Ambev.DeveloperEvaluation.Application.Produtos.CreateProduto
{
    public class CreateProdutoResult
    {
        /// <summary>
        /// ID do produto criado.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Nome do produto criado.
        /// </summary>
        public string Nome { get; set; } = string.Empty;

        /// <summary>
        /// Descrição do produto criado.
        /// </summary>
        public string Descricao { get; set; } = string.Empty;

        /// <summary>
        /// Preço unitário do produto criado.
        /// </summary>
        public decimal PrecoUnitario { get; set; }
    }
}
