using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface IFilialRepository
    {
        /// <summary>
        /// Cria uma nova filial no banco de dados.
        /// </summary>
        Task<Filial> CreateAsync(Filial filial, CancellationToken cancellationToken = default);

        /// <summary>
        /// Recupera uma filial pelo seu identificador único (ID).
        /// </summary>
        Task<Filial?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Recupera uma filial pelo nome.
        /// </summary>
        Task<Filial?> GetByNameAsync(string nome, CancellationToken cancellationToken = default);

        /// <summary>
        /// Exclui uma filial pelo seu identificador único (ID).
        /// </summary>
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

       
   
    }
}
