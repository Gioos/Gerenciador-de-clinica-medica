using GerenciadorDeClinica.Application.Models.ViewModels;
using GerenciadorDeClinica.Core.Repositories;
using MediatR;

namespace GerenciadorDeClinica.Application.Commands.MedicoCommands.UpdateMedico
{
    public class UpdateMedicoHandler : IRequestHandler<UpdateMedicoCommand, ResultViewModel>
    {
        private readonly IMedicoRepository _repository;

        public UpdateMedicoHandler(IMedicoRepository repository)
        {
            _repository = repository;
        }


        public async Task<ResultViewModel> Handle(UpdateMedicoCommand request, CancellationToken cancellationToken)
        {
           var medico = await _repository.GetById(request.IdMedico);

            if (medico == null || medico.IsDeleted)
            {
                return ResultViewModel.Error("Médico não encontrado.");
            }

            medico.UpdateMedico(request.Telefone, request.Especialidade);

            await _repository.Update(medico);

            return ResultViewModel.Sucess();
        }
    }
}
