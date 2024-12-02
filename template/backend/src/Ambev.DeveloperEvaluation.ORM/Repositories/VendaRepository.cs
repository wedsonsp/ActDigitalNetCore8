using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

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
            // Garantir que a lista de ItensVenda está sem duplicação
            var itensVenda = venda.ItensVenda.ToList();

            // Validar se algum item tem mais de 20 unidades individualmente
            foreach (var item in itensVenda)
            {
                if (item.Quantidade <= 0 || item.Quantidade > 20)
                {
                    throw new ArgumentException($"Não é permitido vender menos que 1 e mais de 20 unidades do Item de cada produto {item.IdProduto}. A quantidade de cada item de um produto não pode ser menos que 1 e nem exceder 20.");
                }
            }

            // Agora validamos a quantidade de registros (itens) de cada produto individualmente
            var totaisPorProduto = new Dictionary<Guid, int>();

            foreach (var item in itensVenda)
            {
                // Se o produto já foi encontrado, incrementa o contador
                if (totaisPorProduto.ContainsKey(item.IdProduto))
                {
                    totaisPorProduto[item.IdProduto] += 1;  // Contabiliza o número de registros (itens) para esse produto
                }
                else
                {
                    totaisPorProduto[item.IdProduto] = 1;  // Se o produto não foi encontrado, inicializa com 1
                }
            }

            // Agora validamos o número de registros (itens) de cada produto
            foreach (var produto in totaisPorProduto)
            {
                var produtoId = produto.Key;
                var quantidadeDeRegistros = produto.Value;

                // Se o número de registros (itens) para o produto exceder 20, lançamos uma exceção
                if (quantidadeDeRegistros > 20)
                {
                    throw new ArgumentException($"Não é permitido vender mais de 20 itens do produto {produtoId}. A quantidade de itens desse produto excede 20.");
                }
            }


            // Calcular a soma de todas as quantidades de itens para usar no cálculo do desconto da venda
            //var somaQuantidades = venda.ItensVenda.Sum(item => item.Quantidade);
            // Contar o número total de itens na venda (em termos de quantidade de registros, não somando as quantidades dos itens)
            var somaQuantidades = venda.ItensVenda.Count();


            // Calcular o desconto total para a venda baseado na soma das quantidades
            venda.DescontoVenda = CalcularDescontoVenda(somaQuantidades);

            // Calcular o valor total da venda (após o desconto total)
            venda.ValorTotalVenda = venda.ItensVenda.Sum(item => item.ValorTotal);

            // Calcular o valor total da venda (após o desconto total)
            venda.ValorTotalVendaDesconto = venda.ValorTotalVenda - (venda.ValorTotalVenda * venda.DescontoVenda);

            // Data de criação da venda
            venda.DataCadastro = DateTime.UtcNow;

            // Salvar a venda no banco
            await _context.Vendas.AddAsync(venda, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return venda;
        }

        // Dentro do VendaRepository
        private decimal CalcularDescontoVenda(int quantidade)
        {
            if (quantidade >= 10 && quantidade <= 20)
            {
                return 0.20m;  // 20% de desconto
            }
            else if (quantidade > 4)
            {
                return 0.10m;  // 10% de desconto
            }
            else
            {
                return 0.00m;  // Nenhum desconto
            }
        }

        // Calcular a quantidade de cada item
        private decimal CalcularDesconto(int quantidade)
        {
            // Lógica de cálculo do desconto baseado na quantidade
            if (quantidade >= 10 && quantidade <= 20)
            {
                return 0.20m;  // 20% de desconto
            }
            else if (quantidade > 4)
            {
                return 0.10m;  // 10% de desconto
            }
            else
            {
                return 0.00m;  // Nenhum desconto
            }
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
                .Include(v => v.ItensVenda)  // Inclui os itens da venda
                .FirstOrDefaultAsync(v => v.Id == id, cancellationToken); // Filtra pela venda com o id especificado
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
            // Buscar a venda existente no banco
            var vendaExistente = await _context.Vendas
                .FirstOrDefaultAsync(v => v.Id == venda.Id, cancellationToken);

            if (vendaExistente == null)
            {
                throw new ArgumentException("Venda não encontrada.");
            }

            // Atualizar os campos da venda
            //vendaExistente.ValorTotalVenda = venda.ValorTotalVenda;
            //vendaExistente.ValorTotalVendaDesconto = venda.ValorTotalVendaDesconto;
            //vendaExistente.DescontoVenda = venda.DescontoVenda;
            vendaExistente.Status = venda.Status;
            vendaExistente.DataAlteracao = DateTime.UtcNow;

            // Salvar as alterações no banco
            await _context.SaveChangesAsync(cancellationToken);

            return vendaExistente;
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

        // Renomeando para evitar ambiguidade
        public async Task<Venda?> GetVendaByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Vendas
                .Include(v => v.ItensVenda)  // Incluindo os itens da venda
                .FirstOrDefaultAsync(v => v.Id == id, cancellationToken);
        }
    }
}
