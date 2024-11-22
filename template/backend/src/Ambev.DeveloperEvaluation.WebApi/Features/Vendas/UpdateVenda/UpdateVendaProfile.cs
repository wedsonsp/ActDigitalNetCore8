using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Vendas.UpdateVenda;
using Newtonsoft.Json;
using Ambev.DeveloperEvaluation.Application.Vendas.UpdateVendas;

namespace Ambev.DeveloperEvaluation.Application.Vendas.UpdateVenda
{
    /// <summary>
    /// Profile for mapping between Venda entity and UpdateVendaResult
    /// </summary>
    public class UpdateVendaProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for UpdateVenda operation
        /// </summary>
        public UpdateVendaProfile()
        {
            // Mapeia de UpdateVendaCommand para Venda (atualizando os dados de Venda)
            CreateMap<UpdateVendaCommand, Venda>()
                .ForMember(dest => dest.DataAlteracao, opt => opt.MapFrom(src => DateTime.UtcNow)); // Atualiza a data de alteração

            // Mapeia de Venda para UpdateVendaResult (retorna os dados atualizados)
            CreateMap<Venda, UpdateVendaResult>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.NumeroVenda, opt => opt.MapFrom(src => src.NumeroVenda))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.DataAlteracao, opt => opt.MapFrom(src => src.DataAlteracao));
        }
    }
}
