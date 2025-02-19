using GerenciadorDeClinica.Application.Models.ViewModels;
using GerenciadorDeClinica.Infrastructure.Persistence;
using MediatR;

namespace GerenciadorDeClinica.Application.Commands.ServicoCommands.InsertServico
{
    public class ValidateInsertServicoCommandBehavior : IPipelineBehavior<InsertServicoCommand, ResultViewModel<int>>
    {
        private readonly GerenciadorDeClinicaDbContext _context;

        public ValidateInsertServicoCommandBehavior(GerenciadorDeClinicaDbContext context)
        {
            _context = context;
        }


        public async Task<ResultViewModel<int>> Handle(InsertServicoCommand request, RequestHandlerDelegate<ResultViewModel<int>> next, CancellationToken cancellationToken)
        {
            var servicoExists = _context.Servicos.Any(x => x.Nome == request.Nome);
            if (servicoExists)
            {
                return ResultViewModel<int>.Error("Serviço já cadastrado");
            }
                return await next();
            
        }
    }
}
