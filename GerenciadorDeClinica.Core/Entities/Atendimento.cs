using GerenciadorDeClinica.Core.Enums;

namespace GerenciadorDeClinica.Core.Entities
{
    public class Atendimento : BaseEntity
    {
        protected Atendimento() { }
        public Atendimento(int idPaciente, int idMedico, int idServico, string convenio, DateTime inicio, DateTime fim, TipoAtendimentoEnum tipoAtendimento)
            : base()
        {
            IdPaciente = idPaciente;
            IdMedico = idMedico;
            IdServico = idServico;
            Convenio = convenio;
            Inicio = inicio;
            Fim = fim;
            TipoAtendimento = tipoAtendimento;
            Atendimentos = [];
        }

        public  int IdPaciente { get; private set; }
        public int IdMedico { get; private set; }
        public int IdServico { get; private set; }
        public string Convenio { get; private set; } = string.Empty;
        public DateTime Inicio { get; private set; }
        public DateTime Fim { get; private set; }
        public TipoAtendimentoEnum TipoAtendimento { get; private set; }
        public Paciente? Paciente { get; private set; }
        public Medico? Medico { get; private set; }
        public Servico? Servico { get; private set; }
        public List<Atendimento> Atendimentos { get; private set; }

        public void InicioAtendimento()
        {
            Inicio = DateTime.Now;
        }

        public void FimAtendimento()
        {
            Fim = DateTime.Now;
        }

        public void Update (string convenio)
        {
            Convenio = convenio;
        }
    }
}
