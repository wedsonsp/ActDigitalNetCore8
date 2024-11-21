using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Vendas.DeleteVenda;

namespace Ambev.DeveloperEvaluation.Application.Vendas.DeleteVenda
{
    /// <summary>
    /// Profile for mapping between Venda entity and DeleteVendaResult
    /// </summary>
    public class DeleteVendaProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for DeleteVenda operation
        /// </summary>
        public DeleteVendaProfile()
        {
            // Mapeia de Venda para DeleteVendaResult
            CreateMap<Venda, DeleteVendaResult>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Success, opt => opt.MapFrom(src => true)) // Assuming success for deletion
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => "Venda excluída com sucesso."));
        }
    }
}
