using System;
using System.Collections.Generic;

namespace TorneoDeFutbol.Domain.Entities
{
    public partial class Equipo
    {
        public Equipo()
        {
            Torneos = new HashSet<Torneo>();
        }

        public int EquipoId { get; set; }
        public string Nombre { get; set; } = null!;
        public string CodigoPais { get; set; } = null!;

        public virtual ICollection<Torneo> Torneos { get; set; }
    }
}
