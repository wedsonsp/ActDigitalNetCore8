using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;
using System;

namespace Ambev.DeveloperEvaluation.Application.Vendas.GetVenda
{
    public class GetVendaByIdQuery : IRequest<Venda>
    {
        public Guid Id { get; }

        public GetVendaByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
