using MediatR;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Vendas.GetVenda
{
    /// <summary>
    /// Handler for processing GetVendaByIdQuery requests
    /// </summary>
    public class GetVendaByIdHandler : IRequestHandler<GetVendaByIdQuery, Venda>
    {
        private readonly IVendaRepository _vendaRepository;

        public GetVendaByIdHandler(IVendaRepository vendaRepository)
        {
            _vendaRepository = vendaRepository;
        }

        public async Task<Venda> Handle(GetVendaByIdQuery request, CancellationToken cancellationToken)
        {
            // Buscar a venda no repositório usando o ID
            var venda = await _vendaRepository.GetByIdAsync(request.Id, cancellationToken);
            return venda;
        }
    }
}
