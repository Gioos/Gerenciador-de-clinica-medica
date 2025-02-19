
namespace GerenciadorDeClinica.Core.Entities
{
    public class Servico : BaseEntity
    {
        public Servico(string nome, string descricao, decimal valor, int duracao) : base()
        {
            Nome = nome;
            Descricao = descricao;
            Valor = valor;
            Duracao = duracao;
            Atendimentos = [];
        }

        public string Nome { get; private set; }
        public string  Descricao { get; private set; }
        public decimal Valor { get; private set; }
        public int Duracao { get; private set; }
        public List<Atendimento> Atendimentos { get; private set; }

        public void Converte(int duracao)
        {
            Duracao = duracao / 60;

        }
        public void UpdateServico(string nome, string descricao, decimal valor)
        {
            Nome = nome;
            Descricao = descricao;
            Valor = valor;
           
        }
    }
}
