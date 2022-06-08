using MediatR;
using TorneoDeFutbol.Application.Common.Interfaces;
using TorneoDeFutbol.Domain;
using TorneoDeFutbol.Domain.Entities;

namespace TorneoDeFutbol.Application.EquipoFutbol.Commands.CrearEquipo
{
    public class CrearEquipoCommand : IRequest<Equipo>
    {
        public string Nombre { get; set; }
        public string CodigoPais { get; set; }
    }

    public class CrearEquipoCommandHandler : IRequestHandler<CrearEquipoCommand, Equipo>
    {

        private readonly IEquipoService _equipoService;

        public CrearEquipoCommandHandler(
            IEquipoService equipoService
            )
        {
            _equipoService = equipoService;
        }

        public async Task<Equipo> Handle(CrearEquipoCommand request, CancellationToken cancellationToken)
        {

            var equipo = new Equipo
            {
                Nombre = request.Nombre,
                CodigoPais = request.CodigoPais
            };

            return await _equipoService.CrearEquipo(equipo);

        }
    }

}
