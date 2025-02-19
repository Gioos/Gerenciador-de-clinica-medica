using GerenciadorDeClinica.Application.Models.ViewModels;
using GerenciadorDeClinica.Core.Entities;
using MediatR;

namespace GerenciadorDeClinica.Application.Commands.ServicoCommands.InsertServico
{
    public class InsertServicoCommand : IRequest<ResultViewModel<int>>
    {
        public string Nome { get;  set; }
        public string Descricao { get;  set; }
        public decimal Valor { get;  set; }
        public int Duracao { get;  set; }

        public Servico ToEntity()
            => new Servico(Nome, Descricao, Valor, Duracao);
    }
}
