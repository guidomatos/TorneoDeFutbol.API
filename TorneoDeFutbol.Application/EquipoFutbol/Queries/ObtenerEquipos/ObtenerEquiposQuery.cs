using MediatR;
using TorneoDeFutbol.Application.Common.Interfaces;
using TorneoDeFutbol.Domain;
using TorneoDeFutbol.Domain.Entities;

namespace TorneoDeFutbol.Application.ProfesionFutbol.Queries.ObtenerEquipos;

public record ObtenerEquiposQuery : IRequest<IEnumerable<Equipo>>;

public class GetProfessionsQueryHandler : IRequestHandler<ObtenerEquiposQuery, IEnumerable<Equipo>>
{
    private readonly IEquipoService _equipoService;
    public GetProfessionsQueryHandler
    (
        IEquipoService equipoService
    )
    {
        _equipoService = equipoService;
    }

    public async Task<IEnumerable<Equipo>> Handle(ObtenerEquiposQuery request, CancellationToken cancellationToken)
    {
        return await _equipoService.ObtenerEquipos();
    }
}