using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Vendas.CreateVenda;

namespace Ambev.DeveloperEvaluation.Application.Vendas.CreateVenda
{
    /// <summary>
    /// Profile for mapping between Venda entity and CreateVendaCommand/Response.
    /// </summary>
    public class CreateVendaProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for CreateVenda operation.
        /// </summary>
        public CreateVendaProfile()
        {
            // Mapeia o comando para a entidade Venda
            CreateMap<CreateVendaCommand, Venda>();

            // Mapeia a entidade Venda para o resultado da criação de venda (CreateVendaResult)
            CreateMap<Venda, CreateVendaResult>();
        }
    }
}
