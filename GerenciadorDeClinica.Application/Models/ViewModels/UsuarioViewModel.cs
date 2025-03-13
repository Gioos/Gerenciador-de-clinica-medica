namespace GerenciadorDeClinica.Application.Models.ViewModels
{
    public class UsuarioViewModel
    {
        public UsuarioViewModel(string email, string passwordHash)
        {
            Email = email;
            PasswordHash = passwordHash;
        }

        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
    }
}
