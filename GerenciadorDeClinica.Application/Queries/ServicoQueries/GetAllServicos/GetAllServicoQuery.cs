using GerenciadorDeClinica.Application.Models.ViewModels;
using GerenciadorDeClinica.Core.Entities;
using MediatR;

namespace GerenciadorDeClinica.Application.Queries.ServicoQueries.GetAllServicos
{
    public class GetAllServicosQuery : IRequest<ResultViewModel<List<ServicoViewModel>>>
    {
    }
}
