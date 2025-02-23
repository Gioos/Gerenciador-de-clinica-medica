using GerenciadorDeClinica.Application.Models.ViewModels;
using GerenciadorDeClinica.Infrastructure.Persistence;
using MediatR;
using System.Linq;

namespace GerenciadorDeClinica.Application.Commands.AtendimentoCommands.InsertAtendimento
{
    public class ValidateInsertAtendimentoCommandBehavior : IPipelineBehavior<InsertAtendimentoCommand, ResultViewModel<int>>
    {
        private readonly GerenciadorDeClinicaDbContext _context;

        public ValidateInsertAtendimentoCommandBehavior(GerenciadorDeClinicaDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel<int>> Handle(InsertAtendimentoCommand request,
            RequestHandlerDelegate<ResultViewModel<int>> next, CancellationToken cancellationToken)
        {
            var medicoExists = _context.Medicos.Any(x => x.Id == request.IdMedico);

            var pacienteExists = _context.Pacientes.Any(x => x.Id == request.IdPaciente);

            if (!medicoExists || !pacienteExists)
                return ResultViewModel<int>.Error("Médico ou paciente inválido");

            return await next();
        }
    }
}
