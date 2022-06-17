using System;
using System.Collections.Generic;

namespace TorneoDeFutbol.Domain.Entities
{
    public partial class Profesion
    {
        public int ProfesionId { get; set; }
        public string Nombre { get; set; } = null!;
    }
}
