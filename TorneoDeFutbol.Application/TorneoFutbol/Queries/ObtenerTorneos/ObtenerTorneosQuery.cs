using TorneoDeFutbol.Domain.Entities;
using MediatR;
using TorneoDeFutbol.Application.Common.Interfaces;

namespace TorneoDeFutbol.Application.ProfesionFutbol.Queries.ObtenerTorneos;

public record ObtenerTorneosQuery : IRequest<IEnumerable<Torneo>>;

public class ObtenerTorneosQueryHandler : IRequestHandler<ObtenerTorneosQuery, IEnumerable<Torneo>>
{
    private readonly ITorneoService _torneoService;
    public ObtenerTorneosQueryHandler
    (
        ITorneoService torneoService
    )
    {
        _torneoService = torneoService;
    }

    public async Task<IEnumerable<Torneo>> Handle(ObtenerTorneosQuery request, CancellationToken cancellationToken)
    {
        return await _torneoService.ObtenerTorneos();
    }
}