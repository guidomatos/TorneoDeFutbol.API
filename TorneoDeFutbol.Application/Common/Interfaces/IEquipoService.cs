using TorneoDeFutbol.Domain;
using TorneoDeFutbol.Domain.Entities;

namespace TorneoDeFutbol.Application.Common.Interfaces;

public interface IEquipoService
{
    Task<Equipo> CrearEquipo(Equipo equipo);
    Task<int> EliminarEquipo(Equipo equipo);
    Task<int> ActualizarEquipo(Equipo equipo);
    Task<Equipo> ObtenerEquipo(int id);
    Task<IEnumerable<Equipo>> ObtenerEquipos();
}
