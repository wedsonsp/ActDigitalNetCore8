using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Filiais.CreateFilial;

namespace Ambev.DeveloperEvaluation.Application.Filiais.CreateFilial
{
    /// <summary>
    /// Handler for processing CreateFilialCommand requests
    /// </summary>
    public class CreateFilialHandler : IRequestHandler<CreateFilialCommand, CreateFilialResult>
    {
        private readonly IFilialRepository _filialRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of CreateFilialHandler
        /// </summary>
        /// <param name="filialRepository">The Filial repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public CreateFilialHandler(IFilialRepository filialRepository, IMapper mapper)
        {
            _filialRepository = filialRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the CreateFilialCommand request
        /// </summary>
        /// <param name="command">The CreateFilial command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created filial details</returns>
        public async Task<CreateFilialResult> Handle(CreateFilialCommand command, CancellationToken cancellationToken)
        {
            // Valida o comando de criação da filial
            var validator = new CreateFilialCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            // Verifica se já existe uma filial com o mesmo nome
            var existingFilial = await _filialRepository.GetByNameAsync(command.Nome, cancellationToken);
            if (existingFilial != null)
                throw new InvalidOperationException($"Filial com o nome {command.Nome} já existe.");

            // Mapeia o comando para a entidade Filial
            var filial = _mapper.Map<Filial>(command);

            // Cria a filial no repositório
            var createdFilial = await _filialRepository.CreateAsync(filial, cancellationToken);

            // Mapeia a entidade Filial criada para o resultado
            var result = _mapper.Map<CreateFilialResult>(createdFilial);
            return result;
        }
    }
}
