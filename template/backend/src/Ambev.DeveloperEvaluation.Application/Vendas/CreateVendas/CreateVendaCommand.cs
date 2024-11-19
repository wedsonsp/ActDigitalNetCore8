using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Enums;
using MediatR;
using System;

namespace Ambev.DeveloperEvaluation.Application.Vendas.CreateVenda
{
    /// <summary>
    /// Command for creating a new sale (venda).
    /// </summary>
    /// <remarks>
    /// This command captures the necessary data for creating a sale, including:
    /// - Sale number
    /// - Client ID
    /// - Branch ID (Filial)
    /// - Total sale value
    /// - Total product value
    /// - Sale status
    ///
    /// It implements <see cref="IRequest{TResponse}"/> to initiate a request that returns a <see cref="CreateVendaResult"/>.
    /// 
    /// Validation of the provided data is done using <see cref="CreateVendaCommandValidator"/>
    /// to ensure the fields are correctly populated and meet the required rules.
    /// </remarks>
    public class CreateVendaCommand : IRequest<CreateVendaResult>
    {
        /// <summary>
        /// Gets or sets the sale number (NumeroVenda).
        /// </summary>
        public string NumeroVenda { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the client ID (IdCliente).
        /// </summary>
        public Guid IdCliente { get; set; }

        /// <summary>
        /// Gets or sets the client name (NomeCliente).
        /// </summary>
        public string NomeCliente { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the branch ID (IdFilial).
        /// </summary>
        public Guid IdFilial { get; set; }

        /// <summary>
        /// Gets or sets the branch name (NomeFilial).
        /// </summary>
        public string NomeFilial { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the total value of the sale (ValorTotalVenda).
        /// </summary>
        public decimal ValorTotalVenda { get; set; }

        /// <summary>
        /// Gets or sets the total value of products in the sale (ValorTotalProdutos).
        /// </summary>
        public decimal ValorTotalProdutos { get; set; }

        /// <summary>
        /// Gets or sets the status of the sale (Status).
        /// </summary>
        public string Status { get; set; } = "Não cancelada";

        /// <summary>
        /// Gets or sets the date and time of the sale (DataVenda).
        /// </summary>
        public DateTime DataVenda { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Gets or sets the registration date and time of the sale (DataCadastro).
        /// </summary>
        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Gets or sets the date and time of the last update of the sale (DataAlteracao).
        /// </summary>
        public DateTime? DataAlteracao { get; set; }

        /// <summary>
        /// Validates the CreateVendaCommand.
        /// </summary>
        /// <returns>ValidationResultDetail that contains the validation result and errors (if any).</returns>
        public ValidationResultDetail Validate()
        {
            var validator = new CreateVendaCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
