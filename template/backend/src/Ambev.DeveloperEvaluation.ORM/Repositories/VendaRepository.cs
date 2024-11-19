using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class VendaRepository : IVendaRepository
    {
        private readonly DefaultContext _context;

        public VendaRepository(DefaultContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Cria uma nova venda no banco de dados.
        /// </summary>
        /// <param name="venda">A venda a ser criada.</param>
        /// <param name="cancellationToken">Token de cancelamento.</param>
        /// <returns>A venda criada.</returns>
        public async Task<Venda> CreateAsync(Venda venda, CancellationToken cancellationToken = default)
        {
            await _context.Set<Venda>().AddAsync(venda, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return venda;
        }

        /// <summary>
        /// Retorna uma venda pelo seu ID.
        /// </summary>
        /// <param name="id">O ID da venda.</param>
        /// <param name="cancellationToken">Token de cancelamento.</param>
        /// <returns>A venda encontrada ou null.</returns>
        public async Task<Venda?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Venda>()
                .Include(v => v.Cliente)   // Inclui o cliente
                .Include(v => v.Filial)    // Inclui a filial
                .FirstOrDefaultAsync(v => v.Id == id, cancellationToken);
        }

        /// <summary>
        /// Deleta uma venda pelo seu ID.
        /// </summary>
        /// <param name="id">O ID da venda a ser deletada.</param>
        /// <param name="cancellationToken">Token de cancelamento.</param>
        /// <returns>True se a venda foi deletada, falso se não encontrada.</returns>
        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var venda = await GetByIdAsync(id, cancellationToken);
            if (venda == null)
                return false;

            _context.Set<Venda>().Remove(venda);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
