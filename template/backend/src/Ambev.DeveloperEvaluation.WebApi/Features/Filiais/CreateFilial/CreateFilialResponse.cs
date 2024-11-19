using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Filiais.CreateFilial
{
    /// <summary>
    /// API response model for CreateFilial operation
    /// </summary>
    public class CreateFilialResponse
    {
        /// <summary>
        /// The unique identifier of the created filial
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The name of the filial
        /// </summary>
        public string Nome { get; set; } = string.Empty;

        /// <summary>
        /// The address of the filial
        /// </summary>
        public string Endereco { get; set; } = string.Empty;

        /// <summary>
        /// The phone number of the filial
        /// </summary>
        public string Telefone { get; set; } = string.Empty;

        /// <summary>
        /// The email address of the filial
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// The current status of the filial
        /// </summary>
        public FilialStatus Status { get; set; }

        /// <summary>
        /// The city where the filial is located
        /// </summary>
        public string Cidade { get; set; } = string.Empty;

        /// <summary>
        /// The state (UF) where the filial is located
        /// </summary>
        public string Estado { get; set; } = string.Empty;

        /// <summary>
        /// The postal code (CEP) of the filial's location
        /// </summary>
        public string Cep { get; set; } = string.Empty;
    }
}
