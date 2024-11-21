using MediatR;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using FluentValidation.Results;
using System.Threading;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Vendas.DeleteVenda
{
    public class DeleteVendaHandler : IRequestHandler<DeleteVendaCommand, DeleteVendaResult>
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly DeleteVendaCommandValidator _validator;

        public DeleteVendaHandler(IVendaRepository vendaRepository)
        {
            _vendaRepository = vendaRepository;
            _validator = new DeleteVendaCommandValidator();  // Instanciando o validador
        }

        public async Task<DeleteVendaResult> Handle(DeleteVendaCommand request, CancellationToken cancellationToken)
        {
            // Validar o comando usando o FluentValidation
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
            {
                // Retorna um resultado indicando falha de validação
                return new DeleteVendaResult
                {
                    Success = false,
                    Message = validationResult.ToString() // Mensagem de erro gerada pela validação
                };
            }

            // Lógica de exclusão da venda
            var venda = await _vendaRepository.GetByIdAsync(request.Id);
            if (venda == null)
            {
                return new DeleteVendaResult
                {
                    Success = false,
                    Message = "Venda não encontrada"
                };
            }

            // Deleta a venda
            await _vendaRepository.DeleteAsync(request.Id);

            return new DeleteVendaResult
            {
                Success = true,
                Message = "Venda excluída com sucesso"
            };
        }
    }
}
