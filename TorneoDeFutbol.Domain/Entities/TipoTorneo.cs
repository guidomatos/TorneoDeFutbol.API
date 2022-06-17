using System;
using System.Collections.Generic;

namespace TorneoDeFutbol.Domain.Entities
{
    public partial class TipoTorneo
    {
        public TipoTorneo()
        {
            Torneos = new HashSet<Torneo>();
        }

        public int TipoTorneoId { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Torneo> Torneos { get; set; }
    }
}
