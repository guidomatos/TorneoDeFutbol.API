using TorneoDeFutbol.Domain.Entities;
using TorneoDeFutbol.Infrastructure.Services;
using MediatR;

namespace TorneoDeFutbol.Application.ProfesionFutbol.Queries.ObtenerProfesiones;

public record ObtenerProfesionesQuery : IRequest<IEnumerable<Profesion>>;

public class GetProfessionsQueryHandler : IRequestHandler<ObtenerProfesionesQuery, IEnumerable<Profesion>>
{
    private readonly IProfesionService _professionService;
    public GetProfessionsQueryHandler
    (
        IProfesionService professionService
    )
    {
        _professionService = professionService;
    }

    public async Task<IEnumerable<Profesion>> Handle(ObtenerProfesionesQuery request, CancellationToken cancellationToken)
    {
        return await _professionService.ObtenerProfesiones();
    }
}