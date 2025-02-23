using GerenciadorDeClinica.Application.Models.ViewModels;
using MediatR;

namespace GerenciadorDeClinica.Application.Commands.PacienteCommands.UpdatePaciente
{
    public class UpdatePacienteCommand : IRequest<ResultViewModel>
    {
        public int IdPaciente { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public double Altura { get; set; }
        public double Peso { get; set; }


    }
}
