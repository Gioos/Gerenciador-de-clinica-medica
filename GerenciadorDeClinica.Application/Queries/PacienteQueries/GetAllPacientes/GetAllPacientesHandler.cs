using GerenciadorDeClinica.Application.Models.ViewModels;
using GerenciadorDeClinica.Core.Repositories;
using MediatR;

namespace GerenciadorDeClinica.Application.Queries.PacienteQueries.GetAllPacientes
{
    public class GetAllPacientesHandler : IRequestHandler<GetAllPacientesQuery, ResultViewModel<List<PacienteViewModel>>>
    {
        private readonly IPacienteRepository _pacienteRepository;

        public GetAllPacientesHandler(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        public async Task<ResultViewModel<List<PacienteViewModel>>> Handle(GetAllPacientesQuery request, CancellationToken cancellationToken)
        {
            var pacientes = await _pacienteRepository.GetAll();

            var model = pacientes.Select(PacienteViewModel.FromEntity).ToList();

            return ResultViewModel<List<PacienteViewModel>>.Success(model);
        }
    }
}
