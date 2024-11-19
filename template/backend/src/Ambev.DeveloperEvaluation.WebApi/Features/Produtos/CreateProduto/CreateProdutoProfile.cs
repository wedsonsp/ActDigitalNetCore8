using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Produtos.CreateProduto;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Produtos.CreateProduto
{
    /// <summary>
    /// Profile for mapping between Application and API CreateProduto requests and responses
    /// </summary>
    public class CreateProdutoProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for CreateProduto feature
        /// </summary>
        public CreateProdutoProfile()
        {
            // Mapeia o CreateProdutoRequest para o CreateProdutoCommand
            CreateMap<CreateProdutoRequest, CreateProdutoCommand>();

            // Mapeia o Produto (entidade) para o CreateProdutoResult
            CreateMap<Produto, CreateProdutoResult>();
        }
    }
}
