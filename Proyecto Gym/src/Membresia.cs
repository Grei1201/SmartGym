public class Membresia
{
    public int Id { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }

    public Membresia(int id, DateTime fechaInicio, DateTime fechaFin)
    {
        Id = id;
        FechaInicio = fechaInicio;
        FechaFin = fechaFin;
    }

    public bool EstaPorVencer()
    {
        return (FechaFin - DateTime.Now).Days <= 5;
    }
}
