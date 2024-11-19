using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Vendas.CreateVenda;
using Newtonsoft.Json;

namespace Ambev.DeveloperEvaluation.Application.Vendas.CreateVenda
{
    /// <summary>
    /// Profile for mapping between Venda entity and CreateVendaResponse
    /// </summary>
    public class CreateVendaProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for CreateVenda operation
        /// </summary>
        public CreateVendaProfile()
        {
            // Mapeia de CreateVendaCommand para Venda
            CreateMap<CreateVendaCommand, Venda>();  // Serializa os itens da venda para JSON

            // Mapeia de Venda para CreateVendaResult
            CreateMap<Venda, CreateVendaResult>();  // Mapeia o NumeroVenda para o CreateVendaResult
        }
    }
}
