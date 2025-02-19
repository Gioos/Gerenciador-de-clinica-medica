using GerenciadorDeClinica.Core.Entities;

namespace GerenciadorDeClinica.Application.Models.ViewModels
{
    public class MedicoViewModel
    {
        private int idMedico;
        private string nomeMedico;

        public MedicoViewModel(int idMedico, string nomeMedico)
        {
            this.idMedico = idMedico;
            this.nomeMedico = nomeMedico;
        }

        public MedicoViewModel(string nome, string especialidade, string crm, string telefone)
        {
            Nome = nome;
            Especialidade = especialidade;
            CRM = crm;
            Telefone = telefone;
        }

        public string Nome { get; private set; }
        public string Especialidade { get; private set; }
        public string CRM { get; private set; }
        public string Telefone { get; private set; }

        public static MedicoViewModel FromEntity(Medico entity)
            => new MedicoViewModel(entity.Nome, entity.Especialidade, entity.CRM, entity.Telefone);
    }
}
