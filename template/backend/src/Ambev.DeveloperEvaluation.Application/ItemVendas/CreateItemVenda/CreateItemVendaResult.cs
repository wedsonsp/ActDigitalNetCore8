namespace Ambev.DeveloperEvaluation.Application.ItemVendas.CreateItemVenda
{
    /// <summary>
    /// Resultado da criação do item de venda
    /// </summary>
    public class CreateItemVendaResult
    {
        /// <summary>
        /// Identificador único do item de venda criado
        /// </summary>
        public Guid IdProduto { get; set; }

        public Guid IdVenda { get; set; }

        /// <summary>
        /// Nome do produto no item de venda
        /// </summary>
        public string NomeProduto { get; set; } = string.Empty;

        /// <summary>
        /// Quantidade do produto no item de venda
        /// </summary>
        public int Quantidade { get; set; }

        /// <summary>
        /// Preço unitário do produto no item de venda
        /// </summary>
        public decimal PrecoUnitario { get; set; }

        public decimal ValorTotal { get; set; }
    }
}
