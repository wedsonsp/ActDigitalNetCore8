using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Vendas.GetVenda;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.Application.Vendas.GetVenda
{
    /// <summary>
    /// Handler for processing GetVendaCommand requests
    /// </summary>
    public class GetVendaHandler : IRequestHandler<GetVendaCommand, GetVendaResult>
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of GetVendaHandler
        /// </summary>
        /// <param name="vendaRepository">The venda repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public GetVendaHandler(
            IVendaRepository vendaRepository,
            IMapper mapper)
        {
            _vendaRepository = vendaRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the GetVendaCommand request
        /// </summary>
        /// <param name="request">The GetVenda command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The sale details if found</returns>
        public async Task<GetVendaResult> Handle(GetVendaCommand request, CancellationToken cancellationToken)
        {
            // Validação da solicitação (opcional, você pode adicionar um validador específico se necessário)
            var validator = new GetVendaValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            // Recuperando a venda usando o repositório
            var venda = await _vendaRepository.GetByIdAsync(request.Id, cancellationToken);
            if (venda == null)
                throw new KeyNotFoundException($"Venda with ID {request.Id} not found");

            // Mapeando a venda para o resultado esperado
            return _mapper.Map<GetVendaResult>(venda);
        }
    }
}
