using GerenciadorDeClinica.Application.Models.ViewModels;
using MediatR;

namespace GerenciadorDeClinica.Application.Commands.MedicoCommands.DeleteMedico
{
    public class DeleteMedicoCommand : IRequest<ResultViewModel>
    {
        public DeleteMedicoCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
