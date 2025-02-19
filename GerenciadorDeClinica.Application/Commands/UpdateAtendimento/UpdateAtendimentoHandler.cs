using GerenciadorDeClinica.Application.Models.ViewModels;
using GerenciadorDeClinica.Core.Repositories;
using MediatR;

namespace GerenciadorDeClinica.Application.Commands.UpdateAtendimento
{
    public class UpdateAtendimentoHandler : IRequestHandler<UpdateAtendimentoCommand, ResultViewModel>
    {
        private readonly IAtendimentoRepository _repository;

        public UpdateAtendimentoHandler(IAtendimentoRepository repository)
        {
            _repository = repository;
        }


        public async Task<ResultViewModel> Handle(UpdateAtendimentoCommand request, CancellationToken cancellationToken)
        {
            var atendimento = await _repository.GetById(request.IdAtendimento);

            if (atendimento == null || atendimento.IsDeleted)
            {
                return ResultViewModel.Error("Atendimento não encontrado");
            }
            atendimento.Update(request.Convenio);

            await _repository.Update(atendimento);

            return ResultViewModel.Sucess();
        }

    }
}
