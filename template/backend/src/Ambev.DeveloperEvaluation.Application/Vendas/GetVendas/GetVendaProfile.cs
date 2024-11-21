using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Vendas.GetVenda;

namespace Ambev.DeveloperEvaluation.Application.Vendas.GetVenda
{
    /// <summary>
    /// Profile for mapping between Venda entity and GetVendaResult
    /// </summary>
    public class GetVendaProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for GetVenda operation
        /// </summary>
        public GetVendaProfile()
        {
            // Mapeia a entidade Venda para GetVendaResult
            CreateMap<Venda, GetVendaResult>();
                //.ForMember(dest => dest.ItensVenda, opt => opt.MapFrom(src => src.Itens))
                //.ForMember(dest => dest.ValorTotal, opt => opt.MapFrom(src => src.Itens.Sum(item => item.Quantidade * item.PrecoUnitario)))
                //.ForMember(dest => dest.Desconto, opt => opt.MapFrom(src => src.Desconto)); // Se houver desconto
        }
    }
}
