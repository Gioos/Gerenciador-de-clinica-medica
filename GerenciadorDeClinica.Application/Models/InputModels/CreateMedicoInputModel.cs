namespace GerenciadorDeClinica.Application.Models.InputModels
{
    public class CreateMedicoInputModel
    {
        public string Nome { get;  set; }
        public string SobreNome { get;  set; }
        public DateTime Nascimento { get; set; }
        public string Telefone { get; private set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string Endereco { get; set; }
        public string TipoSanguineo { get;  set; }
        public string Especialidade { get;  set; }
        public string CRM { get; set; }
    }
}
