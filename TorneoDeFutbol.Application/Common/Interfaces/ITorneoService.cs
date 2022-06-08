using TorneoDeFutbol.Domain.Entities;

namespace TorneoDeFutbol.Application.Common.Interfaces
{
    public interface ITorneoService
    {
        Task<Torneo> CrearTorneo(Torneo equipo);
        Task<IEnumerable<Torneo>> ObtenerTorneos();
    }
}
