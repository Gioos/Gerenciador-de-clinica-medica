using GerenciadorDeClinica.Application.Models.ViewModels;
using GerenciadorDeClinica.Core.Repositories;
using MediatR;

namespace GerenciadorDeClinica.Application.Commands.MedicoCommands.InsertMedico
{
    public class InsertMedicoHandler : IRequestHandler<InsertMedicoCommand, ResultViewModel<int>>
    {
        private readonly IMedicoRepository _medicoRepository;

        public InsertMedicoHandler(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }


        public async Task<ResultViewModel<int>> Handle(InsertMedicoCommand request, CancellationToken cancellationToken)
        {
            var medico = request.ToEntity();

            await _medicoRepository.Add(medico);

            return ResultViewModel<int>.Success(medico.Id);
        }
    }
}
