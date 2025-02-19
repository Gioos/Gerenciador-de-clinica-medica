using GerenciadorDeClinica.Application.Models.ViewModels;
using GerenciadorDeClinica.Core.Repositories;
using MediatR;

namespace GerenciadorDeClinica.Application.Queries.GetAllAtendimentos
{
    public class GetAllAtendimentosHandler : IRequestHandler<GetAllAtendimentosQuery, ResultViewModel<List<AtendimentoViewModel>>>  
    {
        private readonly IAtendimentoRepository _atendimentoRepository;

        public GetAllAtendimentosHandler(IAtendimentoRepository atendimentoRepository)
        {
            _atendimentoRepository = atendimentoRepository;
        }
        public async Task<ResultViewModel<List<AtendimentoViewModel>>> Handle(GetAllAtendimentosQuery request, CancellationToken cancellationToken)
        {
            var atendimentos = await _atendimentoRepository.GetAll();

            var model = atendimentos.Select(AtendimentoViewModel.FromEntity).ToList();

            return ResultViewModel<List<AtendimentoViewModel>>.Success(model);
        }
    }
}
