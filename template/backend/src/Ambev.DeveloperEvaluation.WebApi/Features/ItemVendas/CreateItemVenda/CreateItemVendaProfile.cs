using AutoMapper;
using Ambev.DeveloperEvaluation.Application.ItemVendas.CreateItemVenda;

namespace Ambev.DeveloperEvaluation.WebApi.Features.ItemVendas.CreateItemVenda;

/// <summary>
/// Profile for mapping between Application and API CreateItemVenda responses
/// </summary>
public class CreateItemVendaProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateItemVenda feature
    /// </summary>
    public CreateItemVendaProfile()
    {
        CreateMap<CreateItemVendaRequest, CreateItemVendaCommand>();
        CreateMap<CreateItemVendaResult, CreateItemVendaResponse>();
    }
}
