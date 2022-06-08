using TorneoDeFutbol.Domain;
using TorneoDeFutbol.Domain.Entities;

namespace TorneoDeFutbol.Application.Common.Interfaces
{
    public interface ITorneoEquipoService
    {
        Task<IEnumerable<Equipo>> ObtenerEquiposPorTorneo(int TorneoId);
    }
}
