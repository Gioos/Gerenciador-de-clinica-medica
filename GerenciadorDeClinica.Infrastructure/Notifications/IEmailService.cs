namespace GerenciadorDeClinica.Infrastructure.Notifications
{
    public interface IEmailService
    {
        Task  SendEmailAsync(string email, string subject, string message);
    }
}
