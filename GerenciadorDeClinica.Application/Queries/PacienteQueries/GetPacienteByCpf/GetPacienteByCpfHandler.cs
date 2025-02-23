using GerenciadorDeClinica.Application.Models.ViewModels;
using GerenciadorDeClinica.Core.Repositories;
using MediatR;

namespace GerenciadorDeClinica.Application.Queries.PacienteQueries.GetPacienteByCpf
{
    public class GetPacienteByCpfHandler : IRequestHandler<GetPacienteByCpfQuery, ResultViewModel<PacienteViewModel>>
    {
        private readonly IPacienteRepository _pacienteRepository;

        public GetPacienteByCpfHandler(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }
        public async Task<ResultViewModel<PacienteViewModel>> Handle(GetPacienteByCpfQuery request, CancellationToken cancellationToken)
        {
            var paciente = await _pacienteRepository.GetByCpf(request.Cpf);

            if (paciente == null || paciente.IsDeleted)
                return ResultViewModel<PacienteViewModel>.Error("Paciente não encontrado");

            var model = PacienteViewModel.FromEntity(paciente);

            return ResultViewModel<PacienteViewModel>.Success(model);
        }
    }
}
