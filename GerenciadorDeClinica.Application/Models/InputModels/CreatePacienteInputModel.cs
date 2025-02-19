namespace GerenciadorDeClinica.Application.Models.InputModels
{
    public class CreatePacienteInputModel
    {
        public string Nome { get;  set; } = "";
        public string SobreNome { get; set; } = "";
        public DateTime Nascimento { get; set; }
        public string Telefone { get; set; } = "";
        public string Email { get; set; } = "";
        public string CPF { get; set; } = "";
        public string Endereco { get; set; } = "";
        public string TipoSanguineo { get; set; } = "";         
        public double Peso { get; set; }
        public double Altura { get; set; }
    }
}
