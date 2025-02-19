using GerenciadorDeClinica.Application.Models.ViewModels;
using MediatR;

namespace GerenciadorDeClinica.Application.Commands.ServicoCommands.DeleteServico
{
    public class DeleteServicoCommand : IRequest<ResultViewModel>
    {
        public DeleteServicoCommand(int id)
        {
            Id = id;
        }
        public int Id { get; private set; }
    }
}
