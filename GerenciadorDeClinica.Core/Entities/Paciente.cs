namespace GerenciadorDeClinica.Core.Entities
{
    public class Paciente : BaseEntity
    {
        public Paciente(string nome, string sobreNome, DateTime nascimento, string telefone, string email,
            string cPF, string endereco, string tipoSanguineo, double peso, double altura) : base()
        {
            Nome = nome;
            SobreNome = sobreNome;
            Nascimento = nascimento;
            Telefone = telefone;
            Email = email;
            CPF = cPF.Trim();
            Endereco = endereco;
            TipoSanguineo = tipoSanguineo;
            Peso = peso;
            Altura = altura;
            Atendimentos = [];


        }

        public string Nome { get; private set; }
        public string SobreNome { get; private set; }
        public DateTime Nascimento { get; private set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }
        public string CPF { get; private set; }
        public string Endereco { get; private set; }
        public string TipoSanguineo { get; private set; }
        public double Peso { get; private set; }
        public double Altura { get; private set; }
        public List<Atendimento> Atendimentos { get; private set; }
        //public Usuario? Usuario { get; private set; }




        public void UpdateUsuario(string telefone, string email, string endereco, double altura, double peso)
        {
            Telefone = telefone;
            Email = email;
            Endereco = endereco;
            Altura = altura;
            Peso = peso;
        }

  
    }
}
