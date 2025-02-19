using GerenciadorDeClinica.Application.Models.ViewModels;
using GerenciadorDeClinica.Core.Repositories;
using MediatR;

namespace GerenciadorDeClinica.Application.Queries.ServicoQueries.GetServicoById
{
    public class GetServicoByIdHandler : IRequestHandler<GetServicoByIdQuery, ResultViewModel<ServicoViewModel>>
    {
        private readonly IServicoRepository _servicoRepository;

        public GetServicoByIdHandler(IServicoRepository servicoRepository)
        {
            _servicoRepository = servicoRepository;
        }

        public async Task<ResultViewModel<ServicoViewModel>> Handle(GetServicoByIdQuery request, CancellationToken cancellationToken)
        {
            var servico = await _servicoRepository.GetById(request.Id);

            if (servico == null)
                return ResultViewModel<ServicoViewModel>.Error("Serviço não encontrado");
            if (servico.IsDeleted)
                return ResultViewModel<ServicoViewModel>.Error("Serviço excluído");

            var model = ServicoViewModel.FromEntity(servico);

            return ResultViewModel<ServicoViewModel>.Success(model);
        }
    }
}
