using GerenciadorDeClinica.Application.Models.ViewModels;
using MediatR;

namespace GerenciadorDeClinica.Application.Commands.NovaSenhaCommands
{
    public class NovaSenhaCommand : IRequest<ResultViewModel<int>>
    {
        public NovaSenhaCommand(string email, string senha, string novaSenha)
        {
            Email = email;
            Senha = senha;
            NovaSenha = novaSenha;
        }

        public string Email { get; set; }
        public string Senha { get; set; }
        public string NovaSenha { get; set; }
    }
}
