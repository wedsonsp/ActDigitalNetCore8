using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Vendas.GetVenda;

/// <summary>
/// Command for retrieving a sale by its ID
/// </summary>
public record GetVendaCommand : IRequest<GetVendaResult>
{
    /// <summary>
    /// The unique identifier of the sale to retrieve
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Initializes a new instance of GetVendaCommand
    /// </summary>
    /// <param name="id">The ID of the sale to retrieve</param>
    public GetVendaCommand(Guid id)
    {
        Id = id;
    }
}
