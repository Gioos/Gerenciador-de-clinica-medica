using GerenciadorDeClinica.Application.Models.ViewModels;
using GerenciadorDeClinica.Core.Repositories;
using MediatR;

namespace GerenciadorDeClinica.Application.Queries.MedicoQueries.GetMedicoById
{
    public class GetMedicoByIdHandler : IRequestHandler<GetMedicoByIdQuery, ResultViewModel<MedicoViewModel>>
    {
        private readonly IMedicoRepository _medicoRepository;

        public GetMedicoByIdHandler(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        public async Task<ResultViewModel<MedicoViewModel>> Handle(GetMedicoByIdQuery request, CancellationToken cancellationToken)
        {
           var medico = await _medicoRepository.GetById(request.Id);

            if (medico == null || medico.IsDeleted)
                return ResultViewModel<MedicoViewModel>.Error("Médico não encontrado");


            var model = MedicoViewModel.FromEntity(medico);

            return ResultViewModel<MedicoViewModel>.Success(model);
        }
    }
}
