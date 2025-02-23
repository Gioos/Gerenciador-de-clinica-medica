using GerenciadorDeClinica.Application.Models.ViewModels;
using MediatR;

namespace GerenciadorDeClinica.Application.Queries.PacienteQueries.GetAllPacientes
{
    public class GetAllPacientesQuery : IRequest<ResultViewModel<List<PacienteViewModel>>>
    {
    }
}
