using GerenciadorDeClinica.Application.Models.ViewModels;
using MediatR;

namespace GerenciadorDeClinica.Application.Commands.RecuperarSenhaCommands
{
    public class RecuperarSenhaCommand : IRequest<ResultViewModel<int>>
    {
        public RecuperarSenhaCommand(string? email)
        {
            Email = email;
        }

        public string? Email { get; set; }
    }
}
