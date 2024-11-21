﻿using Ambev.DeveloperEvaluation.Domain.Entities;
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
            // Evitar duplicação de itens de venda (agrupando por produto)
            var itensVenda = venda.ItensVenda
                                  .GroupBy(i => i.IdProduto)
                                  .Select(g => g.First())  // Seleciona o primeiro item de cada grupo
                                  .ToList();

            // Verificar se algum item tem mais de 20 unidades
            foreach (var item in itensVenda)
            {
                if (item.Quantidade > 20)
                {
                    throw new ArgumentException($"Não é permitido vender mais de 20 itens do produto {item.IdProduto}."); // Lançar exceção se exceder o limite
                }
            }

            // Atribuir os itens filtrados à venda
            venda.ItensVenda = itensVenda;

            // Calcular o valor total de cada item e aplicar o desconto no item
            foreach (var item in venda.ItensVenda)
            {
                item.ValorTotal = item.Quantidade * item.PrecoUnitario;

                // Calcular o desconto do item, baseado na quantidade
                item.Desconto = CalcularDesconto(item.Quantidade);  // Cálculo do desconto por item

                // Subtrair o desconto do valor total do item
                item.ValorTotal -= item.Desconto;
            }

            // Calcular o valor total dos produtos da venda (após os descontos nos itens)
            venda.ValorTotalProdutos = venda.ItensVenda.Sum(item => item.ValorTotal);

            // Calcular o desconto total para a venda com base no valor total dos itens
            venda.DescontoVenda = CalcularDescontoVenda((int)venda.ValorTotalProdutos); // Calcular o desconto para a venda

            // Calcular o valor total da venda (após o desconto total)
            venda.ValorTotalVenda = venda.ValorTotalProdutos - venda.DescontoVenda;

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
                .Include(v => v.ItensVenda)  // Assuming ItensVenda is a related entity
                .FirstOrDefaultAsync(v => v.Id == id, cancellationToken);
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

        //public async Task<IEnumerable<Venda>> GetByProdutoIdAsync(Guid produtoId, CancellationToken cancellationToken = default)
        //{
        //    return await _context.Vendas
        //        .Where(v => v.IdProduto == produtoId)  // Verificando o campo IdProduto
        //        .Include(v => v.ItensVenda)  // Assumindo que ItensVenda é uma entidade relacionada
        //        .ToListAsync(cancellationToken);
        //}

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
            _context.Vendas.Update(venda);
            await _context.SaveChangesAsync(cancellationToken);
            return venda;
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
