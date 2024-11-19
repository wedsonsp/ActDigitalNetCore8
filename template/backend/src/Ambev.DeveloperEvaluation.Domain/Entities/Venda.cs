using System;
using System.Collections.Generic;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Representa uma venda no sistema
    /// </summary>
    public class Venda : BaseEntity
    {
        /// <summary>
        /// Número da venda
        /// </summary>
        public string NumeroVenda { get; set; } = string.Empty;

        /// <summary>
        /// Data da venda
        /// </summary>
        public DateTime DataVenda { get; set; }

        /// <summary>
        /// Identificador do cliente associado à venda
        /// </summary>
        public Guid IdCliente { get; set; }

        /// <summary>
        /// Nome do cliente associado à venda
        /// </summary>
        public string NomeCliente { get; set; } = string.Empty;

        /// <summary>
        /// Identificador da filial associada à venda
        /// </summary>
        public Guid IdFilial { get; set; }

        /// <summary>
        /// Nome da filial associada à venda
        /// </summary>
        public string NomeFilial { get; set; } = string.Empty;

        /// <summary>
        /// Valor total da venda
        /// </summary>
        public decimal ValorTotalVenda { get; set; }

        /// <summary>
        /// Valor total dos produtos da venda
        /// </summary>
        public decimal ValorTotalProdutos { get; set; }

        /// <summary>
        /// Status da venda (ex: não cancelada, cancelada)
        /// </summary>
        public string Status { get; set; } = "Não cancelada";

        /// <summary>
        /// Data de cadastro da venda
        /// </summary>
        public DateTime DataCadastro { get; set; }

        /// <summary>
        /// Data de alteração da venda (opcional)
        /// </summary>
        public DateTime? DataAlteracao { get; set; }

        /// <summary>
        /// Relacionamento com a tabela ItensVenda
        /// </summary>
        public ICollection<ItemVenda> ItensVenda { get; set; } = new List<ItemVenda>();

        // Método para calcular o valor total da venda a partir dos itens
        public void CalcularValorTotal()
        {
            ValorTotalVenda = 0;
            ValorTotalProdutos = 0;

            foreach (var item in ItensVenda)
            {
                ValorTotalProdutos += item.ValorTotal;
                ValorTotalVenda += item.ValorTotal;
            }
        }

        /// <summary>
        /// Inicializa uma nova instância da classe Venda
        /// </summary>
        public Venda()
        {
            DataCadastro = DateTime.UtcNow;
            DataVenda = DateTime.UtcNow;
        }
    }
}
