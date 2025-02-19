using GerenciadorDeClinica.Core.Entities;

namespace GerenciadorDeClinica.Application.Models.ViewModels
{
    public class ServicoViewModel
    {
        public ServicoViewModel(int id, string nome, string descricao, decimal valor, int duracao)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Valor = valor;
            Duracao = duracao;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Valor { get; private set; }
        public int Duracao { get; private set; }


        public static ServicoViewModel FromEntity(Servico entity)
            => new ServicoViewModel(entity.Id, entity.Nome, entity.Descricao, entity.Valor, entity.Duracao);
    }
}
