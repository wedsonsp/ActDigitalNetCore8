using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface IProdutoRepository
    {
        Task<Produto> CreateAsync(Produto produto, CancellationToken cancellationToken = default);
        Task<Produto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Produto?> GetByNameAsync(string nome, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
