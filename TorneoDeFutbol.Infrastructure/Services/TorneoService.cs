using Microsoft.EntityFrameworkCore;
using TorneoDeFutbol.Application.Common.Interfaces;
using TorneoDeFutbol.Domain;
using TorneoDeFutbol.Domain.Entities;
using TorneoDeFutbol.Infrastructure.Context;

namespace TorneoDeFutbol.Infrastructure.Services
{
    public class TorneoService : ITorneoService
    {
        private readonly TorneoDeFutbolDbContext _context;
        public TorneoService
        (
            TorneoDeFutbolDbContext context
        )
        {
            _context = context;
        }

        public async Task<Torneo> CrearTorneo(Torneo torneo)
        {
            _context.Torneos.Add(torneo);
            await _context.SaveChangesAsync();
            return torneo;
        }
        public async Task<IEnumerable<Torneo>> ObtenerTorneos()
        {
            return await _context.Torneos.ToListAsync();
        }
    }
}
