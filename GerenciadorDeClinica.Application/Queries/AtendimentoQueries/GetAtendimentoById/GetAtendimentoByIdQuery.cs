using GerenciadorDeClinica.Application.Models.ViewModels;
using MediatR;

namespace GerenciadorDeClinica.Application.Queries.AtendimentoQueries.GetAtendimentoById
{
    public class GetAtendimentoByIdQuery : IRequest<ResultViewModel<AtendimentoViewModel>>
    {
        public GetAtendimentoByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; private set; }
    }
}
