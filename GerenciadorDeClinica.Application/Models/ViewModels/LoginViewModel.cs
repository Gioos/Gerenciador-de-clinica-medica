namespace GerenciadorDeClinica.Application.Models.ViewModels
{
    public class LoginViewModel
    {
        public LoginViewModel(string token)
        {
            Token = token;
        }

        public string Token { get; set; }
    }
}
