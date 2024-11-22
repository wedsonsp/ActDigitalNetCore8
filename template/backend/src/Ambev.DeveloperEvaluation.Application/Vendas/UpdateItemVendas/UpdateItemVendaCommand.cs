using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;
using System;

namespace Ambev.DeveloperEvaluation.Application.ItemVendas.UpdateItemVenda
{
    /// <summary>
    /// Command for updating an existing item of a sale (ItemVenda).
    /// </summary>
    /// <remarks>
    /// This command captures the necessary data for updating an item in a sale,
    /// including product ID, quantity, unit price, discount, and total value.
    /// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
    /// that returns a <see cref="UpdateItemVendaResult"/>.
    /// 
    /// The data provided in this command is validated using the 
    /// <see cref="UpdateItemVendaCommandValidator"/> to ensure that the fields 
    /// are correctly populated and follow the required rules.
    /// </remarks>
    public class UpdateItemVendaCommand : IRequest<UpdateItemVendaResult>
    {
        /// <summary>
        /// Gets or sets the unique identifier of the item to be updated.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the product ID associated with the item.
        /// </summary>
        public Guid IdProduto { get; set; }

        /// <summary>
        /// Gets or sets the product name.
        /// </summary>
        public string NomeProduto { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the quantity of the product.
        /// </summary>
        public int Quantidade { get; set; }

        /// <summary>
        /// Gets or sets the unit price of the product.
        /// </summary>
        public decimal PrecoUnitario { get; set; }

        /// <summary>
        /// Gets or sets the discount applied to the item.
        /// </summary>
        public decimal Desconto { get; set; }

        /// <summary>
        /// Gets or sets the total value of the item (Quantidade * PreçoUnitario - Desconto).
        /// </summary>
        public decimal ValorTotal { get; set; }

        /// <summary>
        /// Validates the UpdateItemVendaCommand.
        /// </summary>
        /// <returns>ValidationResultDetail that contains the validation result and errors (if any).</returns>
        public ValidationResultDetail Validate()
        {
            var validator = new UpdateItemVendaCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
