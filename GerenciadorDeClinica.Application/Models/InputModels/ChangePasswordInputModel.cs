namespace GerenciadorDeClinica.Application.Models.InputModels
{
    public class ChangePasswordInputModel
    {
        public string Email { get; set; }
        public string Code { get; set; }
        public string NewPassword { get; set; }
    }
}
