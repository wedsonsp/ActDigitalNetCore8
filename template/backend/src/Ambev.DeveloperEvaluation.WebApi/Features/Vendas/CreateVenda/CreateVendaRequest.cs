using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.WebApi.Features.ItemVendas.CreateItemVenda;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Vendas.CreateVenda
{
    /// <summary>
    /// Represents a request to create a new sale in the system.
    /// </summary>
    public class CreateVendaRequest
    {

        /// <summary>
        /// Gets or sets the sale number. This field is required.
        /// </summary>
        public string NumeroVenda { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the unique identifier of the branch (Filial) for the sale.
        /// </summary>
        public Guid IdFilial { get; set; }

        /// <summary>
        /// Gets or sets the name of the branch (Filial). This is an additional field for easier querying.
        /// </summary>
        public string NomeFilial { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets the unique identifier of the client for the sale.
        /// </summary>
        public Guid IdProduto { get; set; }

        /// <summary>
        /// Gets or sets the name of the client. This is an additional field for easier querying.
        /// </summary>
        public string NomeProduto { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets the unique identifier of the client for the sale.
        /// </summary>
        public Guid IdCliente { get; set; }

        /// <summary>
        /// Gets or sets the name of the client. This is an additional field for easier querying.
        /// </summary>
        public string NomeCliente { get; set; } = string.Empty;

     

        /// <summary>
        /// Gets or sets the total value of the sale.
        /// </summary>
        //public decimal ValorTotalVenda { get; set; }

        /// <summary>
        /// Gets or sets the total value of the products (without discounts).
        /// </summary>
        //public decimal ValorTotalProdutos { get; set; }

        /// <summary>
        /// Gets or sets the status of the sale (e.g., "Not Cancelled" or "Cancelled").
        /// </summary>
        public string Status { get; set; } = "Não cancelada";

        /// <summary>
        /// Gets or sets the list of sale items represented in JSON format.
        /// </summary>
        // Lista de itens de venda diretamente aqui
        public List<CreateItemVendaRequest> ItensVenda { get; set; } = new List<CreateItemVendaRequest>();

        /// <summary>
        /// Gets or sets the sale creation date (optional).
        /// </summary>
        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Gets or sets the sale update date (optional).
        /// </summary>
        public DateTime? DataAlteracao { get; set; }

        


    }

    public class ItemVenda
    {
        public Guid IdProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
    }

    public class ItemVendaRequest
    {
        public Guid IdVenda { get; set; }
        public Guid IdProduto { get; set; }
        public string NomeProduto { get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal Desconto { get; set; }
        public int Status { get; set; }
    }
}
