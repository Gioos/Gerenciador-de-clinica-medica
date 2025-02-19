using GerenciadorDeClinica.Application.Models.ViewModels;
using MediatR;

namespace GerenciadorDeClinica.Application.Queries.MedicoQueries.GetMedicoById
{
    public class GetMedicoByIdQuery : IRequest<ResultViewModel<MedicoViewModel>>
    {
        public GetMedicoByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
