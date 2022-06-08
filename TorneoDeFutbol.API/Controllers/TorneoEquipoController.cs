using MediatR;
using Microsoft.AspNetCore.Mvc;
using TorneoDeFutbol.Application.ProfesionFutbol.Queries.ObtenerEquipoPorTorneo;
using TorneoDeFutbol.Domain.Entities;

namespace TorneoDeFutbol.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TorneoEquipoController : Controller
    {
        private readonly IMediator _mediator;
        public TorneoEquipoController(

        IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<Equipo>> Get(int id)
        => await _mediator.Send(new ObtenerEquipoPorTorneoQuery { TorneoId = id });

    }
}
