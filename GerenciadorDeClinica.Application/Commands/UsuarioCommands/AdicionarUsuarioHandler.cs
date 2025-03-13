using GerenciadorDeClinica.Application.Models.ViewModels;
using GerenciadorDeClinica.Core.Entities;
using GerenciadorDeClinica.Core.Repositories;
using GerenciadorDeClinica.Infrastructure.Security;
using MediatR;

namespace GerenciadorDeClinica.Application.Commands.UsuarioCommands
{
    public class AdicionarUsuarioHandler : IRequestHandler<AdicionarUsuarioCommand, ResultViewModel<int>>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IAuthService _authService;

        public AdicionarUsuarioHandler(IUsuarioRepository usuarioRepository, IAuthService authService)
        {
            
            _usuarioRepository = usuarioRepository;
            _authService = authService;
        }
        public async Task<ResultViewModel<int>> Handle(AdicionarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var hash = _authService.ComputeHash(request.Password);

            var usuario = new Usuario(request.Email, hash);

            await _usuarioRepository.CriarUsuarioAsync(usuario);
            
            return new ResultViewModel<int>(usuario.Id);
        }
    }
}
