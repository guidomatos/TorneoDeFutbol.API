using TorneoDeFutbol.Domain.Entities;

namespace TorneoDeFutbol.Infrastructure.Services;

public interface IProfesionService
{
    Task<IEnumerable<Profesion>> ObtenerProfesiones();
    Task<Profesion> ObtenerProfesion(int id);
    Task<Profesion> CrearProfesion(Profesion profesion);
    Task<Profesion> ActualizarProfesion(Profesion profesion);
    Task<int> EliminarProfesion(Profesion profesion);
}