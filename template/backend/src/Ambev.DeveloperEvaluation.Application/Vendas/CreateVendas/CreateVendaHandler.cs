using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Vendas.CreateVenda;
using System;

namespace Ambev.DeveloperEvaluation.Application.Vendas.CreateVenda
{
    /// <summary>
    /// Handler for processing CreateVendaCommand requests
    /// </summary>
    public class CreateVendaHandler : IRequestHandler<CreateVendaCommand, CreateVendaResult>
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of CreateVendaHandler
        /// </summary>
        /// <param name="vendaRepository">The venda repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public CreateVendaHandler(IVendaRepository vendaRepository, IMapper mapper)
        {
            _vendaRepository = vendaRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the CreateVendaCommand request
        /// </summary>
        /// <param name="command">The CreateVenda command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created sale details</returns>
        public async Task<CreateVendaResult> Handle(CreateVendaCommand command, CancellationToken cancellationToken)
        {
            // Validação do comando CreateVendaCommand
            var validator = new CreateVendaCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            // Verificando se já existe alguma venda com o número informado (caso haja alguma restrição nesse sentido)
            var existingVenda = await _vendaRepository.GetByNumeroVendaAsync(command.NumeroVenda, cancellationToken);
            if (existingVenda != null)
                throw new InvalidOperationException($"A venda com o número {command.NumeroVenda} já existe.");

            // Mapeando o comando para a entidade Venda
            var venda = _mapper.Map<Venda>(command);

            // Criando a venda no repositório
            var createdVenda = await _vendaRepository.CreateAsync(venda, cancellationToken);

            // Retornando os dados da venda criada
            var result = _mapper.Map<CreateVendaResult>(createdVenda);
            return result;
        }
    }
}
