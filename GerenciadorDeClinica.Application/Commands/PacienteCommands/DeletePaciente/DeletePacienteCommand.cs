using GerenciadorDeClinica.Application.Models.ViewModels;
using MediatR;

namespace GerenciadorDeClinica.Application.Commands.PacienteCommands.DeletePaciente
{
    public class DeletePacienteCommand : IRequest<ResultViewModel>
    {
        public DeletePacienteCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
