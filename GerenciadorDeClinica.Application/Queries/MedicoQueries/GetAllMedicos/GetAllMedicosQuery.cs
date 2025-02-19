using GerenciadorDeClinica.Application.Models.ViewModels;
using MediatR;

namespace GerenciadorDeClinica.Application.Queries.MedicoQueries.GetAllMedicos
{
    public class GetAllMedicosQuery : IRequest<ResultViewModel<List<MedicoViewModel>>>
    {
    }
}
