using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface IVendaRepository
    {
        /// <summary>
        /// Cria uma nova venda.
        /// </summary>
        Task<Venda> CreateAsync(Venda venda, CancellationToken cancellationToken = default);

        /// <summary>
        /// Obtém uma venda pelo ID.
        /// </summary>
        Task<Venda?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deleta uma venda pelo ID.
        /// </summary>
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
