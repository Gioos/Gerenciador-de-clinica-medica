using GerenciadorDeClinica.Application.Models.ViewModels;
using GerenciadorDeClinica.Core.Repositories;
using MediatR;

namespace GerenciadorDeClinica.Application.Commands.DeletePaciente
{
    public class DeletePacienteHandler : IRequestHandler<DeletePacienteCommand, ResultViewModel>
    {
        private readonly IPacienteRepository _repository;

        public DeletePacienteHandler(IPacienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(DeletePacienteCommand request, CancellationToken cancellationToken)
        {
            var paciente = await _repository.GetById(request.Id);

            if (paciente == null || paciente.IsDeleted)
            {
                return ResultViewModel.Error("Paciente não encontrado.");
            }

            paciente.SetAsDelete();

            await _repository.Update(paciente);

            return ResultViewModel.Sucess();
        }
    }
}
