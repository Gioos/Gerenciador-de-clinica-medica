using GerenciadorDeClinica.Application.Models.InputModels;
using GerenciadorDeClinica.Application.Models.ViewModels;
using GerenciadorDeClinica.Core.Repositories;
using GerenciadorDeClinica.Infrastructure.Security;
using MediatR;

namespace GerenciadorDeClinica.Application.Commands.LoginCommands
{
    public class LoginHandler : IRequestHandler<LoginCommand, ResultViewModel<LoginViewModel>>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IAuthService _authService;


        public LoginHandler(IUsuarioRepository usuarioRepository, IAuthService service)
        {
            _usuarioRepository = usuarioRepository;
            _authService = service;

        }

        public async Task<ResultViewModel<LoginViewModel>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            // Gerar o hash da senha recebida
            var hash = _authService.ComputeHash(request.Senha);

            // Buscar o usuário no banco pelo email e senha hashada
            var usuario = await _usuarioRepository.GetByEmailAndPasswordAsync(request.Email, hash);

            // Se o usuário não existir, retorna erro
            if (usuario == null)
                return ResultViewModel<LoginViewModel>.Error("Usuário ou senha inválidos.");

            // Gerar token de autenticação
            var token = _authService.GenerateToken(usuario.Email, "default-role");

            // Criar ViewModel de resposta
            var viewModel = new LoginViewModel(token);

            var result = ResultViewModel<LoginViewModel>.Success(viewModel);

            return result;
        }
    }
}
