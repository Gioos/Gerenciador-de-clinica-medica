using GerenciadorDeClinica.Application.Models.ViewModels;
using GerenciadorDeClinica.Core.Entities;
using MediatR;

namespace GerenciadorDeClinica.Application.Commands.MedicoCommands.InsertMedico
{
    public class InsertMedicoCommand : IRequest<ResultViewModel<int>>
    {
        public string Nome { get;  set; }
        public string SobreNome { get;  set; }
        public DateTime Nascimento { get; set; }
        public string Telefone { get;   set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string Endereco { get; set; }
        public string TipoSanguineo { get;  set; }
        public string Especialidade { get; set; }
        public string CRM { get; set; }

        public Medico ToEntity()
            => new Medico(Nome, SobreNome, Nascimento, Telefone, Email, CPF, Endereco, TipoSanguineo, Especialidade, CRM);
    }
}
