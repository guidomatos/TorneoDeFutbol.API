using MediatR;
using Microsoft.AspNetCore.Mvc;
using TorneoDeFutbol.Application.ProfesionFutbol.Queries.ObtenerTorneos;
using TorneoDeFutbol.Application.TorneoFutbol.Commands.CrearTorneo;
using TorneoDeFutbol.Domain.Entities;

namespace TorneoDeFutbol.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TorneoController : Controller
{
    private readonly IMediator _mediator;


    public TorneoController(

        IMediator mediator)
    {
        _mediator= mediator;
    }

    [HttpPost]
    public async Task<ActionResult<Torneo>> Crear(CrearTorneoCommand command) => await _mediator.Send(command);

    [HttpGet]
    public async Task<IEnumerable<Torneo>> Get()
        => await _mediator.Send(new ObtenerTorneosQuery());

}
