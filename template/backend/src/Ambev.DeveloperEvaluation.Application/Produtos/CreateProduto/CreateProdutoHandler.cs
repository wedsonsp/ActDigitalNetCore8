using AutoMapper;
using FluentValidation;
using MediatR;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Application.Produtos.CreateProduto;
using System;
using System.Threading;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Application.Produtos.CreateProduto
{
    /// <summary>
    /// Handler for processing CreateProdutoCommand requests
    /// </summary>
    public class CreateProdutoHandler : IRequestHandler<CreateProdutoCommand, CreateProdutoResult>
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of CreateProdutoHandler
        /// </summary>
        /// <param name="produtoRepository">The product repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public CreateProdutoHandler(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the CreateProdutoCommand request
        /// </summary>
        /// <param name="command">The CreateProduto command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created product details</returns>
        public async Task<CreateProdutoResult> Handle(CreateProdutoCommand command, CancellationToken cancellationToken)
        {
            // Validate the command using the CreateProdutoCommandValidator
            var validator = new CreateProdutoCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            // Check if the product already exists by its name (if needed)
            var existingProduct = await _produtoRepository.GetByNameAsync(command.Nome, cancellationToken);
            if (existingProduct != null)
                throw new InvalidOperationException($"Produto com o nome {command.Nome} já existe.");

            // Map the command to the Produto entity
            var produto = _mapper.Map<Produto>(command);

            // Save the product to the repository
            var createdProduto = await _produtoRepository.CreateAsync(produto, cancellationToken);

            // Map the created product to the result
            var result = _mapper.Map<CreateProdutoResult>(createdProduto);

            return result;
        }
    }
}
