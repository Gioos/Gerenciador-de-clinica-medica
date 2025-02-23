using GerenciadorDeClinica.Application.Models.ViewModels;
using GerenciadorDeClinica.Infrastructure.Persistence;
using MediatR;

namespace GerenciadorDeClinica.Application.Commands.PacienteCommands.InsertPaciente
{
    public class ValidateInsertPacienteCommandBehavior : IPipelineBehavior<InsertPacienteCommand, ResultViewModel<int>>
    {
        private readonly GerenciadorDeClinicaDbContext _context;

        public ValidateInsertPacienteCommandBehavior(GerenciadorDeClinicaDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel<int>> Handle(InsertPacienteCommand request, RequestHandlerDelegate<ResultViewModel<int>> next, CancellationToken cancellationToken)
        {
            var pacienteExists = _context.Pacientes.Any(x => x.CPF == request.CPF);

            if (pacienteExists)
                return ResultViewModel<int>.Error("Paciente já cadastrado");

            return await next();
        }
    }
}
