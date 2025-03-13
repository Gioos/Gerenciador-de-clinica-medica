using GerenciadorDeClinica.Application.Models.ViewModels;
using GerenciadorDeClinica.Core.Repositories;
using GerenciadorDeClinica.Infrastructure.Notifications;
using GerenciadorDeClinica.Infrastructure.Security;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace GerenciadorDeClinica.Application.Commands.RecuperarSenhaCommands
{
    public class RecuperarSenhaHandler : IRequestHandler<RecuperarSenhaCommand, ResultViewModel<int>>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IEmailService _emailService;
        private readonly IMemoryCache _cache;
        private readonly IAuthService _auth;
        private readonly IMediator _mediator;

        public RecuperarSenhaHandler(IUsuarioRepository usuarioRepository, IEmailService emailService, IMemoryCache cache, IAuthService auth, IMediator mediator)
        {
            _usuarioRepository = usuarioRepository;
            _emailService = emailService;
            _cache = cache;
            _auth = auth;
            _mediator = mediator;
        }

        

        async Task<ResultViewModel<int>> IRequestHandler<RecuperarSenhaCommand, ResultViewModel<int>>.Handle(RecuperarSenhaCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.GetByEmailAsync(request.Email!);

            if (usuario == null)
            {
                return ResultViewModel<int>.Error("Email inválido!");
            }

            var recoveryCode = new Random().Next(100000, 999999).ToString();

            var chaveCache = $"recovery-code: {usuario.Email}";

            _cache.Set(chaveCache, recoveryCode, TimeSpan.FromMinutes(5));

            await _emailService.SendEmailAsync(usuario.Email, "Recuperação de senha: ", $"Seu código de recuperação é: {recoveryCode} e irá expirar em 5 minutos! ");

            return ResultViewModel<int>.Success(0);
        }
    }
}
