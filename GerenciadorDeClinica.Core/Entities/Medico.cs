namespace GerenciadorDeClinica.Core.Entities
{
    public class Medico : BaseEntity
    {
        public Medico(string nome, string sobreNome, DateTime nascimento, string telefone, string email,
            string cPF, string endereco, string tipoSanguineo, string especialidade, string cRM) : base()
        {
            
            Nome = nome;
            SobreNome = sobreNome;
            Nascimento = nascimento;
            Telefone = telefone;
            Email = email;
            CPF = cPF;
            Endereco = endereco;
            TipoSanguineo = tipoSanguineo;
            Especialidade = especialidade;
            CRM = cRM;
            Atendimentos = [];  
        }

        public string Nome { get; private set; }
        public string SobreNome  { get; private set; }
        public DateTime Nascimento { get; private set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }
        public string CPF { get; private set; }
        public string Endereco { get; private set; }
        public string TipoSanguineo { get; private set; }
        public string Especialidade { get; private set; }
        public string CRM { get; private set; }
        public List<Atendimento> Atendimentos { get; private set; }

        public void UpdateMedico(string telefone, string especialidade)
        {
            Telefone = telefone;
            Especialidade = especialidade;
        }

    }

}
