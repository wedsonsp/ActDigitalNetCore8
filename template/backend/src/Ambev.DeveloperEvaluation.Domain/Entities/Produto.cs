using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;
using System;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Representa um produto no sistema, incluindo validação de regras de negócios.
    /// </summary>
    public class Produto : BaseEntity
    {
        /// <summary>
        /// Identificador único do produto.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Nome do produto.
        /// Não pode ser nulo ou vazio.
        /// </summary>
        public string Nome { get; set; } = string.Empty;

        /// <summary>
        /// Descrição do produto (opcional).
        /// </summary>
        public string? Descricao { get; set; }

        /// <summary>
        /// Preço unitário do produto.
        /// Deve ser um número com até duas casas decimais.
        /// </summary>
        public decimal PrecoUnitario { get; set; }

        /// <summary>
        /// Data de criação do produto.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Data da última atualização do produto.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Construtor que inicializa a data de criação do produto.
        /// </summary>
        public Produto()
        {
            CreatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Realiza a validação do produto de acordo com as regras de negócio.
        /// </summary>
        /// <returns>
        /// Um objeto de <see cref="ValidationResultDetail"/> contendo:
        /// - IsValid: Indica se o produto é válido conforme as regras de validação.
        /// - Errors: Lista de erros, caso existam falhas de validação.
        /// </returns>
        public ValidationResultDetail Validate()
        {
            var validator = new ProdutoValidator(); // Você precisaria de um validador específico para Produto.
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o) // Converter erros para o formato desejado.
            };
        }
    }
}
