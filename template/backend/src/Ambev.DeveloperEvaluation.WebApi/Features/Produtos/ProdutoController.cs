using Ambev.DeveloperEvaluation.Application.Produtos.CreateProduto;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Produtos.CreateProduto;
using Ambev.DeveloperEvaluation.WebApi.Features.Produtos;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProdutoController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of ProdutoController
    /// </summary>
    /// <param name="mediator">The mediator instance</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public ProdutoController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Creates a new product
    /// </summary>
    /// <param name="request">The product creation request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created product details</returns>
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateProdutoResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateProduto([FromBody] CreateProdutoRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateProdutoRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<CreateProdutoCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);  // Agora, este comando deve retornar um valor!

        return Created(string.Empty, new ApiResponseWithData<CreateProdutoResponse>
        {
            Success = true,
            Message = "Product created successfully",
            Data = _mapper.Map<CreateProdutoResponse>(response)  // Mapeia a resposta do produto
        });
    }

    /// <summary>
    /// Deletes a product by its ID
    /// </summary>
    /// <param name="id">The unique identifier of the product to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Success response if the product was deleted</returns>
    //[HttpDelete("{id}")]
    //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    //public async Task<IActionResult> DeleteProduto([FromRoute] Guid id, CancellationToken cancellationToken)
    //{
    //    var request = new DeleteProdutoRequest { Id = id };
    //    var validator = new DeleteProdutoRequestValidator();
    //    var validationResult = await validator.ValidateAsync(request, cancellationToken);

    //    if (!validationResult.IsValid)
    //        return BadRequest(validationResult.Errors);

    //    var command = _mapper.Map<DeleteProdutoCommand>(request.Id);
    //    await _mediator.Send(command, cancellationToken);  // Não há necessidade de armazenar em uma variável, apenas envia o comando.

    //    return Ok(new ApiResponse
    //    {
    //        Success = true,
    //        Message = "Product deleted successfully"
    //    });
    //}
}
