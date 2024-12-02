using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.Application.Vendas.CreateVenda;
using Ambev.DeveloperEvaluation.WebApi.Features.Vendas.CreateVenda;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.WebApi.Features.Vendas.GetVenda;
using Ambev.DeveloperEvaluation.Application.Vendas.GetVenda;
using Ambev.DeveloperEvaluation.Application.Vendas.DeleteVenda;
using Ambev.DeveloperEvaluation.Application.Vendas.UpdateVenda;
using Ambev.DeveloperEvaluation.WebApi.Features.Vendas.UpdateVenda;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Vendas
{
    /// <summary>
    /// Controller for managing sale operations.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class VendasController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of VendasController.
        /// </summary>
        /// <param name="mediator">The mediator instance</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public VendasController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Creates a new sale.
        /// </summary>
        /// <param name="request">The sale creation request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created sale details</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseWithData<CreateVendaResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateVenda([FromBody] CreateVendaRequest request, CancellationToken cancellationToken)
        {
            // Validação da requisição
            var validator = new CreateVendaRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                var errorDetails = validationResult.Errors
                    .Select(e => (ValidationErrorDetail)e)
                    .ToList();

                return BadRequest(new ApiResponse
                {
                    Success = false,
                    Message = "Request validation failed",
                    Errors = errorDetails
                });
            }

            // Mapeamento do comando
            CreateVendaCommand command;
            try
            {
                command = _mapper.Map<CreateVendaCommand>(request);

                // Garantir que os itens sejam únicos (sem duplicação)
                command.ItensVenda = command.ItensVenda.ToList();

                // Atribuindo corretamente NomeProduto
                foreach (var item in command.ItensVenda)
                {
                    item.NomeProduto = request.ItensVenda
                        .FirstOrDefault(i => i.IdProduto == item.IdProduto)?
                        .NomeProduto;
                }

                // Calcular os valores de cada item
                foreach (var item in command.ItensVenda)
                {
                    item.ValorTotal = item.Quantidade * item.PrecoUnitario;
                }

                // Calcular o valor total da venda
                command.ValorTotalVenda = command.ItensVenda.Sum(item => item.ValorTotal);
            }
            catch (AutoMapperMappingException ex)
            {
                return BadRequest(new ApiResponse
                {
                    Success = false,
                    Message = "AutoMapper mapping failed",
                    Errors = new[] { new ValidationErrorDetail { Error = "AutoMapper", Detail = ex.Message } }
                });
            }

            // Envio do comando
            var response = await _mediator.Send(command, cancellationToken);

            if (response == null)
            {
                return BadRequest(new ApiResponse
                {
                    Success = false,
                    Message = "Sale creation failed"
                });
            }

            return Created(string.Empty, new ApiResponseWithData<CreateVendaResponse>
            {
                Success = true,
                Message = "Sale created successfully",
                Data = _mapper.Map<CreateVendaResponse>(response)
            });
        }



        /// <summary>
        /// Gets the sale by its unique identifier (id).
        /// </summary>
        /// <param name="id">The unique identifier of the sale</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The sale details along with its items</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponseWithData<CreateVendaResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetVendaByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            // Recupera a venda pelo ID, incluindo os itens
            var venda = await _mediator.Send(new GetVendaByIdQuery(id), cancellationToken);

            if (venda == null)
            {
                return NotFound(new ApiResponse
                {
                    Success = false,
                    Message = "Sale not found"
                });
            }

            // Retorna a venda com os itens
            var vendaResponse = _mapper.Map<CreateVendaResponse>(venda);
            return Ok(new ApiResponseWithData<CreateVendaResponse>
            {
                Success = true,
                Message = "Sale found successfully",
                Data = vendaResponse
            });
        }

        //[HttpGet("{id}")]
        //[ProducesResponseType(typeof(ApiResponseWithData<GetVendaResponse>), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> GetVenda([FromRoute] Guid id, CancellationToken cancellationToken)
        //{
        //    var request = new GetVendaRequest { Id = id };
        //    var validator = new GetVendaRequestValidator();
        //    var validationResult = await validator.ValidateAsync(request, cancellationToken);

        //    if (!validationResult.IsValid)
        //        return BadRequest(validationResult.Errors);

        //    var command = _mapper.Map<GetVendaCommand>(request.Id);
        //    var response = await _mediator.Send(command, cancellationToken);

        //    return Ok(new ApiResponseWithData<GetVendaResponse>
        //    {
        //        Success = true,
        //        Message = "Client retrieved successfully",
        //        Data = _mapper.Map<GetVendaResponse>(response)
        //    });
        //}

        /// <summary>
        /// Retrieves a sale by its ID
        /// </summary>
        /// <param name="id">The unique identifier of the sale</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The sale details if found</returns>
        [HttpGet("details/{id}")]
        [ProducesResponseType(typeof(ApiResponseWithData<GetVendaResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetVenda([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            // Criando a requisição para obter a venda
            var request = new GetVendaRequest { Id = id };

            // Validação da requisição
            var validator = new GetVendaRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            // Mapeando para o comando GetVendaCommand
            var command = _mapper.Map<GetVendaCommand>(request.Id);

            // Enviando o comando e aguardando a resposta
            var response = await _mediator.Send(command, cancellationToken);

            // Retornando a resposta com os dados da venda
            return Ok(new ApiResponseWithData<GetVendaResponse>
            {
                Success = true,
                Message = "Sale retrieved successfully",
                Data = _mapper.Map<GetVendaResponse>(response)
            });
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteVenda([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var command = new DeleteVendaCommand { Id = id };
            var response = await _mediator.Send(command, cancellationToken);

            if (response == null)
                return NotFound(new ApiResponse
                {
                    Success = false,
                    Message = "Sale not found"
                });

            return Ok(new ApiResponse
            {
                Success = true,
                Message = "Sale deleted successfully"
            });
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(typeof(ApiResponseWithData<UpdateVendaResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateVenda(Guid id, [FromBody] UpdateVendaRequest request, CancellationToken cancellationToken)
        {
            // Validação da requisição
            var validator = new UpdateVendaRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                var errorDetails = validationResult.Errors
                    .Select(e => (ValidationErrorDetail)e)
                    .ToList();

                return BadRequest(new ApiResponse
                {
                    Success = false,
                    Message = "Request validation failed",
                    Errors = errorDetails
                });
            }

            // Verificando se a venda existe
            var existingVenda = await _mediator.Send(new GetVendaByIdQuery(id), cancellationToken);  // Envio da consulta
            if (existingVenda == null)
            {
                return NotFound(new ApiResponse
                {
                    Success = false,
                    Message = "Sale not found"
                });
            }

            // Apenas o campo 'status' será atualizado
            if (request.Status != null)
            {
                existingVenda.Status = request.Status; // Atualiza o campo 'status'
            }
            else
            {
                return BadRequest(new ApiResponse
                {
                    Success = false,
                    Message = "'Status' field is required"
                });
            }

            // Mapeando o request para o comando de atualização
            UpdateVendaCommand command = _mapper.Map<UpdateVendaCommand>(existingVenda); // Usando os dados existentes para garantir a integridade dos outros campos
            command.Id = id; // Garantir que o ID da venda seja o correto para a atualização

            // Enviando o comando para realizar a atualização
            var response = await _mediator.Send(command, cancellationToken);

            if (response == null)
            {
                return BadRequest(new ApiResponse
                {
                    Success = false,
                    Message = "Sale update failed"
                });
            }

            // Retorna a resposta com os dados atualizados
            return Ok(new ApiResponseWithData<UpdateVendaResponse>
            {
                Success = true,
                Message = "Sale updated successfully",
                Data = _mapper.Map<UpdateVendaResponse>(response)
            });
        }



    }
}
