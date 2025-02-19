using GerenciadorDeClinica.Application.Models.ViewModels;
using GerenciadorDeClinica.Core.Repositories;
using MediatR;

namespace GerenciadorDeClinica.Application.Commands.ServicoCommands.UpdateServico
{
    public class UpdateServicoHandler : IRequestHandler<UpdateServicoCommand, ResultViewModel>
    {
        private readonly IServicoRepository _repository;

        public UpdateServicoHandler(IServicoRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel> Handle(UpdateServicoCommand request, CancellationToken cancellationToken)
        {
            var servico = await _repository.GetById(request.IdServico);

            if (servico == null || servico.IsDeleted)
            {
                return ResultViewModel.Error("Serviço não encontrado.");
            }

            servico.UpdateServico(request.Nome, request.Descricao, request.Preco);

            await _repository.Update(servico);

            return ResultViewModel.Sucess();
        }
    }
}
