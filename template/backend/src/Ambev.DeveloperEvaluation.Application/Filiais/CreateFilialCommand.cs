using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Filiais.CreateFilial
{
    /// <summary>
    /// Command for creating a new filial.
    /// </summary>
    /// <remarks>
    /// This command is used to capture the required data for creating a filial, 
    /// including the name, address, city, and state. 
    /// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
    /// that returns a <see cref="CreateFilialResult"/>.
    /// 
    /// The data provided in this command will be validated using a validator 
    /// class (e.g., <see cref="CreateFilialCommandValidator"/>).
    /// </remarks>
    public class CreateFilialCommand : IRequest<CreateFilialResult>
    {
        /// <summary>
        /// Gets or sets the name of the filial to be created.
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
        /// Gets or sets the city where the filial is located.
        /// </summary>
        public string Cidade { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the state where the filial is located.
        /// </summary>
        public string Estado { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the postal code (CEP) of the filial's location.
        /// </summary>
        public string Cep { get; set; } = string.Empty;

        /// <summary>
        /// Performs validation for the CreateFilialCommand.
        /// </summary>
        public ValidationResultDetail Validate()
        {
            var validator = new CreateFilialCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
