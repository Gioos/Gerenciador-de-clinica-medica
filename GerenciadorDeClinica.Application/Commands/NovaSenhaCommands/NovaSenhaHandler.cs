using GerenciadorDeClinica.Application.Models.ViewModels;
using GerenciadorDeClinica.Infrastructure.Persistence;
using GerenciadorDeClinica.Infrastructure.Security;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace GerenciadorDeClinica.Application.Commands.NovaSenhaCommands
{
    public class NovaSenhaHandler : IRequestHandler<NovaSenhaCommand, ResultViewModel<int>>
    {
        private readonly GerenciadorDeClinicaDbContext _dbContext;
        private readonly IAuthService _authService;
        private readonly IMemoryCache _cache;

        public NovaSenhaHandler(GerenciadorDeClinicaDbContext dbContext, IAuthService authService, IMemoryCache cache)
        {
            _dbContext = dbContext;
            _authService = authService;
            _cache = cache;
        }

        public async Task<ResultViewModel<int>> Handle(NovaSenhaCommand request, CancellationToken cancellationToken)
        {
            var cacheKey = $"recovery-code: {request.Email}";

            if (!_cache.TryGetValue(cacheKey, out string? code) || code != request.Senha)
            {
                return await Task.FromResult(ResultViewModel<int>.Error("Código inválido!"));
            }

            _cache.Remove(cacheKey);

            var user = await _dbContext.Usuarios.SingleOrDefaultAsync(u => u.Email == request.Email, cancellationToken);

            if (user == null)
            {
                return await Task.FromResult(ResultViewModel<int>.Error("Usuário não encontrado!"));
            }

            var hash = _authService.ComputeHash(request.NovaSenha);
            user.UpdatePassword(hash);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return ResultViewModel<int>.Success(1);
        }
    }
}
