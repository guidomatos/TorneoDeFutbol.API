using MediatR;
using TorneoDeFutbol.Application.Common.Interfaces;
using TorneoDeFutbol.Domain.Entities;

namespace TorneoDeFutbol.Application.TorneoProgramacionFutbol.Queries.ObtenerProgramacionPorTorneo;

public record ObtenerProgramacionPorTorneoQuery : IRequest<IEnumerable<TorneoProgramacion>>
{
    public int TorneoId { get; set; }
}

public class ObtenerProgramacionPorTorneoQueryHandler : IRequestHandler<ObtenerProgramacionPorTorneoQuery, IEnumerable<TorneoProgramacion>>
{
    private readonly ITorneoProgramacionService _torneoProgramacionService;
    public ObtenerProgramacionPorTorneoQueryHandler
    (
        ITorneoProgramacionService torneoProgramacionService
    )
    {
        _torneoProgramacionService = torneoProgramacionService;
    }

    public async Task<IEnumerable<TorneoProgramacion>> Handle(ObtenerProgramacionPorTorneoQuery request, CancellationToken cancellationToken)
    {
        return await _torneoProgramacionService.ObtenerProgramacionPorTorneo(request.TorneoId);
    }
}