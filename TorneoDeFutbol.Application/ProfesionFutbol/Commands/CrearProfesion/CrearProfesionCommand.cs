using TorneoDeFutbol.Domain.Entities;
using TorneoDeFutbol.Infrastructure.Services;
using MediatR;

namespace TorneoDeFutbol.Application.ProfesionFutbol.Commands.CrearProfesion;

public record CrearProfesionCommand : IRequest<Profesion>
{
    public string Name { get; set; }
}

public class CrearProfesionCommandHandler: IRequestHandler<CrearProfesionCommand, Profesion>
{
    private readonly IProfesionService _professionService;
    public CrearProfesionCommandHandler
    (
        IProfesionService professionService
    )
    {
        _professionService = professionService;
    }

    public async Task<Profesion> Handle(CrearProfesionCommand request, CancellationToken cancellationToken)
    {
        var profession = new Profesion
        {
            Nombre = request.Name
        };

        return await _professionService.CrearProfesion(profession);
    }
}