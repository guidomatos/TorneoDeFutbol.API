using Microsoft.EntityFrameworkCore;
using TorneoDeFutbol.Application.Common.Interfaces;
using TorneoDeFutbol.Domain;
using TorneoDeFutbol.Domain.Entities;
using TorneoDeFutbol.Infrastructure.Context;

namespace TorneoDeFutbol.Infrastructure.Services
{
    public class EquipoService : IEquipoService
    {
        private readonly TorneoDeFutbolDbContext _context;
        public EquipoService
        (
            TorneoDeFutbolDbContext context
        )
        {
            _context = context;
        }

        public async Task<Equipo> CrearEquipo(Equipo equipo)
        {
            _context.Equipos.Add(equipo);
            await _context.SaveChangesAsync();
            return equipo;
        }
        public async Task<int> EliminarEquipo (Equipo equipo)
        {
            _context.Equipos.Remove(equipo);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> ActualizarEquipo(Equipo equipo)
        {
            _context.Equipos.Update(equipo);
            return await _context.SaveChangesAsync();
        }
        public async Task<Equipo> ObtenerEquipo(int id)
        {
            return await _context.Equipos.FirstOrDefaultAsync(e => e.EquipoId == id);
        }
        public async Task<IEnumerable<Equipo>> ObtenerEquipos()
        {
            return await _context.Equipos.ToListAsync();
        }
    }
}
