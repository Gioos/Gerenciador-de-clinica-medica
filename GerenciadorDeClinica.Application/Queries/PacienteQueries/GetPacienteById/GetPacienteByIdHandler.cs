using GerenciadorDeClinica.Application.Models.ViewModels;
using GerenciadorDeClinica.Core.Repositories;
using MediatR;

namespace GerenciadorDeClinica.Application.Queries.PacienteQueries.GetPacienteById
{
    public class GetPacienteByIdHandler : IRequestHandler<GetPacienteByIdQuery, ResultViewModel<PacienteViewModel>>
    {
        private readonly IPacienteRepository _pacienteRepository;

        public GetPacienteByIdHandler(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;

        }

        public async Task<ResultViewModel<PacienteViewModel>> Handle(GetPacienteByIdQuery request, CancellationToken cancellationToken)
        {
            var paciente = await _pacienteRepository.GetById(request.Id);

            if (paciente == null || paciente.IsDeleted)
                return ResultViewModel<PacienteViewModel>.Error("Paciente não encontrado");

            var model = PacienteViewModel.FromEntity(paciente);

            return ResultViewModel<PacienteViewModel>.Success(model);

        }
    }
}
