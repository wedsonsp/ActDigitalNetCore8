using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Filiais.CreateFilial;

namespace Ambev.DeveloperEvaluation.Application.Filiais.CreateFilial
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
            // Mapeamento de CreateFilialCommand para Filial
            CreateMap<CreateFilialCommand, Filial>();

            // Mapeamento de Filial para CreateFilialResult
            CreateMap<Filial, CreateFilialResult>();
        }
    }
}
