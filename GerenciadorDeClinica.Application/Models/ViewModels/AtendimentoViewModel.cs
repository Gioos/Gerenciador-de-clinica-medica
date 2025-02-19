using GerenciadorDeClinica.Core.Entities;
namespace GerenciadorDeClinica.Application.Models.ViewModels
{
    public class AtendimentoViewModel
    {
        public AtendimentoViewModel(int id, string nomePaciente, string nomeMedico, int idPaciente, int idMedico,
            int idServico, string convenio, DateTime inicio, DateTime fim, string tipoAtendimento)
        {
            Id = id;
            NomePaciente = nomePaciente;
            NomeMedico = nomeMedico;
            IdPaciente = idPaciente;
            IdMedico = idMedico;
            IdServico = idServico;
            Convenio = convenio;
            Inicio = inicio;
            Fim = fim;
            TipoAtendimento = tipoAtendimento;
        }

        public int Id { get; private set; }
        public string  NomePaciente { get; private set; }
        public string NomeMedico { get; private set; }
        public int IdPaciente { get; private set; }
        public int IdMedico { get; private set; }
        public int IdServico { get; private set; }
        public string Convenio { get; private set; } = string.Empty;
        public DateTime Inicio { get; private set; }
        public DateTime Fim { get; private set; }
        public string TipoAtendimento { get; private set; }

        public static AtendimentoViewModel FromEntity (Atendimento entity)
            =>new AtendimentoViewModel(entity.Id,
                entity.Paciente?.Nome ?? string.Empty, 
                entity.Medico?.Nome ?? string.Empty,
                entity.IdPaciente, 
                entity.IdMedico,
                entity.IdServico,
                entity.Convenio, entity.Inicio,
                entity.Fim,
                entity.TipoAtendimento.ToString());
    }
}