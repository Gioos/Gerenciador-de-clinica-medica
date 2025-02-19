using GerenciadorDeClinica.Application.Models.ViewModels;
using MediatR;

namespace GerenciadorDeClinica.Application.Queries.GetPacienteById
{
    public class GetPacienteByIdQuery : IRequest<ResultViewModel<PacienteViewModel>>
    {
        public GetPacienteByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; private set; }
    }
}
