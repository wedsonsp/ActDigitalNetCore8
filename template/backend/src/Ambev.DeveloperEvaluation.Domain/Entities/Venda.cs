using System;
using System.Collections.Generic;
using System.Linq;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;

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
        public decimal ValorTotalVendaDesconto { get; set; }

        /// <summary>
        /// Desconto da venda
        /// </summary>
        public decimal DescontoVenda { get; set; }

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

        /// <summary>
        /// Método para calcular o valor total da venda a partir dos itens
        /// </summary>
        public void CalcularValorTotal()
        {
            // Inicializa as variáveis totais
            ValorTotalVenda = 0;
            ValorTotalVendaDesconto = 0;

            // Calculando os valores totais
            foreach (var item in ItensVenda)
            {
                ValorTotalVendaDesconto += item.Quantidade * item.PrecoUnitario;  // Valor total dos produtos (sem desconto)
                ValorTotalVenda += item.ValorTotal;  // Valor total considerando o desconto
            }
        }

        /// <summary>
        /// Inicializa uma nova instância da classe Venda
        /// </summary>
        public Venda()
        {
            // Inicializando as datas de cadastro e venda com a data atual
            DataCadastro = DateTime.UtcNow;
            DataVenda = DateTime.UtcNow;
        }


    }
}
