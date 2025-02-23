using GerenciadorDeClinica.Application.Models.ViewModels;
using MediatR;

namespace GerenciadorDeClinica.Application.Queries.PacienteQueries.GetPacienteByCpf
{
    public class GetPacienteByCpfQuery : IRequest<ResultViewModel<PacienteViewModel>>
    {
        public GetPacienteByCpfQuery(string cpf)
        {
            Cpf = cpf;
        }
        public string Cpf { get; private set; }
    }
}
