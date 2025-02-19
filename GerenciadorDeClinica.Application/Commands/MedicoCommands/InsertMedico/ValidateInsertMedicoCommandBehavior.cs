using GerenciadorDeClinica.Application.Models.ViewModels;
using GerenciadorDeClinica.Infrastructure.Persistence;
using MediatR;

namespace GerenciadorDeClinica.Application.Commands.MedicoCommands.InsertMedico
{
    public class ValidateInsertMedicoCommandBehavior : IPipelineBehavior<InsertMedicoCommand, ResultViewModel<int>>
    {
        private readonly GerenciadorDeClinicaDbContext _context;

        public ValidateInsertMedicoCommandBehavior(GerenciadorDeClinicaDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel<int>> Handle(InsertMedicoCommand request, RequestHandlerDelegate<ResultViewModel<int>> next, CancellationToken cancellationToken)
        {
            var medicoExists = _context.Medicos.Any(x => x.CRM == request.CRM);

            if (medicoExists)
                return ResultViewModel<int>.Error("Médico já cadastrado");

            return await next();
        }
    }
}
