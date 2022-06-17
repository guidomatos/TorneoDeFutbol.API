using TorneoDeFutbol.Domain.Entities;

namespace TorneoDeFutbol.Application.Common.Interfaces; 

public interface ITorneoProgramacionService
{
    Task<IEnumerable<TorneoProgramacion>> ObtenerProgramacionPorTorneo(int TorneoId);
    Task<int> ProgramarFecha(List<TorneoProgramacionDetalle> listaProgramacion);
}
