using GerenciadorDeClinica.Application.Models.ViewModels;
using MediatR;

namespace GerenciadorDeClinica.Application.Commands.MedicoCommands.UpdateMedico
{
    public class UpdateMedicoCommand : IRequest<ResultViewModel>
    {
        public int IdMedico { get; set; }
        public string Telefone { get; set; }
        public string Especialidade { get; set; }
        
    }
}
