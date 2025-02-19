using GerenciadorDeClinica.Application.Models.ViewModels;
using GerenciadorDeClinica.Core.Repositories;
using MediatR;

namespace GerenciadorDeClinica.Application.Commands.ServicoCommands.DeleteServico
{
    public class DeleteServicoHandler : IRequestHandler<DeleteServicoCommand, ResultViewModel>
    {
        private readonly IServicoRepository _servicoRepository;

        public DeleteServicoHandler(IServicoRepository servicoRepository)
        {
            _servicoRepository = servicoRepository;
        }


        public async Task<ResultViewModel> Handle(DeleteServicoCommand request, CancellationToken cancellationToken)
        {
            var servico = await _servicoRepository.GetById(request.Id);

            if (servico == null || servico.IsDeleted)
                return ResultViewModel.Error("Serviço não encontrado");

            servico.SetAsDelete();
            
            await _servicoRepository.Update(servico);

            return ResultViewModel.Sucess();

        }
    }
}
