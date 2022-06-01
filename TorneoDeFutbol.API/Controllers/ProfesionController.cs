using TorneoDeFutbol.Application.ProfesionFutbol.Commands.CrearProfesion;
using TorneoDeFutbol.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using TorneoDeFutbol.Application.ProfesionFutbol.Queries.ObtenerProfesiones;
using TorneoDeFutbol.Application.ProfesionFutbol.Commands.ActualizarProfesion;
using TorneoDeFutbol.Application.ProfesionFutbol.Commands.EliminarProfesion;
using TorneoDeFutbol.Application.ProfesionFutbol.Queries.ObtenerProfession;

namespace TorneoDeFutbol.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfesionController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProfesionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<Profesion>> Create(CrearProfesionCommand command)
        => await _mediator.Send(command);

    [HttpPut("{id}")]
    public async Task<ActionResult<Profesion>> Update(int id, ActualizarProfesionCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }
        return await _mediator.Send(command);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<int>> Delete(int id)
        => await _mediator.Send(new EliminarProfesionCommand(id));

    [HttpGet]
    public async Task<IEnumerable<Profesion>> Get()
        => await _mediator.Send(new ObtenerProfesionesQuery());

    [HttpGet("{id}")]
    public async Task<ActionResult<Profesion>> Get(int id)
        => await _mediator.Send(new ObtenerProfesionQuery { Id = id });

}