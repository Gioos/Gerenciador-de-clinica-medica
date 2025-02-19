using GerenciadorDeClinica.Application.Models.ViewModels;
using GerenciadorDeClinica.Core.Repositories;
using MediatR;

namespace GerenciadorDeClinica.Application.Commands.ServicoCommands.InsertServico
{
    public class InsertServicoHandler : IRequestHandler<InsertServicoCommand, ResultViewModel<int>>
    {
        private readonly IServicoRepository _servicoRepository;

        public InsertServicoHandler(IServicoRepository servicoRepository)
        {
            _servicoRepository = servicoRepository;
        }


        public async Task<ResultViewModel<int>> Handle(InsertServicoCommand request, CancellationToken cancellationToken)
        {
            var servico = request.ToEntity();

            await _servicoRepository.Add(servico);

            return ResultViewModel<int>.Success(servico.Id);
        }
    }
    
    
}
