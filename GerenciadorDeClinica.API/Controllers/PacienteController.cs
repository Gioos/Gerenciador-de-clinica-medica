using GerenciadorDeClinica.Application.Commands.PacienteCommands.DeletePaciente;
using GerenciadorDeClinica.Application.Commands.PacienteCommands.InsertPaciente;
using GerenciadorDeClinica.Application.Commands.PacienteCommands.UpdatePaciente;
using GerenciadorDeClinica.Application.Queries.PacienteQueries.GetAllPacientes;
using GerenciadorDeClinica.Application.Queries.PacienteQueries.GetPacienteByCpf;
using GerenciadorDeClinica.Application.Queries.PacienteQueries.GetPacienteById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeClinica.API.Controllers
{
    [Route("api/pacientes")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PacientesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllPacientes()
        {
            var query = new GetAllPacientesQuery();

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetPacienteById(int id)
        {
            var paciente = await _mediator.Send(new GetPacienteByIdQuery(id));

            if (!paciente.IsSucess)
                return BadRequest(paciente.Message);

            return Ok(paciente);
        }

        [HttpGet("cpf/{cpf}")]
        [Authorize]

        public async Task<IActionResult> GetPacienteByCpf(string cpf)
        {
            var paciente = await _mediator.Send(new GetPacienteByCpfQuery(cpf));

            if (!paciente.IsSucess)
                return BadRequest(paciente.Message);

            return Ok(paciente);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(InsertPacienteCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSucess)
                return BadRequest(result.Message);


            return CreatedAtAction(nameof(GetPacienteById), new { id = result.Data }, result);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, UpdatePacienteCommand command)
        {
            
            var result = await _mediator.Send(command);

            if (!result.IsSucess)
                return BadRequest(result.Message);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeletePacienteCommand(id));

            if (!result.IsSucess)
                return BadRequest(result.Message);

            return NoContent();
        }
    }
}
