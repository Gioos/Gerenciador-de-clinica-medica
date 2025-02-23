using GerenciadorDeClinica.Application.Models.ViewModels;
using MediatR;

namespace GerenciadorDeClinica.Application.Commands.AtendimentoCommands.UpdateAtendimento
{
    public class UpdateAtendimentoCommand : IRequest<ResultViewModel>
    {
        public int IdAtendimento { get; set; }

        public string Convenio { get; set; }

    }
}
