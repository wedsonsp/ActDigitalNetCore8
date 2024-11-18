using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    /// <summary>
    /// Implementation of IClienteRepository using Entity Framework Core
    /// </summary>
    public class ClienteRepository : IClienteRepository
    {
        private readonly DefaultContext _context;

        /// <summary>
        /// Initializes a new instance of ClienteRepository
        /// </summary>
        /// <param name="context">The database context</param>
        public ClienteRepository(DefaultContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new client in the database
        /// </summary>
        /// <param name="cliente">The client to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created client</returns>
        public async Task<Cliente> CreateAsync(Cliente cliente, CancellationToken cancellationToken = default)
        {
            await _context.Clientes.AddAsync(cliente, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return cliente;
        }

        /// <summary>
        /// Retrieves a client by their unique identifier
        /// </summary>
        /// <param name="id">The unique identifier of the client</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The client if found, null otherwise</returns>
        public async Task<Cliente?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Clientes
                .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
        }

        /// <summary>
        /// Retrieves a client by their email address
        /// </summary>
        /// <param name="email">The email address to search for</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The client if found, null otherwise</returns>
        public async Task<Cliente?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            return await _context.Clientes
                .FirstOrDefaultAsync(c => c.Email == email, cancellationToken);
        }

        /// <summary>
        /// Deletes a client from the database
        /// </summary>
        /// <param name="id">The unique identifier of the client to delete</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if the client was deleted, false if not found</returns>
        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var cliente = await GetByIdAsync(id, cancellationToken);
            if (cliente == null)
                return false;

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
