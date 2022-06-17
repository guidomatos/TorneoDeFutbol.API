using MediatR;
using Microsoft.AspNetCore.Mvc;
using TorneoDeFutbol.Application.TorneoProgramacionFutbol.Commands.ProgramarFecha;
using TorneoDeFutbol.Application.TorneoProgramacionFutbol.Queries.ObtenerProgramacionPorTorneo;
using TorneoDeFutbol.Domain.Entities;

namespace TorneoDeFutbol.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TorneoProgramacionController : Controller
{
    private readonly IMediator _mediator;
    public TorneoProgramacionController(

    IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<IEnumerable<TorneoProgramacion>> Get(int id)
    => await _mediator.Send(new ObtenerProgramacionPorTorneoQuery { TorneoId = id });

    [HttpPost]
    public async Task<ActionResult<int>> ProgramarFecha(ProgramarFechaCommand command)
    {
        return await _mediator.Send(command);
    }
}
