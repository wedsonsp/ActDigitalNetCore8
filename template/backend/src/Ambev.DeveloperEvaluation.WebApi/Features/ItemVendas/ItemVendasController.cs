using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.ItemVendas.CreateItemVenda;
using Ambev.DeveloperEvaluation.Application.ItemVendas.CreateItemVenda;

namespace Ambev.DeveloperEvaluation.WebApi.Features.ItemVendas;

/// <summary>
/// Controller for managing item venda operations
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class ItemVendasController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of ItemVendasController
    /// </summary>
    /// <param name="mediator">The mediator instance</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public ItemVendasController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Creates a new item venda
    /// </summary>
    /// <param name="request">The item venda creation request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created item venda details</returns>
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateItemVendaResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateItemVenda([FromBody] CreateItemVendaRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateItemVendaRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<CreateItemVendaCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<CreateItemVendaResponse>
        {
            Success = true,
            Message = "Item venda created successfully",
            Data = _mapper.Map<CreateItemVendaResponse>(response)
        });
    }

    /// <summary>
    /// Retrieves an item venda by its ID
    /// </summary>
    /// <param name="id">The unique identifier of the item venda</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The item venda details if found</returns>
    //[HttpGet("{id}")]
    //[ProducesResponseType(typeof(ApiResponseWithData<GetItemVendaResponse>), StatusCodes.Status200OK)]
    //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    //public async Task<IActionResult> GetItemVenda([FromRoute] Guid id, CancellationToken cancellationToken)
    //{
    //    var request = new GetItemVendaRequest { Id = id };
    //    var validator = new GetItemVendaRequestValidator();
    //    var validationResult = await validator.ValidateAsync(request, cancellationToken);

    //    if (!validationResult.IsValid)
    //        return BadRequest(validationResult.Errors);

    //    var command = _mapper.Map<GetItemVendaCommand>(request.Id);
    //    var response = await _mediator.Send(command, cancellationToken);

    //    return Ok(new ApiResponseWithData<GetItemVendaResponse>
    //    {
    //        Success = true,
    //        Message = "Item venda retrieved successfully",
    //        Data = _mapper.Map<GetItemVendaResponse>(response)
    //    });
    //}

    /// <summary>
    /// Deletes an item venda by its ID
    /// </summary>
    /// <param name="id">The unique identifier of the item venda to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Success response if the item venda was deleted</returns>
    //[HttpDelete("{id}")]
    //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    //public async Task<IActionResult> DeleteItemVenda([FromRoute] Guid id, CancellationToken cancellationToken)
    //{
    //    var request = new DeleteItemVendaRequest { Id = id };
    //    var validator = new DeleteItemVendaRequestValidator();
    //    var validationResult = await validator.ValidateAsync(request, cancellationToken);

    //    if (!validationResult.IsValid)
    //        return BadRequest(validationResult.Errors);

    //    var command = _mapper.Map<DeleteItemVendaCommand>(request.Id);
    //    await _mediator.Send(command, cancellationToken);

    //    return Ok(new ApiResponse
    //    {
    //        Success = true,
    //        Message = "Item venda deleted successfully"
    //    });
    //}
}
