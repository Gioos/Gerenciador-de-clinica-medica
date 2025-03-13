using GerenciadorDeClinica.Application.Models.ViewModels;
using GerenciadorDeClinica.Core.Entities;
using MediatR;

namespace GerenciadorDeClinica.Application.Commands.UsuarioCommands
{
    public class AdicionarUsuarioCommand : IRequest<ResultViewModel<int>>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public AdicionarUsuarioCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }

    }
}
