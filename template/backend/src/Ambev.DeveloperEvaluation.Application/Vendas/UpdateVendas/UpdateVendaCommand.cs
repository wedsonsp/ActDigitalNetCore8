using Ambev.DeveloperEvaluation.Application.ItemVendas.UpdateItemVenda;
using Ambev.DeveloperEvaluation.Application.Vendas.UpdateVendas;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.Application.Vendas.UpdateVenda
{
    /// <summary>
    /// Command for updating an existing sale.
    /// </summary>
    /// <remarks>
    /// This command captures the necessary data for updating a sale, 
    /// including sale number, client ID, branch ID, total sale value, 
    /// sale status, etc.
    /// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
    /// that returns a <see cref="UpdateVendaResult"/>.
    /// 
    /// The data provided in this command is validated using the 
    /// <see cref="UpdateVendaCommandValidator"/> to ensure that the fields 
    /// are correctly populated and follow the required rules.
    /// </remarks>
    public class UpdateVendaCommand : IRequest<UpdateVendaResult>
    {
        /// <summary>
        /// Gets or sets the unique identifier of the sale to be updated.
        /// </summary>
        public Guid Id { get; set; }

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
        /// Gets or sets the total value of products in the sale (ValorTotalVendaDesconto).
        /// </summary>
        public decimal ValorTotalVendaDesconto { get; set; }

        /// <summary>
        /// Gets or sets the status of the sale (Status).
        /// </summary>
        public string Status { get; set; } = "Não cancelada";

        /// <summary>
        /// Gets or sets the sale date (DataVenda).
        /// </summary>
        public DateTime DataVenda { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Gets or sets the registration date of the sale (DataCadastro).
        /// </summary>
        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Gets or sets the last update date of the sale (DataAlteracao).
        /// </summary>
        public DateTime? DataAlteracao { get; set; }

        /// <summary>
        /// Gets or sets the list of items in the sale to be updated.
        /// </summary>
        public List<UpdateItemVendaCommand> ItensVenda { get; set; } = new List<UpdateItemVendaCommand>();

        /// <summary>
        /// Validates the UpdateVendaCommand.
        /// </summary>
        /// <returns>ValidationResultDetail that contains the validation result and errors (if any).</returns>
        public ValidationResultDetail Validate()
        {
            var validator = new UpdateVendaCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
