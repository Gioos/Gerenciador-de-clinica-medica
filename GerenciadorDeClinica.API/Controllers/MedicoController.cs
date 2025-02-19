using GerenciadorDeClinica.Application.Commands.MedicoCommands.DeleteMedico;
using GerenciadorDeClinica.Application.Commands.MedicoCommands.InsertMedico;
using GerenciadorDeClinica.Application.Commands.MedicoCommands.UpdateMedico;
using GerenciadorDeClinica.Application.Queries.MedicoQueries.GetAllMedicos;
using GerenciadorDeClinica.Application.Queries.MedicoQueries.GetMedicoById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeClinica.API.Controllers
{
    [Route("api/medicos")]
    [ApiController]
    public class MedicosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MedicosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMedicos()
        {
            var medicos = await _mediator.Send(new GetAllMedicosQuery());

            return Ok(medicos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMedicoById(int id)
        {
            var medico = await _mediator.Send(new GetMedicoByIdQuery(id));

            if (!medico.IsSucess)
                return BadRequest(medico.Message);

            return Ok(medico);
        }

        [HttpPost]
        public async Task<IActionResult> Post(InsertMedicoCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSucess)
                return BadRequest(result.Message);

            return CreatedAtAction(nameof(GetMedicoById), new { id = result.Data }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateMedicoCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSucess)
                return BadRequest(result.Message);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteMedicoCommand(id));

            if (!result.IsSucess)
                return BadRequest(result.Message);

            return NoContent();
        }
    }
}
