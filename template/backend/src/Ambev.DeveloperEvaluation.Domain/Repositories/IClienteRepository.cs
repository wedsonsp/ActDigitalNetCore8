using Ambev.DeveloperEvaluation.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface IClienteRepository
    {
        Task<Cliente> CreateAsync(Cliente cliente, CancellationToken cancellationToken = default);
        Task<Cliente?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Cliente?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }

}
