using GerenciadorDeClinica.Application.Commands.DeleteAtendimento;
using GerenciadorDeClinica.Application.Commands.InsertAtendimento;
using GerenciadorDeClinica.Application.Commands.UpdateAtendimento;
using GerenciadorDeClinica.Application.Queries.GetAllAtendimentos;
using GerenciadorDeClinica.Application.Queries.GetAtendimentoById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeClinica.API.Controllers
{
    [Route("api/atendimentos")]
    [ApiController]
    public class AtendimentosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AtendimentosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAtendimentos()
        {
            var query = new GetAllAtendimentosQuery();

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAtendimentoById(int id)
        {
            
            var result = await _mediator.Send(new GetAtendimentoByIdQuery(id));

            if (!result.IsSucess)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(InsertAtendimentoCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.IsSucess)
                return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateAtendimentoCommand command)
        {
            
            var result = await _mediator.Send(command);
            if (!result.IsSucess)
                return BadRequest(result.Message);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteAtendimentoCommand(id));

            if (!result.IsSucess)
                return BadRequest(result.Message);

            return NoContent();
        }
    }
}
