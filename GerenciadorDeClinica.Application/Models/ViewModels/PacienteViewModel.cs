using GerenciadorDeClinica.Core.Entities;

namespace GerenciadorDeClinica.Application.Models.ViewModels
{
    public class PacienteViewModel
    {
        private int idPaciente;
        private string nomePaciente;

        public PacienteViewModel(int idPaciente, string nomePaciente)
        {
            this.idPaciente = idPaciente;
            this.nomePaciente = nomePaciente;
        }

        public PacienteViewModel(int id, string nome, string sobreNome, string tipoSanquineo, List<Atendimento> atendimentos)
        {
            Id = id;
            Nome = nome;
            SobreNome = sobreNome;
            TipoSanquineo = tipoSanquineo;
           // Atendimentos = atendimentos;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string SobreNome { get; private set; }
        public string TipoSanquineo { get; private set; }
        //public List<Atendimento> Atendimentos { get; private set; }

        public static PacienteViewModel FromEntity(Paciente entity)
            => new PacienteViewModel(entity.Id, entity.Nome, entity.SobreNome, entity.TipoSanguineo, entity.Atendimentos);
    }
}
