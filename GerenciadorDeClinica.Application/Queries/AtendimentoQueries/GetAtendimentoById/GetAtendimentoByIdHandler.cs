using GerenciadorDeClinica.Application.Models.ViewModels;
using GerenciadorDeClinica.Core.Repositories;
using MediatR;

namespace GerenciadorDeClinica.Application.Queries.AtendimentoQueries.GetAtendimentoById
{
    public class GetAtendimentoByIdHandler : IRequestHandler<GetAtendimentoByIdQuery, ResultViewModel<AtendimentoViewModel>>
    {
        private readonly IAtendimentoRepository _atendimentoRepository;

        public GetAtendimentoByIdHandler(IAtendimentoRepository atendimentoRepository)
        {
            _atendimentoRepository = atendimentoRepository;
        }

        public async Task<ResultViewModel<AtendimentoViewModel>> Handle(GetAtendimentoByIdQuery request, CancellationToken cancellationToken)
        {
            var atendimento = await _atendimentoRepository.GetById(request.Id);

            if (atendimento == null || atendimento.IsDeleted)
                return ResultViewModel<AtendimentoViewModel>.Error("Atendimento não encontrado");


            var model = AtendimentoViewModel.FromEntity(atendimento);

            return ResultViewModel<AtendimentoViewModel>.Success(model);
        }
    }
}
