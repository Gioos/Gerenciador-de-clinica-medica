using GerenciadorDeClinica.Application.Models.ViewModels;
using GerenciadorDeClinica.Core.Entities;
using MediatR;

namespace GerenciadorDeClinica.Application.Commands.AtendimentoCommands.InsertAtendimento
{
    public class InsertAtendimentoCommand : IRequest<ResultViewModel<int>>
    {
        public int IdMedico { get; set; }
        public int IdPaciente { get; set; }
        public int IdServico { get; set; }
        public string Convenio { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public int TipoAtendimento { get; set; }

        public Atendimento ToEntity()
            => new Atendimento(IdPaciente,
                IdMedico,
                IdServico,
                Convenio,
                Inicio,
                Fim,
                (Core.Enums.TipoAtendimentoEnum)TipoAtendimento);
    }
}
