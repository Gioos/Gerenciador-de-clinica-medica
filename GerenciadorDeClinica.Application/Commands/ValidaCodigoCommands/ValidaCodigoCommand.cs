using GerenciadorDeClinica.Application.Models.ViewModels;
using MediatR;

namespace GerenciadorDeClinica.Application.Commands.ValidaCodigoCommands
{
    public class ValidaCodigoCommand : IRequest<ResultViewModel<int>>
    {
        public string Email { get; set; }
        public string Code { get; set; }

        public ValidaCodigoCommand(string email, string code)
        {
            Email = email;
            Code = code;
        }


    }
}
