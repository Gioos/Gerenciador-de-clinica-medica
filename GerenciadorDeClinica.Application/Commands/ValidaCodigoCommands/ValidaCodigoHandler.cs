using GerenciadorDeClinica.Application.Models.ViewModels;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace GerenciadorDeClinica.Application.Commands.ValidaCodigoCommands
{
    public class ValidaCodigoHandler : IRequestHandler<ValidaCodigoCommand, ResultViewModel<int>>
    {
        
        private readonly IMemoryCache _cache;

        public ValidaCodigoHandler(IMemoryCache cache)
        {
            
            _cache = cache;
        }
        public async Task<ResultViewModel<int>> Handle(ValidaCodigoCommand request, CancellationToken cancellationToken)
        {

            var cacheKey = $"recovery-code: {request.Email}";

            if (!_cache.TryGetValue(cacheKey, out string? code) || code!= request.Code)
            {
                return ResultViewModel<int>.Error("Código inválido!");
            }

            return ResultViewModel<int>.Success(1);
        }
    }
}
