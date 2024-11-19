using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Produtos.CreateProduto
{
    /// <summary>
    /// Command para criar um novo produto.
    /// </summary>
    /// <remarks>
    /// Este comando captura os dados necessários para a criação de um produto, 
    /// incluindo nome, descrição, preço unitário, etc.
    /// Ele implementa <see cref="IRequest{TResponse}"/> para iniciar a solicitação 
    /// que retorna um <see cref="CreateProdutoResult"/>.
    /// 
    /// Os dados fornecidos neste comando são validados usando o 
    /// <see cref="CreateProdutoCommandValidator"/> que estende 
    /// <see cref="AbstractValidator{T}"/> para garantir que os campos sejam corretamente 
    /// preenchidos e sigam as regras necessárias.
    /// </remarks>
    public class CreateProdutoCommand : IRequest<CreateProdutoResult>
    {
        /// <summary>
        /// Nome do produto a ser criado.
        /// </summary>
        public string Nome { get; set; } = string.Empty;

        /// <summary>
        /// Descrição do produto (opcional).
        /// </summary>
        public string? Descricao { get; set; }

        /// <summary>
        /// Preço unitário do produto.
        /// </summary>
        public decimal PrecoUnitario { get; set; }

        /// <summary>
        /// Data de criação do produto (geralmente é atribuída automaticamente no backend).
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Valida os dados do comando de criação de produto.
        /// </summary>
        public ValidationResultDetail Validate()
        {
            var validator = new CreateProdutoCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
