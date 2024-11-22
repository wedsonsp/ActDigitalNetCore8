using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Vendas.UpdateVenda;

namespace Ambev.DeveloperEvaluation.Application.Vendas.UpdateVendas
{
    /// <summary>
    /// Profile for mapping between UpdateVenda command and Venda entity
    /// </summary>
    public class UpdateVendaProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for UpdateVenda operation
        /// </summary>
        public UpdateVendaProfile()
        {
            // Mapeamento do UpdateVendaCommand para a entidade Venda
            CreateMap<UpdateVendaCommand, Venda>()
                .ForMember(dest => dest.ItensVenda, opt => opt.Ignore()) // Ignoramos a lista de itens de venda, pois ela será tratada separadamente
                .ForMember(dest => dest.DataAlteracao, opt => opt.MapFrom(src => DateTime.UtcNow)); // Definimos o campo DataAlteracao como o horário atual

            // Mapeamento da entidade Venda para o resultado da atualização
            CreateMap<Venda, UpdateVendaResult>();
        }
    }
}
