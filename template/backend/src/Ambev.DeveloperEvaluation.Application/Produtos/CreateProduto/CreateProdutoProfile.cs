using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Produtos.CreateProduto;

namespace Ambev.DeveloperEvaluation.Application.Users.CreateUser;

/// <summary>
/// Profile for mapping between Produto entity and CreateProdutoResponse
/// </summary>
public class CreateProdutoProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateUser operation
    /// </summary>
    public CreateProdutoProfile()
    {
        CreateMap<CreateProdutoCommand, Produto>();
        CreateMap<Produto, CreateUserResult>();
    }
}
