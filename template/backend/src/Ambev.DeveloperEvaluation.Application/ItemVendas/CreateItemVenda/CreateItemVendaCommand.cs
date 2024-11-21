using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.ItemVendas.CreateItemVenda
{
    /// <summary>
    /// Command para criar um novo item de venda.
    /// </summary>
    /// <remarks>
    /// Este comando captura os dados necessários para a criação de um item de venda, 
    /// incluindo o identificador do produto, a quantidade, o preço unitário, etc.
    /// Ele implementa <see cref="IRequest{TResponse}"/> para iniciar a solicitação 
    /// que retorna um <see cref="CreateItemVendaResult"/>.
    /// 
    /// Os dados fornecidos neste comando são validados usando o 
    /// <see cref="CreateItemVendaCommandValidator"/> que estende 
    /// <see cref="AbstractValidator{T}"/> para garantir que os campos sejam corretamente 
    /// preenchidos e sigam as regras necessárias.
    /// </remarks>
    public class CreateItemVendaCommand : IRequest<CreateItemVendaResult>
    {
        /// <summary>
        /// Identificador do produto associado ao item de venda.
        /// </summary>
        public Guid IdProduto { get; set; }

        /// <summary>
        /// Nome do produto
        /// </summary>
        public string NomeProduto { get; set; } = string.Empty;

        /// <summary>
        /// Quantidade do produto no item de venda.
        /// </summary>
        public int Quantidade { get; set; }

        /// <summary>
        /// Preço unitário do produto no item de venda.
        /// </summary>
        public decimal PrecoUnitario { get; set; }

        /// <summary>
        /// Preço desconto do produto no item de venda.
        /// </summary>
        public decimal Desconto { get; set; }

        public decimal ValorTotal { get; set; }

        /// <summary>
        /// Identificador da venda à qual o item pertence.
        /// </summary>
        public Guid IdVenda { get; set; }

        /// <summary>
        /// Valida os dados do comando de criação de item de venda.
        /// </summary>
        public ValidationResultDetail Validate()
        {
            var validator = new CreateItemVendaCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
