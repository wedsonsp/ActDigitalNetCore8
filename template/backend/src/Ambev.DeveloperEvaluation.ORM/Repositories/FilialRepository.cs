using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    /// <summary>
    /// Implementação de IFilialRepository usando Entity Framework Core.
    /// </summary>
    public class FilialRepository : IFilialRepository
    {
        private readonly DefaultContext _context;

        /// <summary>
        /// Inicializa uma nova instância de FilialRepository.
        /// </summary>
        /// <param name="context">O contexto do banco de dados.</param>
        public FilialRepository(DefaultContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Cria uma nova filial no banco de dados.
        /// </summary>
        /// <param name="filial">A filial a ser criada.</param>
        /// <param name="cancellationToken">Token de cancelamento.</param>
        /// <returns>A filial criada.</returns>
        public async Task<Filial> CreateAsync(Filial filial, CancellationToken cancellationToken = default)
        {
            await _context.Filiais.AddAsync(filial, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return filial;
        }

        /// <summary>
        /// Recupera uma filial pelo seu identificador único.
        /// </summary>
        /// <param name="id">O identificador único da filial.</param>
        /// <param name="cancellationToken">Token de cancelamento.</param>
        /// <returns>A filial encontrada ou null se não encontrar.</returns>
        public async Task<Filial?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Filiais
                .FirstOrDefaultAsync(f => f.Id == id, cancellationToken);
        }

        /// <summary>
        /// Recupera uma filial pelo nome.
        /// </summary>
        /// <param name="nome">O nome da filial.</param>
        /// <param name="cancellationToken">Token de cancelamento.</param>
        /// <returns>A filial encontrada ou null se não encontrar.</returns>
        public async Task<Filial?> GetByNameAsync(string nome, CancellationToken cancellationToken = default)
        {
            // Usando ToLower() para garantir a comparação insensível a maiúsculas/minúsculas
            return await _context.Filiais
                .FirstOrDefaultAsync(f => f.Nome.ToLower() == nome.ToLower(), cancellationToken);
        }


        /// <summary>
        /// Exclui uma filial pelo identificador único.
        /// </summary>
        /// <param name="id">O identificador único da filial a ser excluída.</param>
        /// <param name="cancellationToken">Token de cancelamento.</param>
        /// <returns>True se a filial foi excluída, falso se não foi encontrada.</returns>
        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var filial = await GetByIdAsync(id, cancellationToken);
            if (filial == null)
                return false;

            _context.Filiais.Remove(filial);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
