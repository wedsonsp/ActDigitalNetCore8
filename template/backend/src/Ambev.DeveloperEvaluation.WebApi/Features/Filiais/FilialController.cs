using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Filiais.CreateFilial;
using Ambev.DeveloperEvaluation.Application.Filiais.CreateFilial;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Filiais
{
    /// <summary>
    /// Controller for managing filial operations
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class FilialController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of FilialController
        /// </summary>
        /// <param name="mediator">The mediator instance</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public FilialController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Creates a new filial
        /// </summary>
        /// <param name="request">The filial creation request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created filial details</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseWithData<CreateFilialResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateFilial([FromBody] CreateFilialRequest request, CancellationToken cancellationToken)
        {
            // Validação do request de criação da filial
            var validator = new CreateFilialRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<CreateFilialCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            return Created(string.Empty, new ApiResponseWithData<CreateFilialResponse>
            {
                Success = true,
                Message = "Filial criada com sucesso",
                Data = _mapper.Map<CreateFilialResponse>(response)
            });
        }

        /// <summary>
        /// Retrieves a filial by its ID
        /// </summary>
        /// <param name="id">The unique identifier of the filial</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The filial details if found</returns>
        //[HttpGet("{id}")]
        //[ProducesResponseType(typeof(ApiResponseWithData<GetFilialResponse>), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> GetFilial([FromRoute] Guid id, CancellationToken cancellationToken)
        //{
        //    var request = new GetFilialRequest { Id = id };
        //    var validator = new GetFilialRequestValidator();
        //    var validationResult = await validator.ValidateAsync(request, cancellationToken);

        //    if (!validationResult.IsValid)
        //        return BadRequest(validationResult.Errors);

        //    var command = _mapper.Map<GetFilialCommand>(request.Id);
        //    var response = await _mediator.Send(command, cancellationToken);

        //    return Ok(new ApiResponseWithData<GetFilialResponse>
        //    {
        //        Success = true,
        //        Message = "Filial recuperada com sucesso",
        //        Data = _mapper.Map<GetFilialResponse>(response)
        //    });
        //}

        /// <summary>
        /// Deletes a user by their ID
        /// </summary>
        /// <param name="id">The unique identifier of the user to delete</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Success response if the user was deleted</returns>
        //[HttpDelete("{id}")]
        //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> DeleteUser([FromRoute] Guid id, CancellationToken cancellationToken)
        //{
        //    var request = new DeleteUserRequest { Id = id };
        //    var validator = new DeleteUserRequestValidator();
        //    var validationResult = await validator.ValidateAsync(request, cancellationToken);

        //    if (!validationResult.IsValid)
        //        return BadRequest(validationResult.Errors);

        //    var command = _mapper.Map<DeleteUserCommand>(request.Id);
        //    await _mediator.Send(command, cancellationToken);

        //    return Ok(new ApiResponse
        //    {
        //        Success = true,
        //        Message = "User deleted successfully"
        //    });
        //}
    }

}
