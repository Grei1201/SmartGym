// Esta clase es para: Gestionar la información de las membresías de los clientes.
public class Membresia
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public bool Activa { get; set; }
}
