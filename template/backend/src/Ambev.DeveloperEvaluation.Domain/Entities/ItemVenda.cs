using System;
using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Representa um item de venda no sistema
    /// </summary>
    public class ItemVenda : BaseEntity
    {
        /// <summary>
        /// Identificador da venda associada ao item
        /// </summary>
        public Guid IdVenda { get; set; }

        /// <summary>
        /// Identificador do produto associado ao item
        /// </summary>
        public Guid IdProduto { get; set; }

        /// <summary>
        /// Nome do produto
        /// </summary>
        public string NomeProduto { get; set; } = string.Empty;

        /// <summary>
        /// Quantidade do produto
        /// </summary>
        public int Quantidade { get; set; }

        /// <summary>
        /// Preço unitário do produto
        /// </summary>
        public decimal PrecoUnitario { get; set; }

        /// <summary>
        /// Desconto aplicado ao item
        /// </summary>
        public decimal Desconto { get; set; }

        /// <summary>
        /// Valor total do item (Quantidade * PreçoUnitario - Desconto)
        /// </summary>
        public decimal ValorTotal { get; set; }

        /// <summary>
        /// Navegação para a venda associada
        /// </summary>
        public Venda Venda { get; set; } = null!;

        /// <summary>
        /// Inicializa uma nova instância de ItemVenda
        /// </summary>
        public ItemVenda()
        {
        }
    }
}
