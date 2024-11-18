using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Clientes.CreateCliente;

/// <summary>
/// Handler para processar a requisição CreateClienteCommand
/// </summary>
public class CreateClienteHandler : IRequestHandler<CreateClienteCommand, CreateClienteResult>
{
    private readonly IClienteRepository _clienteRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Inicializa uma nova instância do CreateClienteHandler
    /// </summary>
    /// <param name="clienteRepository">Repositório de clientes</param>
    /// <param name="mapper">Instância do AutoMapper</param>
    public CreateClienteHandler(IClienteRepository clienteRepository, IMapper mapper)
    {
        _clienteRepository = clienteRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Manipula a requisição CreateClienteCommand
    /// </summary>
    /// <param name="command">O comando CreateCliente</param>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>Detalhes do cliente criado</returns>
    public async Task<CreateClienteResult> Handle(CreateClienteCommand command, CancellationToken cancellationToken)
    {
        // Validação do comando (por exemplo, garantir que o nome e o email não sejam nulos ou vazios)
        var validator = new CreateClienteCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        // Verificar se o cliente com o mesmo email já existe
        var existingCliente = await _clienteRepository.GetByEmailAsync(command.Email, cancellationToken);
        if (existingCliente != null)
            throw new InvalidOperationException($"Cliente com o email {command.Email} já existe");

        // Mapear o comando para a entidade Cliente
        var cliente = _mapper.Map<Cliente>(command);

        // Criar o cliente no repositório
        var createdCliente = await _clienteRepository.CreateAsync(cliente, cancellationToken);

        // Mapear o cliente criado para o resultado
        var result = _mapper.Map<CreateClienteResult>(createdCliente);

        return result;
    }
}
