using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DefaultContext _context;

        public ProdutoRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task<Produto> CreateAsync(Produto produto, CancellationToken cancellationToken = default)
        {
            await _context.Set<Produto>().AddAsync(produto, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return produto;
        }

        public async Task<Produto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Produto>().FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        }

        public async Task<Produto?> GetByNameAsync(string nome, CancellationToken cancellationToken = default)
        {
            // Alterado para usar ToLower() para comparação de strings sem considerar maiúsculas/minúsculas
            return await _context.Set<Produto>()
                .FirstOrDefaultAsync(p => p.Nome.ToLower() == nome.ToLower(), cancellationToken);
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
