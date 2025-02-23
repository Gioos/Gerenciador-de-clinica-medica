using GerenciadorDeClinica.Application.Models.ViewModels;
using GerenciadorDeClinica.Core.Entities;
using MediatR;

namespace GerenciadorDeClinica.Application.Commands.PacienteCommands.InsertPaciente
{
    public class InsertPacienteCommand : IRequest<ResultViewModel<int>>
    {
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public DateTime Nascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string Endereco { get; set; }
        public string TipoSanguineo { get; set; }
        public double Peso { get; set; }
        public double Altura { get; set; }

        public Paciente ToEntity()
            => new Paciente(Nome, SobreNome, Nascimento, Telefone, Email, CPF, Endereco, TipoSanguineo, Peso, Altura);
    }
}
