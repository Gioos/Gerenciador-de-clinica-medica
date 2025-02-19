using GerenciadorDeClinica.Application.Commands.Notification;
using GerenciadorDeClinica.Application.Models.ViewModels;
using GerenciadorDeClinica.Core.Repositories;
using MediatR;

namespace GerenciadorDeClinica.Application.Commands.InsertAtendimento
{
    public class InsertAtendimentoHandler : IRequestHandler<InsertAtendimentoCommand, ResultViewModel<int>>
    {

        private readonly IMediator _mediator;

        private readonly IAtendimentoRepository _repository;

        public InsertAtendimentoHandler(IMediator mediator, IAtendimentoRepository repository)
        {
            _mediator = mediator;
            _repository = repository;
        }


        public async Task<ResultViewModel<int>> Handle(InsertAtendimentoCommand request, CancellationToken cancellationToken)
        {
            var atendimento = request.ToEntity();

            await _repository.Add(atendimento);

            //notificacao com mediator
            var atendimentoCriado = new AtendimentoCriadoNotification(atendimento.Id, (int)atendimento.TipoAtendimento, atendimento.Convenio);

            await _mediator.Publish(atendimentoCriado);

            return  ResultViewModel<int>.Success(atendimento.Id);

        }
    }
}
