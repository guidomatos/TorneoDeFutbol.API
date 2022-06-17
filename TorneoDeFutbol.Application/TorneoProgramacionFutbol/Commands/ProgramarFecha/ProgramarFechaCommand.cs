using MediatR;
using TorneoDeFutbol.Application.Common.Interfaces;
using TorneoDeFutbol.Domain.Entities;

namespace TorneoDeFutbol.Application.TorneoProgramacionFutbol.Commands.ProgramarFecha; 

public class ProgramarFechaCommand : IRequest<int>
{
    public List<TorneoProgramacionDetalle> ProgramacionDetalle { get; set; }
}

public class ProgramarFechaCommandHandler : IRequestHandler<ProgramarFechaCommand, int>
{

    private readonly ITorneoProgramacionService _torneoProgramacionService;

    public ProgramarFechaCommandHandler(
        ITorneoProgramacionService torneoProgramacionService
        )
    {
        _torneoProgramacionService = torneoProgramacionService;
    }

    public async Task<int> Handle(ProgramarFechaCommand request, CancellationToken cancellationToken)
    {
        return await _torneoProgramacionService.ProgramarFecha(request.ProgramacionDetalle);
    }
}
