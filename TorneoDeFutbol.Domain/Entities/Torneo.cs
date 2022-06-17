using System;
using System.Collections.Generic;

namespace TorneoDeFutbol.Domain.Entities
{
    public partial class Torneo
    {
        public Torneo()
        {
            Equipos = new HashSet<Equipo>();
        }

        public int TorneoId { get; set; }
        public int TipoTorneoId { get; set; }
        public string Nombre { get; set; } = null!;
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public int Anio { get; set; }

        public virtual TipoTorneo TipoTorneo { get; set; } = null!;
        public virtual ICollection<Equipo> Equipos { get; set; }
    }
}
