namespace TorneoDeFutbol.Domain.Entities;

public class TorneoProgramacionDetalle
{
    public int TorneoProgramacionDetalleId { get; set; }
    public int TorneoProgramacionId { get; set; }
    public int Equipo1 { get; set; }
    public int Equipo2 { get; set; }
    public DateTime? FechaPartido { get; set; }
    public int? CantidadGolesEquipo1 { get; set; }
    public int? CantidadGolesEquipo2 { get; set; }

    public virtual TorneoProgramacion TorneoProgramacion { get; set; } = null!;
}
