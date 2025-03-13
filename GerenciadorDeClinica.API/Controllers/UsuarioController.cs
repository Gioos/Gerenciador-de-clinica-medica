using GerenciadorDeClinica.Application.Commands.RecuperarSenhaCommands;
using GerenciadorDeClinica.Application.Commands.UsuarioCommands;
using GerenciadorDeClinica.Application.Models.InputModels;
using GerenciadorDeClinica.Core.Repositories;
using GerenciadorDeClinica.Infrastructure.Notifications;
using GerenciadorDeClinica.Infrastructure.Security;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;


namespace GerenciadorDeClinica.API.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IAuthService _authService;
        private readonly IEmailService _emailService;
        private readonly IMemoryCache _cache;
        //private readonly IUsuarioRepository _repository;

        public UsuarioController(IMediator mediator, IAuthService authService,IMemoryCache cache, IEmailService emailService)
        {
            _mediator = mediator;
            _authService = authService;
            _cache = cache;
            _emailService = emailService;
            //_repository = repository;
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post (AdicionarUsuarioCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        
        
    }
}
