using GerenciadorDeClinica.Application.Models.ViewModels;
using GerenciadorDeClinica.Core.Repositories;
using MediatR;

namespace GerenciadorDeClinica.Application.Commands.PacienteCommands.UpdatePaciente
{
    public class UpdatePacienteHandler : IRequestHandler<UpdatePacienteCommand, ResultViewModel>
    {
        private readonly IPacienteRepository _repository;
        public UpdatePacienteHandler(IPacienteRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel> Handle(UpdatePacienteCommand request, CancellationToken cancellationToken)
        {
            var paciente = await _repository.GetById(request.IdPaciente);

            if (paciente == null || paciente.IsDeleted)
            {
                return ResultViewModel.Error("Paciente não encontrado.");
            }

            paciente.UpdateUsuario(request.Telefone, request.Email, request.Endereco, request.Altura, request.Peso);

            await _repository.Update(paciente);

            return ResultViewModel.Sucess();
        }
    }
}
