using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Application.Vendas.UpdateVendas;

namespace Ambev.DeveloperEvaluation.Application.Vendas.UpdateVenda
{
    /// <summary>
    /// Handler for processing UpdateVendaCommand requests
    /// </summary>
    public class UpdateVendaHandler : IRequestHandler<UpdateVendaCommand, UpdateVendaResult>
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of UpdateVendaHandler
        /// </summary>
        /// <param name="vendaRepository">The venda repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public UpdateVendaHandler(IVendaRepository vendaRepository, IMapper mapper)
        {
            _vendaRepository = vendaRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the UpdateVendaCommand request
        /// </summary>
        /// <param name="command">The UpdateVenda command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The updated sale details</returns>
        public async Task<UpdateVendaResult> Handle(UpdateVendaCommand command, CancellationToken cancellationToken)
        {
            var validator = new UpdateVendaCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            // Retrieve the existing sale by Id
            var existingVenda = await _vendaRepository.GetByIdAsync(command.Id, cancellationToken);
            if (existingVenda == null)
                throw new KeyNotFoundException($"Sale with ID {command.Id} not found");

            // Map the command to the entity (update the values)
            _mapper.Map(command, existingVenda);

            // Update the sale in the repository
            var updatedVenda = await _vendaRepository.UpdateAsync(existingVenda, cancellationToken);

            // Return the result (map the entity to the result)
            var result = _mapper.Map<UpdateVendaResult>(updatedVenda);
            return result;
        }
    }
}
