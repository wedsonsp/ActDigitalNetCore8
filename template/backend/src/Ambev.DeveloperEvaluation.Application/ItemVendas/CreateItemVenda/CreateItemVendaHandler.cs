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

        public CreateItemVendaHandler(IItemVendaRepository itemVendaRepository, IVendaRepository vendaRepository, IMapper mapper)
        {
            _itemVendaRepository = itemVendaRepository;
            _vendaRepository = vendaRepository;
            _mapper = mapper;
        }

        public async Task<CreateItemVendaResult> Handle(CreateItemVendaCommand command, CancellationToken cancellationToken)
        {
            // Validação dos dados
            var validator = new CreateItemVendaCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            // Mapeia o comando para a entidade ItemVenda
            var itemVenda = _mapper.Map<ItemVenda>(command);

            // Salva o item de venda sem associá-lo a uma venda ainda
            var createdItemVenda = await _itemVendaRepository.CreateAsync(itemVenda, cancellationToken);

            // Mapeia o item de venda criado para o resultado
            var result = _mapper.Map<CreateItemVendaResult>(createdItemVenda);

            return result;
        }
    }

}
