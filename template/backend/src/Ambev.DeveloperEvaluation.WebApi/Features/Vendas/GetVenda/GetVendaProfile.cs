using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Vendas.GetVenda;


/// <summary>
/// Profile for mapping GetVenda feature requests to commands
/// </summary>
public class GetVendaProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetVenda feature
    /// </summary>
    public GetVendaProfile()
    {
        // Mapeamento do Guid (ID da venda) para o comando GetVendaCommand
        CreateMap<Guid, Application.Vendas.GetVenda.GetVendaCommand>()
            .ConstructUsing(id => new Application.Vendas.GetVenda.GetVendaCommand(id));
    }
}
