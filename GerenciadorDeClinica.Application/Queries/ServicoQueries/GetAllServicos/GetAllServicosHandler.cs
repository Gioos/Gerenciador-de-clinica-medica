using GerenciadorDeClinica.Application.Models.ViewModels;
using GerenciadorDeClinica.Core.Repositories;
using MediatR;

namespace GerenciadorDeClinica.Application.Queries.ServicoQueries.GetAllServicos
{
    public class GetAllServicosHandler : IRequestHandler<GetAllServicosQuery, ResultViewModel<List<ServicoViewModel>>>
    {
        private readonly IServicoRepository _servicoRepository;

        public GetAllServicosHandler(IServicoRepository servicoRepository)
        {
            _servicoRepository = servicoRepository;
        }

        public async Task<ResultViewModel<List<ServicoViewModel>>> Handle(GetAllServicosQuery request, CancellationToken cancellationToken)
        {
            var servicos = await _servicoRepository.GetAll();

            var model = servicos.Select(ServicoViewModel.FromEntity).ToList();

            return ResultViewModel<List<ServicoViewModel>>.Success(model);
        }
    }
}
