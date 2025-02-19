using GerenciadorDeClinica.Application.Models.ViewModels;
using MediatR;

namespace GerenciadorDeClinica.Application.Queries.ServicoQueries.GetServicoById
{
    public class GetServicoByIdQuery : IRequest<ResultViewModel<ServicoViewModel>>
    {
        public int Id { get; private set; }

        public GetServicoByIdQuery(int id)
        {
            Id = id;
        }
    }
}
