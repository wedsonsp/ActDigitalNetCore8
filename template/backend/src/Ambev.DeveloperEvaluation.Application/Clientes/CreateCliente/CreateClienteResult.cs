using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Clientes.CreateCliente
{
    public class CreateClienteResult
    {
        /// <summary>
        /// Gets or sets the unique identifier of the newly created cliente.
        /// </summary>
        /// <value>A GUID that uniquely identifies the created cliente in the system.</value>
        public Guid Id { get; set; }
    }
}
