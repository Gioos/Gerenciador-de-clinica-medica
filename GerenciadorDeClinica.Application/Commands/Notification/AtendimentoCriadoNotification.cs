using MediatR;

namespace GerenciadorDeClinica.Application.Commands.Notification
{
    public class AtendimentoCriadoNotification : INotification
    {
        public AtendimentoCriadoNotification(int id, int tipoAtendimento, string convenio)
        {
            Id = id;
            TipoAtendimento = tipoAtendimento;
            Convenio = convenio;
        }

        public int Id { get; private set; }
        public int TipoAtendimento { get; private set; }
        public string Convenio { get; private set; }
    }
}
