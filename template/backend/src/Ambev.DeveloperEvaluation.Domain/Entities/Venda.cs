using Ambev.DeveloperEvaluation.Domain.Common;
using System;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Representa uma venda realizada no sistema.
    /// </summary>
    public class Venda : BaseEntity
    {
        /// <summary>
        /// Número único da venda.
        /// </summary>
        public string NumeroVenda { get; set; } = string.Empty;

        /// <summary>
        /// Data e hora da venda.
        /// </summary>
        public DateTime DataVenda { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Referência ao cliente que realizou a compra.
        /// </summary>
        public Guid IdCliente { get; set; }

        /// <summary>
        /// Referência à filial onde a venda foi realizada.
        /// </summary>
        public Guid IdFilial { get; set; }

        /// <summary>
        /// Valor total da venda.
        /// </summary>
        public decimal TotalVenda { get; set; }

        /// <summary>
        /// Status da venda (se foi cancelada ou não).
        /// </summary>
        public string Status { get; set; } = "Não cancelado";

        /// <summary>
        /// Cliente que realizou a venda.
        /// </summary>
        public Cliente Cliente { get; set; }

        /// <summary>
        /// Filial onde a venda foi realizada.
        /// </summary>
        public Filial Filial { get; set; }
    }
}
