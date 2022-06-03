using MediatR;
using TorneoDeFutbol.Application.Common.Interfaces;
using TorneoDeFutbol.Domain;
using TorneoDeFutbol.Domain.Entities;

namespace TorneoDeFutbol.Application.TorneoFutbol.Commands.CrearTorneo
{
    public class CrearTorneoCommand : IRequest<Torneo>
    {
        public int TipoTorneoId { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public int Anio { get; set; }
    }

    public class CrearTorneoCommandHandler : IRequestHandler<CrearTorneoCommand, Torneo>
    {

        private readonly ITorneoService _torneoService;

        public CrearTorneoCommandHandler(
            ITorneoService torneoService
            )
        {
            _torneoService = torneoService;
        }

        public async Task<Torneo> Handle(CrearTorneoCommand request, CancellationToken cancellationToken)
        {

            var torneo = new Torneo
            {
                TipoTorneoId = request.TipoTorneoId,
                Nombre = request.Nombre,
                FechaInicio = request.FechaInicio,
                FechaFin = request.FechaFin,
                Anio = request.Anio
            };

            return await _torneoService.CrearTorneo(torneo);

        }
    }

}
