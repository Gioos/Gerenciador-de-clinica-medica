using GerenciadorDeClinica.Application.Models.ViewModels;
using GerenciadorDeClinica.Core.Repositories;
using MediatR;

namespace GerenciadorDeClinica.Application.Queries.MedicoQueries.GetAllMedicos
{
    public class GetAllMedicosHandler : IRequestHandler<GetAllMedicosQuery, ResultViewModel<List<MedicoViewModel>>>
    {
        private readonly IMedicoRepository _medicoRepository;

        public GetAllMedicosHandler(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        public async Task<ResultViewModel<List<MedicoViewModel>>> Handle(GetAllMedicosQuery request, CancellationToken cancellationToken)
        {
            var medicos = await _medicoRepository.GetAll();

            var model = medicos.Select(MedicoViewModel.FromEntity).ToList();

            return ResultViewModel<List<MedicoViewModel>>.Success(model);


        }
    }
}
