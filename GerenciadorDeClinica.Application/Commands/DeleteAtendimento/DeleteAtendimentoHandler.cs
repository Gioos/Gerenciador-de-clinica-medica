using GerenciadorDeClinica.Application.Models.ViewModels;
using GerenciadorDeClinica.Core.Repositories;
using MediatR;

namespace GerenciadorDeClinica.Application.Commands.DeleteAtendimento
{
    public class DeleteAtendimentoHandler : IRequestHandler<DeleteAtendimentoCommand, ResultViewModel>
    {
        private readonly IAtendimentoRepository _repository;

        public DeleteAtendimentoHandler(IAtendimentoRepository repository)
        {
            _repository = repository;
        }


        public async Task<ResultViewModel> Handle(DeleteAtendimentoCommand request, CancellationToken cancellationToken)
        {
            var atendimento = await _repository.GetById(request.Id);

            if (atendimento == null || atendimento.IsDeleted)
                
                    return ResultViewModel.Error("Atendimento não encontrado");

            atendimento.SetAsDelete();
            await _repository.Update(atendimento);

            return ResultViewModel.Sucess();

        }
    }
}
