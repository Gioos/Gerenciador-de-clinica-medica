using GerenciadorDeClinica.Application.Commands.ServicoCommands.DeleteServico;
using GerenciadorDeClinica.Application.Commands.ServicoCommands.InsertServico;
using GerenciadorDeClinica.Application.Commands.ServicoCommands.UpdateServico;
using GerenciadorDeClinica.Application.Queries.ServicoQueries.GetAllServicos;
using GerenciadorDeClinica.Application.Queries.ServicoQueries.GetServicoById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeClinica.API.Controllers
{
    [Route("api/servicos")]
    [ApiController]
    public class ServicoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServicoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetServicos()
        {
            var servicos = await _mediator.Send(new GetAllServicosQuery());
            return Ok(servicos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetServicoById(int id)
        {
            var servico = await _mediator.Send(new GetServicoByIdQuery(id));

            if (!servico.IsSucess)
                return BadRequest(servico.Message);

            return Ok(servico);
        }

        [HttpPost]
        public async Task<IActionResult> Post(InsertServicoCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSucess)
                return BadRequest(result.Message);

            return CreatedAtAction(nameof(GetServicoById), new { id = result.Data }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateServicoCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSucess)
                return BadRequest(result.Message);

            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteServicoCommand(id));

            if (!result.IsSucess)
                return BadRequest(result.Message);

            return NoContent();
        }


    }
}
