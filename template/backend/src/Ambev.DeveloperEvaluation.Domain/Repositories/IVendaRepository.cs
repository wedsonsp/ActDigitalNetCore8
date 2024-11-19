using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    /// <summary>
    /// Repository interface for Venda entity operations
    /// </summary>
    public interface IVendaRepository
    {
        /// <summary>
        /// Creates a new venda in the repository
        /// </summary>
        /// <param name="venda">The venda to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created venda</returns>
        Task<Venda> CreateAsync(Venda venda, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a venda by its unique identifier
        /// </summary>
        /// <param name="id">The unique identifier of the venda</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The venda if found, null otherwise</returns>
        Task<Venda?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves all vendas associated with a specific client
        /// </summary>
        /// <param name="clientId">The unique identifier of the client</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A list of vendas for the client</returns>
        Task<IEnumerable<Venda>> GetByClientIdAsync(Guid clientId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves all vendas associated with a specific filial
        /// </summary>
        /// <param name="filialId">The unique identifier of the filial</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A list of vendas for the filial</returns>
        Task<IEnumerable<Venda>> GetByFilialIdAsync(Guid filialId, CancellationToken cancellationToken = default);

        Task<Venda?> GetByNumeroVendaAsync(string numeroVenda, CancellationToken cancellationToken = default);


        /// <summary>
        /// Retrieves all vendas
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A list of all vendas</returns>
        Task<IEnumerable<Venda>> GetAllAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an existing venda in the repository
        /// </summary>
        /// <param name="venda">The venda with updated information</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The updated venda</returns>
        Task<Venda> UpdateAsync(Venda venda, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a venda from the repository
        /// </summary>
        /// <param name="id">The unique identifier of the venda to delete</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if the venda was deleted, false if not found</returns>
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
