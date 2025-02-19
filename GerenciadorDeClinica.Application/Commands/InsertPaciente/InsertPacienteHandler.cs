using GerenciadorDeClinica.Application.Models.ViewModels;
using GerenciadorDeClinica.Core.Repositories;
using MediatR;

namespace GerenciadorDeClinica.Application.Commands.InsertPaciente
{
    public class InsertPacienteHandler : IRequestHandler<InsertPacienteCommand, ResultViewModel<int>>
    {
        private readonly IMediator _mediator;

        private readonly IPacienteRepository _repository;

        public InsertPacienteHandler(IMediator mediator, IPacienteRepository repository)
        {
            _mediator = mediator;
            _repository = repository;
        }   

        public async Task<ResultViewModel<int>> Handle(InsertPacienteCommand request, CancellationToken cancellationToken)
        {
           var paciente = request.ToEntity();

            await _repository.Add(paciente);

            //notificacao com mediator
           // var pacienteCriado = new PacienteCriadoNotification(paciente.Id);

            return ResultViewModel<int>.Success(paciente.Id);
        }
    }
}
