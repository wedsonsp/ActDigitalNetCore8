using AutoMapper;
using FluentValidation;
using MediatR;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Application.ItemVendas.CreateItemVenda;
using Ambev.DeveloperEvaluation.Domain.Validation;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.ItemVendas.CreateItemVenda
{
    /// <summary>
    /// Handler for processing CreateItemVendaCommand requests
    /// </summary>
    public class CreateItemVendaHandler : IRequestHandler<CreateItemVendaCommand, CreateItemVendaResult>
    {
        private readonly IItemVendaRepository _itemVendaRepository;
        private readonly IVendaRepository _vendaRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of CreateItemVendaHandler
        /// </summary>
        /// <param name="itemVendaRepository">The item venda repository</param>
        /// <param name="vendaRepository">The venda repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public CreateItemVendaHandler(IItemVendaRepository itemVendaRepository, IVendaRepository vendaRepository, IMapper mapper)
        {
            _itemVendaRepository = itemVendaRepository;
            _vendaRepository = vendaRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the CreateItemVendaCommand request
        /// </summary>
        /// <param name="command">The CreateItemVenda command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created item venda details</returns>
        public async Task<CreateItemVendaResult> Handle(CreateItemVendaCommand command, CancellationToken cancellationToken)
        {
            // Valida os dados do comando usando o CreateItemVendaCommandValidator
            var validator = new CreateItemVendaCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            // Verifica se a venda associada ao item de venda existe pelo IdVenda
            var venda = await _vendaRepository.GetByIdAsync(command.IdVenda, cancellationToken);
            if (venda == null)
                throw new InvalidOperationException($"Venda com o Id {command.IdVenda} não encontrada.");

            // Mapeia o comando para a entidade ItemVenda
            var itemVenda = _mapper.Map<ItemVenda>(command);
            itemVenda.IdVenda = venda.Id;  // Associa o item de venda à venda existente

            // Salva o item de venda no repositório
            var createdItemVenda = await _itemVendaRepository.CreateAsync(itemVenda, cancellationToken);

            // Mapeia o item de venda criado para o resultado
            var result = _mapper.Map<CreateItemVendaResult>(createdItemVenda);

            return result;
        }
    }
}
