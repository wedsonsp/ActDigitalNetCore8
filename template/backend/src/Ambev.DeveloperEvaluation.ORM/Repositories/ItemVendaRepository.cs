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
    /// Implementation of IItemVendaRepository using Entity Framework Core
    /// </summary>
    public class ItemVendaRepository : IItemVendaRepository
    {
        private readonly DefaultContext _context;

        /// <summary>
        /// Initializes a new instance of ItemVendaRepository
        /// </summary>
        /// <param name="context">The database context</param>
        public ItemVendaRepository(DefaultContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new item venda in the database
        /// </summary>
        /// <param name="itemVenda">The item venda to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created item venda</returns>
        public async Task<ItemVenda> CreateAsync(ItemVenda itemVenda, CancellationToken cancellationToken = default)
        {
            await _context.ItensVenda.AddAsync(itemVenda, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return itemVenda;
        }

        /// <summary>
        /// Retrieves an item venda by its unique identifier
        /// </summary>
        /// <param name="id">The unique identifier of the item venda</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The item venda if found, null otherwise</returns>
        public async Task<ItemVenda?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.ItensVenda
                .Include(i => i.Venda)  // Assuming ItemVenda has a navigation property to Venda
                .FirstOrDefaultAsync(i => i.Id == id, cancellationToken);
        }

        /// <summary>
        /// Retrieves all item vendas associated with a specific venda
        /// </summary>
        /// <param name="vendaId">The unique identifier of the venda</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A list of item vendas for the venda</returns>
        public async Task<IEnumerable<ItemVenda>> GetByVendaIdAsync(Guid vendaId, CancellationToken cancellationToken = default)
        {
            return await _context.ItensVenda
                .Where(i => i.IdVenda == vendaId)
                .Include(i => i.Venda)  // Assuming ItemVenda has a navigation property to Venda
                .ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Retrieves all item vendas associated with a specific product
        /// </summary>
        /// <param name="produtoId">The unique identifier of the product</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A list of item vendas for the product</returns>
        public async Task<IEnumerable<ItemVenda>> GetByProdutoIdAsync(Guid produtoId, CancellationToken cancellationToken = default)
        {
            return await _context.ItensVenda
                .Where(i => i.IdProduto == produtoId)
                .Include(i => i.Venda)  // Assuming ItemVenda has a navigation property to Venda
                .ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Retrieves all item vendas
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A list of all item vendas</returns>
        public async Task<IEnumerable<ItemVenda>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.ItensVenda
                .Include(i => i.Venda)  // Assuming ItemVenda has a navigation property to Venda
                .ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Updates an existing item venda in the database
        /// </summary>
        /// <param name="itemVenda">The item venda with updated information</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The updated item venda</returns>
        public async Task<ItemVenda> UpdateAsync(ItemVenda itemVenda, CancellationToken cancellationToken = default)
        {
            _context.ItensVenda.Update(itemVenda);
            await _context.SaveChangesAsync(cancellationToken);
            return itemVenda;
        }

        /// <summary>
        /// Deletes an item venda from the database
        /// </summary>
        /// <param name="id">The unique identifier of the item venda to delete</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if the item venda was deleted, false if not found</returns>
        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var itemVenda = await GetByIdAsync(id, cancellationToken);
            if (itemVenda == null)
                return false;

            _context.ItensVenda.Remove(itemVenda);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
