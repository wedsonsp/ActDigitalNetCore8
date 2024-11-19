using Ambev.DeveloperEvaluation.Domain.Common;
using System;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Represents a branch (Filial) where sales are conducted.
    /// </summary>
    public class Filial : BaseEntity
    {
        /// <summary>
        /// Gets or sets the branch name.
        /// </summary>
        public string Nome { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the branch address.
        /// </summary>
        public string? Endereco { get; set; }

        /// <summary>
        /// Gets or sets the city of the branch.
        /// </summary>
        public string? Cidade { get; set; }

        /// <summary>
        /// Gets or sets the state of the branch.
        /// </summary>
        public string? Estado { get; set; }

        /// <summary>
        /// Initializes a new instance of the Filial class.
        /// </summary>
        public Filial()
        {
            Id = Guid.NewGuid();
        }
    }
}
