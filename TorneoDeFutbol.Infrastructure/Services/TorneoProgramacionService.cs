using Microsoft.EntityFrameworkCore;
using TorneoDeFutbol.Application.Common.Interfaces;
using TorneoDeFutbol.Domain.Entities;
using TorneoDeFutbol.Infrastructure.Context;

namespace TorneoDeFutbol.Infrastructure.Services
{
    public class TorneoProgramacionService : ITorneoProgramacionService
    {
        private readonly TorneoDeFutbolDbContext _context;
        public TorneoProgramacionService
        (
            TorneoDeFutbolDbContext context
        )
        {
            _context = context;
        }

        public async Task<IEnumerable<TorneoProgramacion>> ObtenerProgramacionPorTorneo(int TorneoId)
        {

            var table = from item in _context.TorneoProgramacions
                        where item.TorneoId == TorneoId
                        select new TorneoProgramacion()
                        {
                            TorneoProgramacionId = item.TorneoProgramacionId,
                            NumeroFecha = item.NumeroFecha
                        };

            var list = await table.ToListAsync();

            return list;

        }

        public async Task<int> ProgramarFecha(List<TorneoProgramacionDetalle> listaProgramacion)
        {
            foreach(var item in listaProgramacion)
            {

                var progDet = new TorneoProgramacionDetalle
                {
                    TorneoProgramacionId = item.TorneoProgramacion.TorneoProgramacionId,
                    Equipo1 = item.Equipo1,
                    Equipo2 = item.Equipo2
                };

                _context.TorneoProgramacionDetalles.Add(progDet);

            }
            
            await _context.SaveChangesAsync();
            return 1;
        }
    }
}
