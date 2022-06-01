using TorneoDeFutbol.Application.Common.Exceptions;
using TorneoDeFutbol.Domain.Entities;
using TorneoDeFutbol.Infrastructure.Services;
using MediatR;

namespace TorneoDeFutbol.Application.ProfesionFutbol.Commands.EliminarProfesion;

public record EliminarProfesionCommand (int Id) : IRequest<int>;

public class EliminarProfesionCommandHandler : IRequestHandler<EliminarProfesionCommand, int>
{
    private readonly IProfesionService _profesionService;
    public EliminarProfesionCommandHandler
    (
        IProfesionService professionService
    )
    {
        _profesionService = professionService;
    }

    public async Task<int> Handle(EliminarProfesionCommand request, CancellationToken cancellationToken)
    {
        var profession = await _profesionService.ObtenerProfesion(request.Id);

        if (profession == null)
        {
            throw new NotFoundException(nameof(Profesion), request.Id);
        }

        return await _profesionService.EliminarProfesion(profession);
    }
}