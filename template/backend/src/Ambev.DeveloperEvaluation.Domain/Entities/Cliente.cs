using System;
using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Represents a customer in the system.
    /// This entity follows domain-driven design principles and includes business rules validation.
    /// </summary>
    /// public class User : BaseEntity, IUser
    public class Cliente : BaseEntity, ICliente
    {

        /// <summary>
        /// Gets the unique identifier of the user.
        /// </summary>
        /// <returns>The user's ID as a string.</returns>
        string ICliente.Id => Id.ToString();

        /// <summary>
        /// Gets or sets the customer's full name.
        /// Must not be null or empty.
        /// </summary>
        public string Nome { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the customer's email address.
        /// It can be null or empty.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets the customer's phone number.
        /// It can be null or empty.
        /// </summary>
        public string? Telefone { get; set; }

        /// <summary>
        /// Gets the date and time when the customer was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets the date and time of the last update to the customer's information.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Initializes a new instance of the Cliente class.
        /// </summary>
        public Cliente()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Performs validation of the Cliente entity using the ClienteValidator rules.
        /// </summary>
        /// <returns>A ValidationResultDetail containing:</returns>
        public ValidationResultDetail Validate()
        {
            var validator = new ClienteValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }

        /// <summary>
        /// Updates the customer's contact information (Email, Telefone).
        /// </summary>
        /// <param name="email">The new email.</param>
        /// <param name="telefone">The new phone number.</param>
        public void UpdateContactInfo(string? email, string? telefone)
        {
            Email = email;
            Telefone = telefone;
            UpdatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Deactivates the customer by setting a flag or status.
        /// </summary>
        public void Deactivate()
        {
            // Business logic for deactivating a client, if needed.
            UpdatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Gets the user's current status.
        /// Indicates whether the user is active, inactive, or blocked in the system.
        /// </summary>
        public ClienteStatus Status { get; set; }
    }
}
