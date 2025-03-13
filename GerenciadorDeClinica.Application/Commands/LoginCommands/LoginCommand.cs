using GerenciadorDeClinica.Application.Models.InputModels;
using GerenciadorDeClinica.Application.Models.ViewModels;
using GerenciadorDeClinica.Core.Entities;
using MediatR;

namespace GerenciadorDeClinica.Application.Commands.LoginCommands
{
    public class LoginCommand : IRequest<ResultViewModel<LoginViewModel>>
    {
        public LoginCommand(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }

        public string Email { get; set; }
        public string Senha { get; set; }

       
    }
}
