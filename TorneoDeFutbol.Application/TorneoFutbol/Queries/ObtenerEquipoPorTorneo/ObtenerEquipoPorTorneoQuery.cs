using TorneoDeFutbol.Domain.Entities;
using MediatR;
using TorneoDeFutbol.Application.Common.Interfaces;

namespace TorneoDeFutbol.Application.ProfesionFutbol.Queries.ObtenerEquipoPorTorneo;

public record ObtenerEquipoPorTorneoQuery : IRequest<IEnumerable<Equipo>>
{
    public int TorneoId { get; set; }   
}

public class ObtenerEquipoPorTorneoQueryHandler : IRequestHandler<ObtenerEquipoPorTorneoQuery, IEnumerable<Equipo>>
{
    private readonly ITorneoEquipoService _torneoEquipoService;
    public ObtenerEquipoPorTorneoQueryHandler
    (
        ITorneoEquipoService torneoEquipoService
    )
    {
        _torneoEquipoService = torneoEquipoService;
    }

    public async Task<IEnumerable<Equipo>> Handle(ObtenerEquipoPorTorneoQuery request, CancellationToken cancellationToken)
    {
        return await _torneoEquipoService.ObtenerEquiposPorTorneo(request.TorneoId);
    }
}