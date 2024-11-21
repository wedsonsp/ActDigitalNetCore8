using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Vendas.DeleteVenda;

namespace Ambev.DeveloperEvaluation.Application.Vendas.DeleteVenda
{
    /// <summary>
    /// Profile for mapping between DeleteVendaCommand and Venda entity
    /// </summary>
    public class DeleteVendaProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for DeleteVenda operation
        /// </summary>
        public DeleteVendaProfile()
        {
            // Define o mapeamento do comando DeleteVendaCommand para a entidade Venda
            CreateMap<DeleteVendaCommand, Venda>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)); // Mapeia o ID da venda

            //CreateMap<Venda, DeleteVendaResult>();
        }
    }
}
