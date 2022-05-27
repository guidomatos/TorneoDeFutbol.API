using System;
using System.Collections.Generic;

namespace TorneoDeFutbol.Domain
{
    public partial class Equipo
    {
        public int EquipoId { get; set; }
        public string Nombre { get; set; } = null!;
        public string CodigoPais { get; set; } = null!;
    }
}
