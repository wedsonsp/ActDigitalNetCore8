using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    /// <summary>
    /// Interface do repositório para operações relacionadas ao ItemVenda.
    /// </summary>
    public interface IItemVendaRepository
    {
        /// <summary>
        /// Cria um novo item de venda no repositório.
        /// </summary>
        /// <param name="itemVenda">O item de venda a ser criado.</param>
        /// <param name="cancellationToken">Token de cancelamento.</param>
        /// <returns>O item de venda criado.</returns>
        Task<ItemVenda> CreateAsync(ItemVenda itemVenda, CancellationToken cancellationToken = default);

        /// <summary>
        /// Recupera um item de venda pelo seu identificador único.
        /// </summary>
        /// <param name="id">O identificador único do item de venda.</param>
        /// <param name="cancellationToken">Token de cancelamento.</param>
        /// <returns>O item de venda se encontrado, caso contrário, null.</returns>
        Task<ItemVenda?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Recupera todos os itens de venda associados a uma venda específica.
        /// </summary>
        /// <param name="vendaId">O identificador da venda.</param>
        /// <param name="cancellationToken">Token de cancelamento.</param>
        /// <returns>Uma lista de itens de venda para a venda especificada.</returns>
        //Task<IEnumerable<ItemVenda>> GetByVendaIdAsync(Guid vendaId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Recupera todos os itens de venda associados a um produto específico.
        /// </summary>
        /// <param name="produtoId">O identificador do produto.</param>
        /// <param name="cancellationToken">Token de cancelamento.</param>
        /// <returns>Uma lista de itens de venda associados ao produto especificado.</returns>
        Task<IEnumerable<ItemVenda>> GetByProdutoIdAsync(Guid produtoId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Recupera todos os itens de venda.
        /// </summary>
        /// <param name="cancellationToken">Token de cancelamento.</param>
        /// <returns>Uma lista de todos os itens de venda.</returns>
        Task<IEnumerable<ItemVenda>> GetAllAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Atualiza um item de venda existente no repositório.
        /// </summary>
        /// <param name="itemVenda">O item de venda com informações atualizadas.</param>
        /// <param name="cancellationToken">Token de cancelamento.</param>
        /// <returns>O item de venda atualizado.</returns>
        Task<ItemVenda> UpdateAsync(ItemVenda itemVenda, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deleta um item de venda do repositório.
        /// </summary>
        /// <param name="id">O identificador único do item de venda a ser deletado.</param>
        /// <param name="cancellationToken">Token de cancelamento.</param>
        /// <returns>True se o item foi deletado, ou false se não encontrado.</returns>
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
