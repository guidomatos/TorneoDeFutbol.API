using TorneoDeFutbol.Application.Common.Exceptions;
using TorneoDeFutbol.Domain.Entities;
using TorneoDeFutbol.Infrastructure.Services;
using MediatR;

namespace TorneoDeFutbol.Application.ProfesionFutbol.Commands.ActualizarProfesion;

public record ActualizarProfesionCommand : IRequest<Profesion>
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class ActualizarProfesionCommandHandler : IRequestHandler<ActualizarProfesionCommand, Profesion>
{
    private readonly IProfesionService _professionService;
    public ActualizarProfesionCommandHandler
    (
        IProfesionService professionService
    )
    {
        _professionService = professionService;
    }

    public async Task<Profesion> Handle(ActualizarProfesionCommand request, CancellationToken cancellationToken)
    {
        var profession = await _professionService.ObtenerProfesion(request.Id);

        if (profession == null)
        {
            throw new NotFoundException(nameof(Profesion), request.Id);
        }

        profession.Nombre = request.Name;

        return await _professionService.ActualizarProfesion(profession);
    }
}