using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Filiais.CreateFilial;
using Ambev.DeveloperEvaluation.Application.Filiais;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Filiais.CreateFilial
{
    /// <summary>
    /// Profile for mapping between Filial entity and CreateFilialResponse
    /// </summary>
    public class CreateFilialProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for CreateFilial operation
        /// </summary>
        public CreateFilialProfile()
        {
            // Mapeia de CreateFilialCommand para Filial
            CreateMap<CreateFilialCommand, Filial>();

            // Mapeia de Filial para CreateFilialResult
            CreateMap<Filial, CreateFilialResult>();
        }
    }
}
