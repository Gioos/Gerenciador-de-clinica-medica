using GerenciadorDeClinica.Application.Commands.LoginCommands;
using GerenciadorDeClinica.Application.Commands.NovaSenhaCommands;
using GerenciadorDeClinica.Application.Commands.RecuperarSenhaCommands;
using GerenciadorDeClinica.Application.Commands.ValidaCodigoCommands;
using GerenciadorDeClinica.Application.Models.InputModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace GerenciadorDeClinica.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMemoryCache _cache;

        public LoginController(IMediator mediator, IMemoryCache cache)
        {
            _mediator = mediator;
            _cache = cache;
        }

        [HttpPost()]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginInputModel loginInputModel)
        {
            var command = new LoginCommand(loginInputModel.Email, loginInputModel.Password);

            var result = await _mediator.Send(command);

            if (!result.IsSucess)
            {
                return BadRequest(result); // Retorna erro caso o login falhe
            }

            return Ok(result); // Retorna sucesso e o token caso o login seja válido
        }

        //recuperar senha
        [HttpPost("password-recovery/request")]
        public async Task<IActionResult> RequestPasswordRecovery(PasswordRecoveryInputModel model)
        {

            var result = await _mediator.Send(new RecuperarSenhaCommand(model.Email));

            if (result == null || !result.IsSucess)
            {
                return BadRequest("Usuário não encontrado");
            }

            return NoContent();

        }

        //validação do código de recuperação
        [HttpPost("password-recovery/validate")]
        public async Task<IActionResult> ValidateRecoveryCode(ValidateRecoveryCodeInputModel model)
        {
            var result = await _mediator.Send(new ValidaCodigoCommand(model.Email, model.Code));

            if (!result.IsSucess)
            {
                return BadRequest(result);
            }

            return NoContent();
        }

        //Nova senha
        [HttpPost("password-recovery/change")]
        public async Task<IActionResult> ChangePassword(ChangePasswordInputModel model)
        {
            var command = new NovaSenhaCommand(model.Email, model.Code, model.NewPassword);
            var result = await _mediator.Send(command);

            if (!result.IsSucess)
                return BadRequest(result);

            return NoContent();
        }
    }
}
