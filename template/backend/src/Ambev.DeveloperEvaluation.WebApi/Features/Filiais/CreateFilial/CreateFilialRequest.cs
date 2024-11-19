using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Filiais.CreateFilial
{
    /// <summary>
    /// Represents a request to create a new filial (branch) in the system.
    /// </summary>
    public class CreateFilialRequest
    {
        /// <summary>
        /// Gets or sets the name of the filial. Must be unique and contain only valid characters.
        /// </summary>
        public string Nome { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the address of the filial.
        /// </summary>
        public string Endereco { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the phone number of the filial. The format could be like (XX) XXXXX-XXXX.
        /// </summary>
        public string Telefone { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the email address of the filial.
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the status of the filial.
        /// </summary>
        public FilialStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the city where the filial is located.
        /// </summary>
        public string Cidade { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the state (UF) where the filial is located.
        /// </summary>
        public string Estado { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the postal code (CEP) of the filial's location.
        /// </summary>
        public string Cep { get; set; } = string.Empty;
    }
}
