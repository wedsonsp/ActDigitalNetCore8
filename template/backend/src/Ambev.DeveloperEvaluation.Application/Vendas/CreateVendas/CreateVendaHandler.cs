using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Vendas.CreateVenda;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.ItemVendas.CreateItemVenda;

namespace Ambev.DeveloperEvaluation.Application.Vendas.CreateVenda
{
    /// <summary>
    /// Handler for processing CreateVendaCommand requests
    /// </summary>
    public class CreateVendaHandler : IRequestHandler<CreateVendaCommand, CreateVendaResult>
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly IMapper _mapper;

        public CreateVendaHandler(IVendaRepository vendaRepository, IMapper mapper)
        {
            _vendaRepository = vendaRepository;
            _mapper = mapper;
        }

        public async Task<CreateVendaResult> Handle(CreateVendaCommand command, CancellationToken cancellationToken)
        {
            // Validação do comando CreateVendaCommand
            var validator = new CreateVendaCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            // Verificando se já existe alguma venda com o número informado
            var existingVenda = await _vendaRepository.GetByNumeroVendaAsync(command.NumeroVenda, cancellationToken);
            if (existingVenda != null)
                throw new InvalidOperationException($"A venda com o número {command.NumeroVenda} já existe.");

            // Mapeando o comando para a entidade Venda
            var venda = _mapper.Map<Venda>(command);  // Aqui, os itens já são mapeados para a lista de ItensVenda, se configurado corretamente no AutoMapper.

            // Criando a venda no repositório
            var createdVenda = await _vendaRepository.CreateAsync(venda, cancellationToken);

            // Mapeando a venda criada para a resposta
            var result = _mapper.Map<CreateVendaResult>(createdVenda);

            // Mapear os itens de venda na resposta
            result.ItensVenda = createdVenda.ItensVenda
                .Select(item => new CreateItemVendaResult
                {
                    IdProduto = item.IdProduto,
                    Quantidade = item.Quantidade,
                    PrecoUnitario = item.PrecoUnitario,
                    ValorTotal = item.ValorTotal
                })
                .ToList();

            return result;
        }

    }

}
