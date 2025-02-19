using GerenciadorDeClinica.Application.Commands.DeletePaciente;
using GerenciadorDeClinica.Application.Commands.InsertPaciente;
using GerenciadorDeClinica.Application.Commands.UpdatePaciente;
using GerenciadorDeClinica.Application.Queries.GetAllPacientes;
using GerenciadorDeClinica.Application.Queries.GetPacienteByCpf;
using GerenciadorDeClinica.Application.Queries.GetPacienteById;
using MediatR;
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
        public async Task<IActionResult> GetAllPacientes()
        {
            var query = new GetAllPacientesQuery();

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPacienteById(int id)
        {
            var paciente = await _mediator.Send(new GetPacienteByIdQuery(id));

            if (!paciente.IsSucess)
                return BadRequest(paciente.Message);

            return Ok(paciente);
        }

        [HttpGet("cpf/{cpf}")]

        public async Task<IActionResult> GetPacienteByCpf(string cpf)
        {
            var paciente = await _mediator.Send(new GetPacienteByCpfQuery(cpf));

            if (!paciente.IsSucess)
                return BadRequest(paciente.Message);

            return Ok(paciente);
        }

        [HttpPost]
        public async Task<IActionResult> Post(InsertPacienteCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSucess)
                return BadRequest(result.Message);


            return CreatedAtAction(nameof(GetPacienteById), new { id = result.Data }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdatePacienteCommand command)
        {
            
            var result = await _mediator.Send(command);

            if (!result.IsSucess)
                return BadRequest(result.Message);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeletePacienteCommand(id));

            if (!result.IsSucess)
                return BadRequest(result.Message);

            return NoContent();
        }
    }
}
