using GerenciadorDeClinica.Application.Models.ViewModels;
using GerenciadorDeClinica.Core.Repositories;
using MediatR;

namespace GerenciadorDeClinica.Application.Commands.MedicoCommands.DeleteMedico
{
    public class DeleteMedicoHandler : IRequestHandler<DeleteMedicoCommand, ResultViewModel>
    {
        private readonly IMedicoRepository _repository;

        public DeleteMedicoHandler(IMedicoRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel> Handle(DeleteMedicoCommand request, CancellationToken cancellationToken)
        {
            var medico = await _repository.GetById(request.Id);

            if (medico == null || medico.IsDeleted)
            {
                return ResultViewModel.Error("Médico não encontrado.");
            }

            medico.SetAsDelete();

            await _repository.Update(medico);

            return ResultViewModel.Sucess();
        }
    }
}
