using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.ItemVendas.CreateItemVenda;

namespace Ambev.DeveloperEvaluation.Application.ItemVendas.CreateItemVenda
{
    /// <summary>
    /// Profile for mapping between ItemVenda entity and CreateItemVendaResponse
    /// </summary>
    public class CreateItemVendaProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for CreateItemVenda operation
        /// </summary>
        public CreateItemVendaProfile()
        {
            // Mapeia o comando de criação de item de venda para a entidade ItemVenda
            CreateMap<CreateItemVendaCommand, ItemVenda>();

            // Mapeia a entidade ItemVenda para a resposta desejada, se necessário
            // Por exemplo, se você precisar retornar algo como CreateItemVendaResult ou CreateItemVendaResponse
            CreateMap<ItemVenda, CreateItemVendaResult>();  // Substitua por CreateItemVendaResponse, se for o caso
        }
    }
}
