using TorneoDeFutbol.Domain.Entities;
using TorneoDeFutbol.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace TorneoDeFutbol.Infrastructure.Services;

public class ProfesionService : IProfesionService
{
    private readonly TorneoDeFutbolDbContext _context;
    public ProfesionService(TorneoDeFutbolDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Profesion>> ObtenerProfesiones()
    {
        return await _context.Profesions
            .ToListAsync();
    }

    public async Task<Profesion> ObtenerProfesion(int id)
    {
        return await _context.Profesions
            .FirstOrDefaultAsync(x => x.ProfesionId == id);
    }

    public async Task<Profesion> CrearProfesion(Profesion profession)
    {
        _context.Profesions.Add(profession);
        await _context.SaveChangesAsync();
        return profession;
    }
    public async Task<Profesion> ActualizarProfesion(Profesion profession)
    {
        _context.Profesions.Update(profession);
        await _context.SaveChangesAsync();
        return profession;
    }

    public async Task<int> EliminarProfesion(Profesion profession)
    {
        _context.Profesions.Remove(profession);
        return await _context.SaveChangesAsync();
    }
}