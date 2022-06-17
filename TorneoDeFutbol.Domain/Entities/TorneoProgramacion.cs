namespace TorneoDeFutbol.Domain.Entities;

public class TorneoProgramacion
{
    public TorneoProgramacion()
    {
        TorneoProgramacionDetalles = new HashSet<TorneoProgramacionDetalle>();
    }

    public int TorneoProgramacionId { get; set; }
    public int TorneoId { get; set; }
    public int NumeroFecha { get; set; }

    public virtual ICollection<TorneoProgramacionDetalle> TorneoProgramacionDetalles { get; set; }
}
