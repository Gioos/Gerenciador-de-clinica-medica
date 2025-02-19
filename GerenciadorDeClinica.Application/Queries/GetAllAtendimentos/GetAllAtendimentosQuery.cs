using GerenciadorDeClinica.Application.Models.ViewModels;
using MediatR;

namespace GerenciadorDeClinica.Application.Queries.GetAllAtendimentos
{
    public class GetAllAtendimentosQuery : IRequest<ResultViewModel<List<AtendimentoViewModel>>>
    {
    }   
    

    
}
