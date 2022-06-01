using MediatR;
using TorneoDeFutbol.Domain.Entities;
using TorneoDeFutbol.Infrastructure.Services;

namespace TorneoDeFutbol.Application.ProfesionFutbol.Queries.ObtenerProfession;

public record ObtenerProfesionQuery : IRequest<Profesion>
{
    public int Id { get; set; }
}

public class ObtenerProfesionQueryHandler : IRequestHandler<ObtenerProfesionQuery, Profesion>
{
    private readonly IProfesionService _profesionService;
    public ObtenerProfesionQueryHandler
    (
        IProfesionService profesionService
    )
    {
        _profesionService = profesionService;
    }

    public async Task<Profesion> Handle(ObtenerProfesionQuery request, CancellationToken cancellationToken)
    {
        return await _profesionService.ObtenerProfesion(request.Id);
    }
}