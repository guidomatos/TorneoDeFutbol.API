using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorneoDeFutbol.Application.Common.Interfaces;
using TorneoDeFutbol.Domain;
using TorneoDeFutbol.Domain.Entities;
using TorneoDeFutbol.Infrastructure.Context;

namespace TorneoDeFutbol.Infrastructure.Services
{
    public class TorneoEquipoService: ITorneoEquipoService
    {
        private readonly TorneoDeFutbolDbContext _context;
        public TorneoEquipoService
        (
            TorneoDeFutbolDbContext context
        )
        {
            _context = context;
        }

        public async Task<IEnumerable<Equipo>> ObtenerEquiposPorTorneo(int TorneoId)
        {

                var table = from item in _context.Equipos
                        from subItem in item.Torneos
                        where subItem.TorneoId == TorneoId
                        select new Equipo ()
                        {
                            EquipoId = item.EquipoId,
                            Nombre = item.Nombre
                        };

                var list = await table.ToListAsync();

                return list;

        }
    }
}
