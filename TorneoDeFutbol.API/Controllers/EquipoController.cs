using MediatR;
using Microsoft.AspNetCore.Mvc;
using TorneoDeFutbol.Application.EquipoFutbol.Commands.CrearEquipo;
using TorneoDeFutbol.Domain;

namespace TorneoDeFutbol.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EquipoController : Controller
{
    private readonly IMediator _mediator;


    public EquipoController(

        IMediator mediator)
    {
        _mediator= mediator;    
    }

    [HttpPost]
    public async Task<ActionResult<Equipo>> Crear(CrearEquipoCommand command)
    {
        return await _mediator.Send(command);
    }

}
