using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Clients.CreateCliente;
using Ambev.DeveloperEvaluation.Application.Clientes.CreateCliente;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Clients;

/// <summary>
/// Controller for managing client operations
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class ClientesController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of ClientesController
    /// </summary>
    /// <param name="mediator">The mediator instance</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public ClientesController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Creates a new client
    /// </summary>
    /// <param name="request">The client creation request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created client details</returns>
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateClienteResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateCliente([FromBody] CreateClienteRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateClienteRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<CreateClienteCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<CreateClienteResponse>
        {
            Success = true,
            Message = "Client created successfully",
            Data = _mapper.Map<CreateClienteResponse>(response)
        });
    }

    /// <summary>
    /// Retrieves a client by their ID
    /// </summary>
    /// <param name="id">The unique identifier of the client</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The client details if found</returns>
    //[HttpGet("{id}")]
    //[ProducesResponseType(typeof(ApiResponseWithData<GetClienteResponse>), StatusCodes.Status200OK)]
    //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    //public async Task<IActionResult> GetCliente([FromRoute] Guid id, CancellationToken cancellationToken)
    //{
    //    var request = new GetClienteRequest { Id = id };
    //    var validator = new GetClienteRequestValidator();
    //    var validationResult = await validator.ValidateAsync(request, cancellationToken);

    //    if (!validationResult.IsValid)
    //        return BadRequest(validationResult.Errors);

    //    var command = _mapper.Map<GetClienteCommand>(request.Id);
    //    var response = await _mediator.Send(command, cancellationToken);

    //    return Ok(new ApiResponseWithData<GetClienteResponse>
    //    {
    //        Success = true,
    //        Message = "Client retrieved successfully",
    //        Data = _mapper.Map<GetClienteResponse>(response)
    //    });
    //}

    /// <summary>
    /// Deletes a client by their ID
    /// </summary>
    /// <param name="id">The unique identifier of the client to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Success response if the client was deleted</returns>
    //[HttpDelete("{id}")]
    //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    //public async Task<IActionResult> DeleteCliente([FromRoute] Guid id, CancellationToken cancellationToken)
    //{
    //    var request = new DeleteClienteRequest { Id = id };
    //    var validator = new DeleteClienteRequestValidator();
    //    var validationResult = await validator.ValidateAsync(request, cancellationToken);

    //    if (!validationResult.IsValid)
    //        return BadRequest(validationResult.Errors);

    //    var command = _mapper.Map<DeleteClienteCommand>(request.Id);
    //    await _mediator.Send(command, cancellationToken);

    //    return Ok(new ApiResponse
    //    {
    //        Success = true,
    //        Message = "Client deleted successfully"
    //    });
    //}
}
