using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DefaultContext _context;

        public ProdutoRepository(DefaultContext context)
        {
            _context = context;
        }

        // Método para obter um produto pelo ID
        public async Task<Produto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Produto>()
                                 .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);  // Usando o ID para buscar o produto
        }

        public async Task<Produto?> GetByNameAsync(string nome, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Produto>()
                                 .FirstOrDefaultAsync(p => p.Nome.ToLower() == nome.ToLower(), cancellationToken);
        }

        public async Task<Produto> CreateAsync(Produto produto, CancellationToken cancellationToken = default)
        {
            await _context.Set<Produto>().AddAsync(produto, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return produto;
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var produto = await GetByIdAsync(id, cancellationToken);
            if (produto == null)
                return false;

            _context.Set<Produto>().Remove(produto);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
