using GerenciadorDeClinica.Application.Models.ViewModels;
using MediatR;

namespace GerenciadorDeClinica.Application.Commands.ServicoCommands.UpdateServico
{
    public class UpdateServicoCommand : IRequest<ResultViewModel>
    {
        public int IdServico { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
    }
}
