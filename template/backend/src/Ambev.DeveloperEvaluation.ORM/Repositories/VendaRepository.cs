using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    /// <summary>
    /// Implementation of IVendaRepository using Entity Framework Core
    /// </summary>
    public class VendaRepository : IVendaRepository
    {
        private readonly DefaultContext _context;

        /// <summary>
        /// Initializes a new instance of VendaRepository
        /// </summary>
        /// <param name="context">The database context</param>
        public VendaRepository(DefaultContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new venda in the database
        /// </summary>
        /// <param name="venda">The venda to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created venda</returns>
        public async Task<Venda> CreateAsync(Venda venda, CancellationToken cancellationToken = default)
        {
            await _context.Vendas.AddAsync(venda, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return venda;
        }

        /// <summary>
        /// Retrieves a venda by its unique identifier
        /// </summary>
        /// <param name="id">The unique identifier of the venda</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The venda if found, null otherwise</returns>
        public async Task<Venda?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Vendas
                .Include(v => v.ItensVenda)  // Assuming ItensVenda is a related entity
                .FirstOrDefaultAsync(v => v.Id == id, cancellationToken);
        }

        /// <summary>
        /// Retrieves all vendas associated with a specific client
        /// </summary>
        /// <param name="clientId">The unique identifier of the client</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A list of vendas for the client</returns>
        public async Task<IEnumerable<Venda>> GetByClientIdAsync(Guid clientId, CancellationToken cancellationToken = default)
        {
            return await _context.Vendas
                .Where(v => v.IdCliente == clientId)
                .Include(v => v.ItensVenda)  // Assuming ItensVenda is a related entity
                .ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Retrieves all vendas associated with a specific filial
        /// </summary>
        /// <param name="filialId">The unique identifier of the filial</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A list of vendas for the filial</returns>
        public async Task<IEnumerable<Venda>> GetByFilialIdAsync(Guid filialId, CancellationToken cancellationToken = default)
        {
            return await _context.Vendas
                .Where(v => v.IdFilial == filialId)
                .Include(v => v.ItensVenda)  // Assuming ItensVenda is a related entity
                .ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Retrieves a venda by its unique number
        /// </summary>
        /// <param name="numeroVenda">The unique number of the venda</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The venda if found, null otherwise</returns>
        public async Task<Venda?> GetByNumeroVendaAsync(string numeroVenda, CancellationToken cancellationToken = default)
        {
            return await _context.Vendas
                .Include(v => v.ItensVenda)  // Incluindo a navegação para ItensVenda, caso exista
                .FirstOrDefaultAsync(v => v.NumeroVenda == numeroVenda, cancellationToken);
        }
 
        /// <summary>
        /// Retrieves all vendas
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A list of all vendas</returns>
        public async Task<IEnumerable<Venda>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Vendas
                .Include(v => v.ItensVenda)  // Assuming ItensVenda is a related entity
                .ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Updates an existing venda in the database
        /// </summary>
        /// <param name="venda">The venda with updated information</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The updated venda</returns>
        public async Task<Venda> UpdateAsync(Venda venda, CancellationToken cancellationToken = default)
        {
            _context.Vendas.Update(venda);
            await _context.SaveChangesAsync(cancellationToken);
            return venda;
        }

        /// <summary>
        /// Deletes a venda from the database
        /// </summary>
        /// <param name="id">The unique identifier of the venda to delete</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if the venda was deleted, false if not found</returns>
        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var venda = await GetByIdAsync(id, cancellationToken);
            if (venda == null)
                return false;

            _context.Vendas.Remove(venda);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
